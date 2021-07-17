using System;
using System.Data;

namespace test_Task
{
    class Salesman: Worker
    {

        public Salesman() { }
        public Salesman(string fio, string eic, string chief, int rate)
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
                double additional = Rate * exp * 0.01 >= Rate * 0.35 ? Rate * 0.35 : Rate * exp * 0.01;
                double subordsInc = subInc(date);
                inc = Rate + additional + subordsInc * 0.003;
                return inc;
            }
            else return 0;
        }
        //Получение зп починенных
        private double subInc(DateTime date)
        {
            double result = 0;
            Queries q = new Queries();
            DataTable subords = q.getSubords(Fio, "Salesmen");
            for (int i = 0; i < subords.Rows.Count; i++)
            {
                switch (subords.Rows[i]["Role"].ToString())
                {
                    case "Работник":
                        {
                            string fio = subords.Rows[i]["Fio"].ToString();
                            string eic = subords.Rows[i]["Eic"].ToString();
                            string chief = subords.Rows[i]["Chief"].ToString();
                            int rate = Convert.ToInt32(subords.Rows[i]["Rate"].ToString());
                            result += new Employee(fio, eic, chief, rate).incomeOnDate(date);
                            break;
                        }
                    case "Менеджер":
                        {
                            string fio = subords.Rows[i]["Fio"].ToString();
                            string eic = subords.Rows[i]["Eic"].ToString();
                            string chief = subords.Rows[i]["Chief"].ToString();
                            int rate = Convert.ToInt32(subords.Rows[i]["Rate"].ToString());
                            result += new Manager(fio, eic, chief, rate).incomeOnDate(date);
                            break;
                        }
                    case "Продавец":
                        {
                            string fio = subords.Rows[i]["Fio"].ToString();
                            string eic = subords.Rows[i]["Eic"].ToString();
                            string chief = subords.Rows[i]["Chief"].ToString();
                            int rate = Convert.ToInt32(subords.Rows[i]["Rate"].ToString());
                            result += new Salesman(fio, eic, chief, rate).incomeOnDate(date);
                            break;
                        }
                }
            }
            return result;
        }
    }
}
