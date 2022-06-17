module FSharp.Business.Features.ManageOrder

    open FSharp.Business.Models.Order

    let createEmpty = EmptyOrder
    
    let create basket firstName lastName email address =
        Order.create basket firstName lastName email address
    
    let send order =
        let preparedOrder = Order.prepare order
        Order.send preparedOrder
    
    let close order = Order.close order