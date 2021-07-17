using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_Task
{
    class Worker
    {
        public int id { get; set; }
        private string fio, eic, chief;
        private int rate;

        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }
        public string Eic
        {
            get { return eic; }
            set { eic = value; }
        }
        public string Chief
        {
            get { return chief; }
            set { chief = value; }
        }
        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public Worker() { }

        public Worker(string fio, string eic, string chief, int rate)
        {
            Fio = fio;
            Eic = eic;
            Chief = chief;
            Rate = rate;
        }
    }
}
