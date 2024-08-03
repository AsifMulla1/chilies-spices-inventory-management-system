using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red_cillies.Reports;

namespace Red_cillies
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new Form2());
            //Application.Run(new MDI());
            // Application.Run(new Customer());
            // Application.Run(new Supplier());
            //Application.Run(new Purchase());
            // Application.Run(new CustBill());
            //Application.Run(new Date_Wise_Bill());
        }
    }
}
