namespace FSharp.Business.Models.Product

open FSharp.Business.Models.Common
open Microsoft.FSharp.Core

type Promotion =
    | PercentageOff of Amount * Percentage
    | Promoted of Amount

type Price =
    | Free
    | StandardPrice of Amount
    | PromotedPrice of Promotion

type Product =
    {
        Id:Id1To99
        Name:String10
        Description:String50 option
        Price: Price
    }

module Product =
    let create id name description price = { Id=id; Name=name; Description=description; Price=StandardPrice price }
    
    let createWithPromotion id name description promotion = { Id=id; Name=name; Description=description; Price=PromotedPrice promotion }
    
    let createWithFreePrice id name description = { Id=id; Name=name; Description=description; Price=Free }