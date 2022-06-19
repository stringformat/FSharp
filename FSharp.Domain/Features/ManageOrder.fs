module FSharp.Business.Features.ManageOrder

    open FSharp.Business.Models.Order

    let createEmpty = EmptyOrder
    
    let create = Order.create
    
    let prepareAndSend = Order.prepare >> Order.send
    
    let close = Order.close