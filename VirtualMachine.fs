namespace Doig.VirtualMachine

open System
open Microsoft.FSharp.Core

type Permission = interface end

type Read = inherit Permission
type Write = inherit Permission
type ReadWrite = inherit Read inherit Write    

type 'a VirtualMachine when 'a :> Permission = 
      private { version : string }

module vm =

    let private createVM = { version = "4.0" }

    let createReadVM = 
        let vm: Read VirtualMachine = createVM
        vm

    let createWriteVM = 
        let vm: Write VirtualMachine = createVM
        vm

    let createReadWriteVM = 
        let vm: ReadWrite VirtualMachine = createVM
        vm

    let getVersion (vm: #Read VirtualMachine) =
        vm.version

    let destroy (vm: #Write VirtualMachine) = 
        printfn "boom!"
         




