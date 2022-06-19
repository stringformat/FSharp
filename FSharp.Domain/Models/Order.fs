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
    let create (FilledBasket basket) firstName lastName email address =
        let items = basket |> List.map (fun x -> { Product=x.Product; Quantity=x.Quantity })
        NewOrder
            {
                FirstName=firstName
                LastName=lastName
                Email=email
                Address=address
                Items=items
            }
    
    let prepare (NewOrder order) = PreparedOrder order
    
    let send (PreparedOrder order) = SentOrder order
    
    let close (SentOrder order) = ClosedOrder order