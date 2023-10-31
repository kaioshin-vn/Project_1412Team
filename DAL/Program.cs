using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        static void WriteToScreen()
        { // hàm không có tham số
            Console.WriteLine("Ham khong co tham so");
            Console.WriteLine( "Check" );
        }

        static void Main()
        {
            WriteToScreen();

            Console.ReadKey(); // dừng màn hình
        }
    }
}