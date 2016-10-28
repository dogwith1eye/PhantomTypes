// Learn more about F# at http://fsharp.org

open System
open Microsoft.FSharp.Core

type 'a VirtualMachine = 
  { version : string 
    (* more fields *)
  }

type Read = interface end
type ReadWrite = interface end

let getVersion (vm: Read VirtualMachine) = vm.version

let destroy (vm: ReadWrite VirtualMachine) = printfn "poof!"

[<EntryPoint>]
let main argv = 

    let vm1: Read VirtualMachine = { version = "2.0" }
    let vm2: ReadWrite VirtualMachine = { version = "2.0" }

    //works as advertised 
    //destroy vm1
    destroy vm2

    let v1 = getVersion vm1

    // same problem
    // let v2 = getVersion vm2

    // new problem
    let vm4 = { version = "3.0" }
    let v4 = getVersion vm4
    destroy vm4

    0 // return an integer exit code
