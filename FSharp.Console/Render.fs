﻿module FSharp.Console.Render

open System
open FSharp.Business.Features
open FSharp.Business.Models.Common
open FSharp.Business.Models.Product
open FSharp.Business.Models.Basket

let renderMenu =
    printfn "Bienvenue"
    printfn "----------------------------------"
    printfn "a - Voir le catalogue."
    printfn "b - Ajouter un produit au panier."
    printfn "c - Voir votre panier."
    printfn "d - Valider le panier et commander."
    printfn "----------------------------------"
    printfn ""
    
let renderShowCatalog (products:Product list) =
    printfn ""
    printfn "------------------- Catalogue ----------------------"
    printfn "ID -- Nom -- Description -- Prix"
    
    for product in products do
         let description =
             match product.Description with
             | Some(String50 s) -> s
             | None -> "Pas de description"
             
         let price =
             match product.Price with
             | Free -> "gratuit"
             | StandardPrice standardPrice -> Amount.toString standardPrice
             | PromotedPrice promotedPrice ->
                 match promotedPrice with
                 | Promoted promoted -> $"PROMO !! %s{Amount.toString promoted}"
                 | PercentageOff(price, percentageOff) -> $"PROMO !! %s{Amount.toString price} (%s{Percentage.toString percentageOff} de réduction)"
         
         printfn $"%s{Id1To99.toString product.Id} -- %s{String10.value product.Name} -- %s{description} -- %s{price}"
         
    printfn "----------------------------------------------------"
    printfn ""
         
let renderAddProductToBasket products basket =
     printfn ""
     printfn "---------------------------"
     printfn "Renseigner l'ID du produit."
     printfn "---------------------------"
     printfn ""
     
     let id = 
         match Id1To99.create (Console.ReadLine() |> int) with
         | Some id -> id 
         | None -> failwith "ID incorrect"
         
     let product = products |> List.find(fun x -> x.Id = id)
     
     printfn ""
     printfn "---------------------------"
     printfn "Renseigner la quantité."
     printfn "---------------------------"
     printfn ""
     
     let quantity =
         match Quantity1To99.create (Console.ReadLine() |> int) with
         | Some quantity -> quantity 
         | None -> failwith "Quantité incorrect"
         
     ManageBasket.addProductToBasket product quantity basket
 
let renderShowBasket (basket:Basket) =
    printfn ""
    printfn "-------------------- Panier -----------------------"
    
    match basket with
        | FilledBasket filledBasket ->
            printfn "ID -- Nom -- Quantité -- Prix -- Total"
            for item in filledBasket.Items do
                printfn $"%s{string item.Product.Id} -- %s{string item.Product.Name} -- %s{string item.Quantity}"
        | EmptyBasket -> printfn "Panier vide."
        
    printfn "----------------------------------------------------"
    printfn "Total panier: {}"
    printfn "----------------------------------------------------"
    
let renderValidateBasketAndCreateOrder basket =
    printfn ""
    printfn "---------------------------"
    printfn "Renseigner votre prénom."
    printfn "---------------------------"
    printfn ""
    
    let firstName = 
         match String10.create (Console.ReadLine()) with
         | Some firstName -> firstName
         | None -> failwith "prénom incorrect"
    
    printfn ""
    printfn "---------------------------"
    printfn "Renseigner votre nom."
    printfn "---------------------------"
    printfn ""
    
    let lastName = 
         match String10.create (Console.ReadLine()) with
         | Some lastName -> lastName
         | None -> failwith "nom incorrect"
    
    printfn ""
    printfn "---------------------------"
    printfn "Renseigner votre email."
    printfn "---------------------------"
    printfn ""
    
    let email = 
         match Email.create (Console.ReadLine()) with
         | Some email -> email
         | None -> failwith "email incorrect"
    
    printfn ""
    printfn "---------------------------"
    printfn "Renseigner votre adresse."
    printfn "---------------------------"
    printfn ""
    
    let address = 
         match Address.create (Console.ReadLine()) with
         | Some address -> address
         | None -> failwith "adresse incorrect"
         
    ManageOrder.create basket firstName lastName email address