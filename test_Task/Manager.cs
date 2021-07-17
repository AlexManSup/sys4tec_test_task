using System;
using System.Data;

namespace test_Task
{
    class Manager : Worker
    {

        public Manager() { }
        public Manager(string fio, string eic, string chief, int rate)
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
                double additional = Rate * exp * 0.05 >= Rate * 0.4 ? Rate * 0.4 : Rate * exp * 0.05;
                double subordsInc = subInc(date);
                inc = Rate + additional + subordsInc * 0.005;
                return inc;
            }
            else return 0;
        }
        //Получение зп починенных
        private double subInc(DateTime date)
        {
            double result = 0;
            string id = $"M{this.id}";
            Queries q = new Queries();
            DataTable subords = q.getSubords(Fio, "Managers");
            for (int i = 0; i < subords.Rows.Count; i++)
            {
                switch (subords.Rows[i]["Role"].ToString())
                {
                    case "Работник":
                        {

                            string fio = subords.Rows[i]["Fio"].ToString();
                            string eic = subords.Rows[i]["Eic"].ToString();
                            string chief = subords.Rows[i]["chief"].ToString();
                            int rate = Convert.ToInt32(subords.Rows[i]["Rate"].ToString());
                            Employee tempEmp = new Employee(fio, eic, chief, rate);
                            if (chief == id)
                            {
                                result += tempEmp.incomeOnDate(date);
                            }
                            break;
                        }
                    case "Менеджер":
                        {
                            string fio = subords.Rows[i]["Fio"].ToString();
                            string eic = subords.Rows[i]["Eic"].ToString();
                            string chief = subords.Rows[i]["chief"].ToString();
                            int rate = Convert.ToInt32(subords.Rows[i]["Rate"].ToString());
                            Manager tempMan = new Manager(fio, eic, chief, rate);
                            if (chief == id)
                            {
                                result += tempMan.incomeOnDate(date);
                            }
                            break;
                        }
                    case "Продавец":
                        {
                            string fio = subords.Rows[i]["Fio"].ToString();
                            string eic = subords.Rows[i]["Eic"].ToString();
                            string chief = subords.Rows[i]["chief"].ToString();
                            int rate = Convert.ToInt32(subords.Rows[i]["Rate"].ToString());
                            Salesman tempSal = new Salesman(fio, eic, chief, rate);
                            if (chief == id)
                            {
                                result += tempSal.incomeOnDate(date);
                            }
                            break;
                        }
                }
            }
            return result;
        }
    }
}
