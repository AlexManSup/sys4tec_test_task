using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_Task
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static IncomeForm incomeForm;
        public static Auth auth;
        public static MainForm mainForm;
        public static AddWorker addWorker;
        public static MenuForm menuForm;
        public static Subordinates subordinates;
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(auth = new Auth());
            //Application.Run(incomeForm = new IncomeForm("admin"));
            
            //Application.Run(mainForm = new MainForm());
        }
    }
}
