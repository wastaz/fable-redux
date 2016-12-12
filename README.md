# fable-redux

Fable bindings and helpers for the [redux](https://github.com/reactjs/redux) state container.

## Installation

    $ npm install --save redux fable-core
    $ npm install --save-dev fable-redux

## Usage

In a F# project (.fsproj)

    <ItemGroup>
        <Reference Include="node_modules/fable-core/Fable.Core.dll" />
        <Reference Include="node_modules/fable-redux/Fable.Redux.dll" />
    </ItemGroup>

## Related projects

Also have a look at my quite opinionated fable bindings for [react-redux](https://github.com/reactjs/react-redux)
as well as my bindings for [redux-thunk](https://github.com/gaearon/redux-thunk) as well as the excellent
react bindings [fable-import-react](https://www.npmjs.com/package/fable-import-react).

I personally recommend using them all together, but these bindings should also be useful on their own.


## License 

MIT, feel free to fork and/or send pull requests :)