module FSharp.Business.Features.ManageProduct

    open FSharp.Business.Models.Common
    open FSharp.Business.Models.Product

    let createProduct id name description price =
        let validId =
            match id with
            | Some x -> x
            | None -> failwith "aie"
        let validPrice =
            match price with
            | Some x -> x
            | None -> failwith "aie"
        let validName =
            match name with
            | Some x -> x
            | None -> failwith "aie"
        Product.create validId validName description validPrice
    
    let createProductWithPromotion id name description promotion =
        let validId =
            match id with
            | Some x -> x
            | None -> failwith "aie"
        let validPromotion =
            match promotion with
            | Some x -> x
            | None -> failwith "aie"
        let validName =
            match name with
            | Some x -> x
            | None -> failwith "aie"
        Product.createWithPromotion validId validName description validPromotion
    
    let createProductWithFreePrice id name description =
        let validId =
            match id with
            | Some x -> x
            | None -> failwith "aie"
        let validName =
            match name with
            | Some x -> x
            | None -> failwith "aie"
        Product.createWithFreePrice validId validName description
    
    let getProducts =
        [
         createProduct
             (Id1To99.create 1)
             (String10.create "BD")
             (String50.create "Une BD")
             (Amount.create 30)
         createProduct
             (Id1To99.create 2)
             (String10.create "Livre")
             (String50.create "Un livre")
             (Amount.create 45)
         createProductWithFreePrice
             (Id1To99.create 3)
             (String10.create "Manga")
             (String50.create "Un Manga")
        ]