﻿'
' HelloWorld.vb
'  
' Author(s):
'       Alessio Parma <alessio.parma@gmail.com>
' 
' Copyright (c) 2012-2016 Alessio Parma <alessio.parma@gmail.com>
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in
' all copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
' THE SOFTWARE.

Public Module HelloWorld
    Private Iterator Function SayHello(sim As SimEnvironment) As IEnumerable(Of SimEvent)
        While True
            Yield sim.Timeout(2.1)
            Console.WriteLine("Hello World at {0}!", sim.Now)
        End While
    End Function

    ' Expected output:
    ' Hello World simulation :)
    ' Hello World at 2.1!
    ' Hello World at 4.2!
    ' Hello World at 6.3!
    ' Hello World at 8.4!
    Sub Run()
        Console.WriteLine("Hello World simulation :)")
        Dim env = Sim.Environment()
        env.Process(SayHello(env))
        env.Run(10)
    End Sub
End Module
