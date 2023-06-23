# Repro for System.TypeInitializationException in Blazor WASM:

Somewhat twisted (but valid) layout of [types](./Types.cs) can crash WASM:
```console
Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]
      Unhandled exception rendering component: The type initializer for 'NestedStatic' threw an exception.
System.TypeInitializationException: The type initializer for 'NestedStatic' threw an exception.
 ---> System.TypeInitializationException: The type initializer for 'BlzWasmTypeInitRepro.TwistedType' threw an exception.
 ---> System.ArgumentNullException: Value cannot be null. (Parameter 'source')
   at System.Linq.ThrowHelper.ThrowArgumentNullException(ExceptionArgument argument)
   at System.Linq.Enumerable.Prepend[TwistedType](IEnumerable`1 source, TwistedType element)
   at BlzWasmTypeInitRepro.TwistedType..cctor() in BlzWasmTypeInitRepro\Types.cs:line 5
   --- End of inner exception stack trace ---
   at BlzWasmTypeInitRepro.TwistedType.NestedStatic..cctor() in BlzWasmTypeInitRepro\Types.cs:line 9
   --- End of inner exception stack trace ---
   at BlzWasmTypeInitRepro.Pages.Index.BuildRenderTree(RenderTreeBuilder __builder) in BlzWasmTypeInitRepro\Pages\Index.razor:line 3
   at Microsoft.AspNetCore.Components.ComponentBase.<.ctor>b__6_0(RenderTreeBuilder builder)
   at Microsoft.AspNetCore.Components.Rendering.ComponentState.RenderIntoBatch(RenderBatchBuilder batchBuilder, RenderFragment renderFragment, Exception& renderFragmentException)
```
Just clone and run.
This runs fine on server. Replacing the field at line 5 with a method _can_ make the problem go away (which I used as a work around for my actual project) but that is not the point for this repo.

Versions:
- Chrome: 116.0.5829.0
- .net: 7.0.304