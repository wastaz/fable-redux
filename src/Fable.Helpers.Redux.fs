module Fable.Helpers.Redux

open Fable.Core.JsInterop

open Fable.Import

let createStore (reducer : 'TState -> 'TAction -> 'TState) (initialState : 'TState) (middleware : Redux.Middleware option) =
    match middleware with
    | Some(m) -> Redux.createStore(System.Func<_,_,_> reducer, initialState, m)
    | None -> Redux.createStore(System.Func<_,_,_> reducer, initialState)

[<Fable.Core.Emit("$0 instanceof Function")>]
let isFunction a : bool = failwith "JS Only"

let unionMiddleware (_ : Redux.IUntypedStore) (next : obj -> unit) (action : obj) =
    if not <| isFunction action then
        let o = toPlainJsObj action
        if o?hasOwnProperty$("Case") |> unbox<bool> then 
            let o = toPlainJsObj action
            o?``type`` <- o?Case
            o |> next
        else
            action |> next
