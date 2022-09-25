namespace FSharp.Business.Models.Order

open FSharp.Business.Models.Common
open FSharp.Business.Models.Product
open FSharp.Business.Models.Basket

type OrderItem =
    {
        Product:Product
        Quantity:Quantity1To99
    }
    
type Order =
    {
        FirstName:String10
        LastName:String10
        Email:Email
        Address:Address
        Items:OrderItem list
    }

type OrderState =
    | EmptyOrder
    | NewOrder of Order
    | PreparedOrder of Order
    | SentOrder of Order
    | ClosedOrder of Order

module Order =
    let create basket firstName lastName email address =
        match basket with
        | EmptyBasket -> failwith "aie"
        | FilledBasket filledBasket ->
            let items = filledBasket.Items |> List.map (fun x -> { Product=x.Product; Quantity=x.Quantity })
            NewOrder
                {
                    FirstName=firstName
                    LastName=lastName
                    Email=email
                    Address=address
                    Items=items
                } 
    
    let prepare order =
        match order with
        | EmptyOrder | ClosedOrder _ | SentOrder _ | PreparedOrder _ -> failwith "aie"
        | NewOrder newOrder -> PreparedOrder newOrder
        
    let send order =
        match order with
        | EmptyOrder | ClosedOrder _ | SentOrder _ | NewOrder _ -> failwith "aie"
        | PreparedOrder preparedOrder -> SentOrder preparedOrder
    
    let close order =
        match order with
        | EmptyOrder | ClosedOrder _ | PreparedOrder _ | NewOrder _ -> failwith "aie"
        | SentOrder sentOrder -> ClosedOrder sentOrder
