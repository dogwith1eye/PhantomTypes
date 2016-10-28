// Learn more about F# at http://fsharp.org

open System
open Doig.VirtualMachine

[<EntryPoint>]
let main argv = 

    let vm1 = vm.createReadVM
    let vm2 = vm.createWriteVM
    let vm3 = vm.createReadWriteVM

    let v1 = vm.getVersion vm1
    //let v2 = vm.getVersion vm2
    let v3 = vm.getVersion vm3

    //vm.destroy vm1
    vm.destroy vm2
    vm.destroy vm3

    // not accessible 
    //let vm4 = { version = "3.0" }
    
    // no proper subtypes
    //let vm5: Permission VirtualMachine = vm1 :> Permission VirtualMachine

    0 // return an integer exit code
