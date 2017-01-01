using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("\nHello Customer, welcome to our humble garage. \n");
            UIManager newUIManager = new UIManager();
            newUIManager.StartService();
            Console.ReadLine();
        }
    }
}