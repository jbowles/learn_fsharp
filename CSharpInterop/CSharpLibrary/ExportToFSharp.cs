using System;
using System.Collections.Generic;
namespace CSharpLibrary
{
    public class ExportToFsharp
    {
        public float SomeNumber { get; set; }
        public List<string> NotesInTheScale()
        {
            return new List<string>
            {"do","re","mi"};
        }
        public string UseDelegate
           (
               Func<int, string> d,
               int arg
           )
        {
            string s = d(arg);
            return $"The delegate returned {s}";
        }
    }
    public interface IExportToFsharp
    {
        string SayHello();
        string SayGoodbye();
    }
}