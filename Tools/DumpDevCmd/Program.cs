using System;
using System.Linq;
using System.Reflection;

var asm = Assembly.LoadFrom(@"C:\Users\T.B\Downloads\TMS\TMS\Website\bin\Debug\net8.0\Olive.Mvc.Testing.dll");
foreach (var t in asm.GetTypes().Where(t => t.Name.EndsWith("DevCommand")))
{
    try
    {
        var inst = Activator.CreateInstance(t);
        var nameProp = t.GetProperty("Name") ?? t.GetProperty("CommandName");
        var name = nameProp?.GetValue(inst)?.ToString();
        Console.WriteLine($"{t.Name}: {name}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{t.Name}: (no paramless ctor) {ex.GetType().Name}");
    }
}
