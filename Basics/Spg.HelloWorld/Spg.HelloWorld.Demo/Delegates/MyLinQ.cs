using Spg.HelloWorld.Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Delegates
{
    public delegate TOut MyFunc<out TOut>();
    public delegate TOut MyFunc<in TIn1, out TOut>(TIn1 param1);
    public delegate TOut MyFunc<in TIn1, in TIn2, out TOut>(TIn1 param1, TIn2 param2);
    public delegate TOut MyFunc<in TIn1, in TIn2, in TIn3, out TOut>(TIn1 param1, TIn2 param2, TIn3 param3);
    // bis 15

    public delegate void MyAction();
    public delegate void MyAction<in TIn1>(TIn1 param1);
}
