using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reminder_practice4
{
    public class Reminder //Это класс, который создает саму заметку
    {
        public string Name = "";
        public string About = "";
        public DateTime DateDone = new DateTime();

        public Reminder(string Name, string About, DateTime DateDone)
        { 
            this.Name = Name;
            this.About = About;
            this.DateDone = DateDone;

            //Благодаря конструктору я могу передавать в класс Reminder сторонние переменные
            //Которые, в свою очередь, присваиваются к выделенным ячейкам в памяти
        }
    }
}
