namespace FSharp.Business.Models.Basket

open FSharp.Business.Models.Common
open FSharp.Business.Models.Product

type BasketItem =
    {
        Product:Product
        Quantity:Quantity1To99
    }
    
type Basket =
    | FilledBasket of BasketItem list
    | EmptyBasket

module Basket =
    let createEmpty = EmptyBasket
    
    let create items = FilledBasket items
    
    let addItem product quantity basket =
        let item = { Product=product; Quantity=quantity }
        match basket with
        | FilledBasket basketItems -> FilledBasket (basketItems @ [item])
        | EmptyBasket -> FilledBasket [item]