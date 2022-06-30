module FSharp.Business.Features.ManageBasket

    open FSharp.Business.Models.Basket

    let private excludeProduct product items =
        items |> List.filter (fun x -> x.Product <> product)
    
    let createEmpty = Basket.createEmpty
    
    let addProductToBasket = Basket.addItem
    
    let deleteProduct product (FilledBasket basket) =
        let items = basket.Items |> List.filter (fun x -> x.Product <> product)
        Basket.create items
    
    let changeProductQuantity quantity product (FilledBasket basket) =
        let newItem = { Product=product; Quantity=quantity }
        let items = excludeProduct product basket.Items
        let newItems = items @ [newItem]
        Basket.create newItems