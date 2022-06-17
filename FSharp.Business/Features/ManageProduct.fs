module FSharp.Business.Features.ManageProduct

    open FSharp.Business.Models.Common
    open FSharp.Business.Models.Product

    let createProduct name description = Product.create name description
    
    let getProducts =
        [createProduct (Id1To99.create 1).Value (String10.create "BD").Value (String50.create "Une BD");
         createProduct (Id1To99.create 2).Value (String10.create "Table").Value (String50.create "Une Table");
         createProduct (Id1To99.create 3).Value (String10.create "Livre").Value (String50.create "Un Livre");
         createProduct (Id1To99.create 4).Value (String10.create "Ordinateur").Value (String50.create "Un ordinateur")]