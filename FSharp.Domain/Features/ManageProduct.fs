module FSharp.Business.Features.ManageProduct

    open FSharp.Business.Models.Common
    open FSharp.Business.Models.Product

    let createProduct = Product.create
    
    let createProductWithPromotion = Product.createWithPromotion
    
    let createProductWithFreePrice = Product.createWithFreePrice
    
    let getProducts =
        [
         createProductWithPromotion
             (Id1To99.create 1).Value
             (String10.create "BD").Value
             (String50.create "Une BD")
             (PercentageOff ((Amount.create 10).Value, (Percentage.create 15).Value));
         createProductWithPromotion
             (Id1To99.create 1).Value
             (String10.create "Livre").Value
             (String50.create "Un livre")
             (Promoted (Amount.create 15).Value);
         createProduct
             (Id1To99.create 1).Value
             (String10.create "BD").Value
             (String50.create "Une BD")
             (Amount.create 30).Value
         createProduct
             (Id1To99.create 1).Value
             (String10.create "BD").Value
             (String50.create "Une BD")
             (Amount.create 45).Value
         createProductWithFreePrice
             (Id1To99.create 1).Value
             (String10.create "BD").Value
             (String50.create "Une BD")
        ]