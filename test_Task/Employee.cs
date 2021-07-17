using System;

namespace test_Task
{
    class Employee : Worker
    {

        public Employee() { }

        public Employee (string fio, string eic, string chief, int rate)
        {
            Fio = fio;
            Eic = eic;
            Chief = chief;
            Rate = rate;
        }
        //Метод расчета зп
        public double incomeOnDate(DateTime date)
        {
            double inc;
            DateTime eic = DateTime.Parse(Eic);
            int exp = (int)(date.Subtract(eic).TotalDays / 365);
            if (exp >= 0)
            {
                double additional = Rate * exp * 0.03 >= Rate * 0.3 ? Rate * 0.3 : Rate * exp * 0.03;
                inc = Rate + additional;
                return inc;
            }
            else return 0;
        }
    }
}
