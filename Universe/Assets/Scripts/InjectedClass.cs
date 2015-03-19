using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InjectedClass : IInjectedClass
{
    public string TheString 
    {
        get { return "This is injected!"; }
    }
}

