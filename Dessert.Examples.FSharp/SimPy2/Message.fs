﻿// 
// Message.fs
//  
// Author(s):
//       Alessio Parma <alessio.parma@gmail.com>
// 
// Copyright (c) 2012-2016 Alessio Parma <alessio.parma@gmail.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

module DIBRIS.Dessert.Examples.FSharp.SimPy2.Message

open DIBRIS.Dessert

let go (env: SimEnvironment) id len = seq<SimEvent> {
    printfn "%g %d Starting" env.Now id
    yield upcast env.Timeout 100.0
    printfn "%g %d Arrived" env.Now id
}

// Expected output:
// Starting simulation
// 0 1 Starting
// 6 2 Starting
// 100 1 Arrived
// 106 2 Arrived
// Current time is 106
let run() =
    let env = Sim.Environment()
    env.Process (go env 1 203) |> ignore
    env.DelayedProcess (go env 2 33, delay = 6.0) |> ignore
    printfn "Starting simulation"
    env.Run (until = 200.0)
    printfn "Current time is %g" env.Now