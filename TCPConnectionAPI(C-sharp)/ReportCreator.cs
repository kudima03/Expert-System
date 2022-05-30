using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPConnectionAPI_C_sharp_
{
    static public class ReportCreator
    {
        static private void PrintHeader(ref string header)
        {
            header += "Дилер";
            header += new string(' ', 20);
            header += "Модель";
            header += new string(' ', 19);
            header += "Цвет";
            header += new string(' ', 21);
            header += "Рег. номер";
            header += new string(' ', 15);
            header += "Общая оценка";
            header += new string(' ', 13) + '\n';
        }
        
        public static string CreateReportAboutVehicles()
        {
            using (IDataViewPermision db = new DatabaseContext())
            {
                var vehicles = db.FindVehiclesWhere(c => c != null);
                string str = ("Отчет состояния автомобилей  на " + DateTime.Now.ToString() + '\n');
                PrintHeader(ref str);
                foreach (var item in vehicles)
                {
                    str += item.Dealer + new string(' ', 25 - item.Dealer.Length);
                    str += item.Model + new string(' ', 25 - item.Model.Length);
                    str += item.Colour + new string(' ', 25 - item.Colour.Length);
                    str += item.RegistrationNumber.ToString() + new string(' ', 25 - item.RegistrationNumber.Length);
                    str += item.TotalRate.ToString() + new string(' ', 25 - item.TotalRate.ToString().Length) + '\n';
                }
                return str;
            }
        }
    }
}
