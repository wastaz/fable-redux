﻿namespace Fable.Import

open Fable.Core
open Fable.Core.JsInterop

module Redux =
    type Listener = unit -> unit
    type UnSubscribe = unit -> unit

    type Reducer<'TState, [<Pojo>] 'TAction> = System.Func<'TState, 'TAction, 'TState>
    
    type IUntypedStore = 
        abstract getState : unit -> obj
        abstract dispatch : obj -> unit

    type IStore<'TState, [<Pojo>] 'TAction> = 
        inherit IUntypedStore
        abstract dispatch : 'TAction -> unit
        abstract getState : unit -> 'TState
        abstract subscribe : Listener -> UnSubscribe
        abstract replaceReducer : Reducer<'TState, 'TAction> -> unit
        

    type Middleware = IUntypedStore -> (obj -> unit) -> obj -> unit

    type Globals = 
        abstract applyMiddleware : [<System.ParamArray>] middlewares : Middleware [] -> Middleware
        abstract createStore : reducer : Reducer<'TState, 'TAction> * ?initialState : 'TState * ?middleware : Middleware -> IStore<'TState, 'TAction>

[<AutoOpen>]
module Redux_Extensions =
    let [<Import("*","redux")>] Redux: Redux.Globals = jsNative
    
