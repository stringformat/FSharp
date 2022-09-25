module FSharp.Business.Features.ManageBasket

    open FSharp.Business.Models.Basket

    let private excludeProduct product items =
        items |> List.filter (fun x -> x.Product <> product)
    
    let createEmpty = Basket.createEmpty
    
    let addProductToBasket = Basket.addItem
    
    let deleteProduct product basket =
        match basket with
        | EmptyBasket -> failwith "aie"
        | FilledBasket filledBasket ->
            let items = filledBasket.Items |> List.filter (fun x -> x.Product <> product)
            Basket.create items
    
    let changeProductQuantity quantity product basket =
        match basket with
        | EmptyBasket -> failwith "aie"
        | FilledBasket filledBasket ->
            let newItem = { Product=product; Quantity=quantity; Total }
            let items = excludeProduct product filledBasket.Items
            let newItems = items @ [newItem]
            Basket.create newItems