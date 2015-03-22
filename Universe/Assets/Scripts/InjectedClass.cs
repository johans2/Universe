using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InjectedClass : IInjectedClass
{
    private string testString;

    public InjectedClass() 
    {
        this.testString = "This is injected!";
    }

    public string TheString 
    {
        get { return this.testString; }
    }
}

