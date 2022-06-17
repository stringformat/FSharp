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

    let createBasketItem product quantity = { Product=product; Quantity=quantity }
    
    let addItem product quantity basket =
        let item = createBasketItem product quantity
        match basket with
        | FilledBasket basketItems -> FilledBasket (basketItems @ [item])
        | EmptyBasket -> FilledBasket [item]