// Learn more about F# at http://fsharp.org

open System
open Microsoft.FSharp.Core

type VirtualMachine = 
  { version : string 
    (* more fields *)
  }

let getVersion vm = vm.version

let destroy (vm:VirtualMachine) = printfn "poof!"

type ReadOnlyVirtualMachine = 
    ReadOnlyVirtualMachine of VirtualMachine
type ReadWriteVirtualMachine = 
    ReadWriteVirtualMachine of VirtualMachine

let roGetVersion (ReadOnlyVirtualMachine(vm)) = vm.version
let rwDestroy (ReadWriteVirtualMachine(vm)) = printfn "poof!"



let rwGetVersion (ReadWriteVirtualMachine(vm)) = vm.version

[<Measure>] type ReadOnlyMeasure
[<Measure>] type ReadWriteMeasure

[<EntryPoint>]
let main argv = 

    let vm1 = { version = "1.0" }
    let vm2 = { version = "1.0" }

    let v1 = getVersion vm1
    let v2 = getVersion vm2

    destroy vm1
    destroy vm2

    let vm3 = ReadOnlyVirtualMachine { version = "1.0" }
    let vm4 = ReadWriteVirtualMachine { version = "1.0" }

    //works as advertised 
    //rwDestroy vm3
    rwDestroy vm4

    let v3 = roGetVersion vm3
    let v4 = rwGetVersion vm4

    0 // return an integer exit code