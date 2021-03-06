﻿//  
// ClockExample.cs
//  
// Author(s):
//     Alessio Parma <alessio.parma@gmail.com>
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

namespace DIBRIS.Dessert.Examples.CSharp.SimPy3
{
    using System;
    using System.Collections.Generic;

    public static class ClockExample
    {
        static IEnumerable<SimEvent> Clock(SimEnvironment env, string name, double tick)
        {
            while (true) {
                Console.WriteLine("{0} {1:0.0}", name, env.Now);
                yield return env.Timeout(tick);
            }
        }

        public static void Run()
        {
            var env = Sim.Environment();
            env.Process(Clock(env, "fast", 0.5));
            env.Process(Clock(env, "slow", 1.0));
            env.Run(until: 2);
        }
    }
}