module FSharp.Business.Features.ManageBasket

    open FSharp.Business.Models.Basket

    let private excludeProduct product items =
        items |> List.filter (fun x -> x.Product <> product)
    
    let createEmpty = Basket.createEmpty
    
    let addProduct product quantity basket =
        Basket.addItem product quantity basket
    
    let deleteProduct product (FilledBasket basket) =
        let items = basket |> List.filter (fun x -> x.Product <> product)
        Basket.create items
    
    let changeProductQuantity quantity product (FilledBasket basket) =
        let newItem = Basket.createBasketItem product quantity
        let items = excludeProduct product basket
        let newItems = items @ [newItem]
        Basket.create newItems