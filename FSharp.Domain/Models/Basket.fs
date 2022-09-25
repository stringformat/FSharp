namespace FSharp.Business.Models.Basket

open FSharp.Business.Models.Common
open FSharp.Business.Models.Product
open Microsoft.FSharp.Core

type BasketItem =
    {
        Product:Product
        Quantity:Quantity1To99
        Total:Amount
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
    let private calculateTotalBasket items =
        let rec calculate index (items:BasketItem list) =
            let total = Product.getAmount items[index].Product * Quantity1To99.toDecimal items[index].Quantity
            total + calculate (index + 1) items
        Amount.create (calculate 0 items)
    
    let private calculateTotalItem product quantity =
        let totalItem = Product.getAmount product * Quantity1To99.toDecimal quantity
        Amount.create totalItem
    
    let createEmpty = EmptyBasket
    
    let create items = { Items=items; Total=(calculateTotalBasket items).Value }
    
    let addItem product quantity basket =
        let item = { Product=product; Quantity=quantity; Total= (calculateTotalItem product quantity).Value  }
        match basket with
        | FilledBasket filledBasket ->
            let items = (filledBasket.Items @ [item])
            { Items=items; Total= (calculateTotalBasket items).Value } 
        | EmptyBasket ->
            { Items=[item]; Total= (Amount.create (Product.getAmount item.Product)).Value }