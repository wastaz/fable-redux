module Fable.Helpers.Redux

open Fable.Core.JsInterop

open Fable.Import

let createStore (reducer : 'TState -> 'TAction -> 'TState) (initialState : 'TState) (middleware : Redux.Middleware option) =
    match middleware with
    | Some(m) -> Redux.createStore(System.Func<_,_,_> reducer, initialState, m)
    | None -> Redux.createStore(System.Func<_,_,_> reducer, initialState)
