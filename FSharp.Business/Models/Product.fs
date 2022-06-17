namespace FSharp.Business.Models.Product

open FSharp.Business.Models.Common

type Promotion =
    | PercentageOff of decimal
    | PromotedPrice of decimal

type Price =
    | Free
    | Price of decimal
    | Promotion of Promotion

type Product =
    {
        Id:Id1To99
        Name:String10
        Description:String50 option
        Price: Price
    }

module Product =
    let create id name description price = { Id=id; Name=name; Description=description; Price=price }