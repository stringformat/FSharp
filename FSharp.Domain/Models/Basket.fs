namespace FSharp.Business.Models.Basket

open FSharp.Business.Models.Common
open FSharp.Business.Models.Product
open Microsoft.FSharp.Core

type BasketItem =
    {
        Product:Product
        Quantity:Quantity1To99
    }

type FilledBasket =
    {
        Items:BasketItem list
        Total:Amount
    }
   
type Basket =
    | FilledBasket of FilledBasket
    | EmptyBasket

module Basket =
    let private getProductAmount product =
        match product.Price with
                | Free -> decimal 0
                | StandardPrice(Amount amount) -> amount
                | PromotedPrice promotion ->
                    match promotion with
                    | Promoted(Amount amount) -> amount
                    | PercentageOff(Amount amount, _) -> amount
    
    let private calculateTotalBasket (items:BasketItem list) =
        let rec calculate (index:int) (items:BasketItem list) =
            let total =
                getProductAmount items[index].Product  
            total + calculate (index + 1) items
        Amount.create (calculate 0 items)
    
    let createEmpty = EmptyBasket
    
    let create items = { Items=items; Total=(calculateTotalBasket items).Value }
    
    let addItem product quantity basket =
        let item = { Product=product; Quantity=quantity }
        match basket with
        | FilledBasket filledBasket ->
            let items = (filledBasket.Items @ [item])
            { Items=items; Total= (calculateTotalBasket items).Value } 
        | EmptyBasket ->
            { Items=[item]; Total= (Amount.create (getProductAmount item.Product)).Value }