﻿open System
open FSharp.Business.Features
open FSharp.Business.Models.Basket
open FSharp.Console

let mutable _basket = ManageBasket.createEmpty
let mutable _order = ManageOrder.createEmpty
let _products = ManageProduct.getProducts

let addProductToBasket products basket =
    _basket <- Render.renderAddProductToBasket products basket |> FilledBasket
    
let renderValidateBasketAndCreateOrder basket =
    _order <- Render.renderValidateBasketAndCreateOrder basket
    _basket <- ManageBasket.createEmpty

let handleKey key products basket =
    match key with
    | ConsoleKey.A -> Render.renderShowCatalog products
    | ConsoleKey.B -> addProductToBasket products basket
    | ConsoleKey.C -> Render.renderShowBasket basket
    | ConsoleKey.D -> renderValidateBasketAndCreateOrder basket
    | _ -> failwith "aie"

Render.renderMenu

while true do
    let key = Console.ReadKey().Key
    handleKey key _products _basket
