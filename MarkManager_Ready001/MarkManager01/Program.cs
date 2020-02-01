using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkManager01
{
    class Program
    {
        static void Main(string[] args)
        {
            MarkManagerLogin login = new MarkManagerLogin(); //makes login form1(markmanagerlogin) run from start
            System.Windows.Forms.Application.Run(login);
        }
    }
}
