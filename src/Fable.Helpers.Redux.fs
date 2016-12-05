module Fable.Helpers.Redux

open Fable.Core.JsInterop

open Fable.Import

let createStore (reducer : 'TState -> 'TAction -> 'TState) (initialState : 'TState) (middleware : Redux.Middleware option) =
    let rdc = fun state action ->
        match box action?Case with
        | :? string -> (System.Func<_,_,_> reducer).Invoke(state, action)
        | _ -> state
    match middleware with
    | Some(m) -> Redux.createStore(System.Func<_,_,_> rdc, initialState, m)
    | None -> Redux.createStore(System.Func<_,_,_> rdc, initialState)

[<Fable.Core.Emit("$0 instanceof Function")>]
let isFunction a : bool = failwith "JS Only"

let unionMiddleware (_ : Redux.IUntypedStore) (next : obj -> unit) (action : obj) =
    if isFunction action then
        let o = toPlainJsObj action
        if o?hasOwnProperty$("Case") |> unbox<bool> then 
            let o = toPlainJsObj action
            o?``type`` <- o?Case
            o |> next
        else
            action |> next
