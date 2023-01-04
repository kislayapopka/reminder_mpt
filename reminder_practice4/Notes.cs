using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reminder_practice4
{
    public class Notes //Это класс, создающий дату со списком заметок
    {
        public Notes(DateTime date) //Создание конструктора DateTime
        {
            this.Date = date; //Передает классу Notes переменную с типом данных DateTime
        } //Класса Notes, в свою очередь присваивает значение переменной к переменной Date

        public DateTime Date = new DateTime(); //Выделяю ячейку памяти для переменной
        public List<Reminder> ListNotes = new List<Reminder>(); //Выделяю в памяти место для списка с классом Reminder

        public void AddNew(Reminder reminder) //Создание метода AddNew, который принимает
        { //значения типа данных Reminder и позволяет добавлять новый эллемент к списку
            ListNotes.Add(reminder);
        }
    }
}
