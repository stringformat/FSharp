namespace FSharp.Business.Models.Common

open System.Text.RegularExpressions
open Microsoft.FSharp.Core

type String10 = String10 of string

module String10 =
    let create (s:string) =
        if s.Length <= 10
        then Some (String10 s)
        else None
        
    let value (String10 s) = s

type String50 = String50 of string

module String50 =
    let create (s:string) =
        if s.Length <= 50
        then Some (String50 s)
        else None
        
    let value (String50 s) = s
    
type Quantity1To99 = Quantity1To99 of int

module Quantity1To99 =
    let create (i:int) =
        if i >= 1 && i <= 99
        then Some (Quantity1To99 i)
        else None
        
    let value (Quantity1To99 q) = q
    
    let toString (Quantity1To99 q) = string q
    
    let toDecimal (Quantity1To99 q) = decimal q 
        
type Id1To99 = Id1To99 of int

module Id1To99 =
    let create (i:int) =
        if i >= 1 && i <= 99
        then Some (Id1To99 i)
        else None
        
    let value (Id1To99 id) = id
    
    let toString (Id1To99 id) = string id

type Email = Email of string

module Email =
    let create (s:string) =
        if Regex.IsMatch(s,"^\S+@\S+\.\S+$")
            then Some (Email s)
            else None
        
    let value (Email e) = e
    
type Address = Address of string

module Address =
    let create (s:string) =
        if Regex.IsMatch(s,"^\d+ rue \S+ \S+ \d+ \S+$")
            then Some (Address s)
            else None
        
    let value (Address a) = a
    
type Percentage = Percentage of int

module Percentage =
    let create i =
        if i >= 0 && i <= 100 
            then Some (Percentage i)
            else None
            
    let toDouble (Percentage p) =
        double ((1 / 100) * p)
        
    let toString (Percentage p) =
        $"%s{string p}%%"
        
type Amount = Amount of decimal

module Amount =
    let create (a:decimal) =
        if a >= 0 && a <= 100 
            then Some (Amount a)
            else None
            
    let value (Amount a) = a
    
    let def = Amount 0
        
    let toString (Amount a) =
        $"%s{string a}€"