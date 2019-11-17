using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
    interface IView
    {
        string pytanie { get; set; }
        string odp1 { get; set; }
        string odp2 { get; set; }
        string odp3 { get; set; }
        string odp4 { get; set; }

        decimal num1 { get; set; }
        decimal num2 { get; set; }
        decimal num3 { get; set; }
        decimal num4 { get; set; }
       
        decimal time { get; set; }

        string list { get; set; }

        string nazwa { set; }

        string sciezka { get; set; }

        event Action Add;
        event Action Exit;
        event Action PathEdit;
    }
}
