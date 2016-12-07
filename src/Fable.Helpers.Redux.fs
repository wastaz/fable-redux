module Fable.Helpers.Redux

open Fable.Core.JsInterop

open Fable.Import

let createStore (reducer : 'TState -> 'TAction -> 'TState) (initialState : 'TState) (middleware : Redux.Middleware option) =
    let rdc = fun state action ->
        match box action?``type`` with
        | :? string as s when s = "@@redux/INIT" -> state
        | _ -> (System.Func<_,_,_> reducer).Invoke(state, action)
    match middleware with
    | Some(m) -> Redux.createStore(System.Func<_,_,_> rdc, initialState, m)
    | None -> Redux.createStore(System.Func<_,_,_> rdc, initialState)
