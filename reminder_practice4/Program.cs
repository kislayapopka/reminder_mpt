using reminder_practice4;

ConsoleKeyInfo key;
int NotesCounter = 0;
int position = 0;
bool start = true;

DateTime datenow = DateTime.Today;

Notes todaynotes = new Notes(datenow); //Объявление списка заметок с датой
Reminder firstnote = new Reminder("ЗАМЕТКА 1", "ВЛАДИК ПОМОГИ", datenow); //Объявление элемента (заметки)
Reminder secondnote = new Reminder("ЗАМЕТКА 2", "Я НИЧЕГО НЕ ПОНИМАЮ", datenow); //Объявление элемента (заметки)
todaynotes.AddNew(firstnote); //Добавление в список первой заметки
todaynotes.AddNew(secondnote); //Добавление в список второй заметки

Notes previousnotes = new Notes(datenow); //Объявление списка заметок с датой
Reminder firstnote2 = new Reminder("ЗАМЕТКА 3", "НЕ ЛЮБЛЮ СИ ШАРП", datenow);
Reminder secondnote2 = new Reminder("ЗАМЕТКА 4", "ЭТО ПРАКТА СУЩИЙ АД", datenow);
previousnotes.AddNew(firstnote2); //Добавление в список заметок первой заметки
previousnotes.AddNew(secondnote2); //Добавление в список заметок вторую заметку

Notes nextnotes = new Notes(datenow); //Объявление списка заметок с датой
Reminder firstnote3 = new Reminder("ЗАМЕТКА 5", "СПАСИБО ЗА ПЕРЕСДАЧУ", datenow); //Объявление элемента (заметки)
Reminder secondnote3 = new Reminder("ЗАМЕТКА 6", "МНЕ ЕЩЕ ДЕЛАТЬ ПЯТЬ ПРАКТОСОВ", datenow); //Объявление элемента (заметки)
nextnotes.AddNew(firstnote3); //Добавление элемента (первой заметки) в список
nextnotes.AddNew(secondnote3); //Добавление элемента (второй заметки) в список

/* ВАЖНАЯ РЕМАРКА!
ДАЛЬШЕ Я ОБЪЯВЛЯЮ СПИСОК ИЗ NOTES - ЗАМЕТОК, СОЗДАННЫХ ПРИ ПОМОЩИ КОНСТРУКТОРА В КЛАССЕ NOTES
ТО ЕСТЬ, У МЕНЯ СОЗДАНЫ ТРИ ЗАМЕТКИ - PREVIOUSNOTES, TODAYNOTES, NEXTNOTES, - КОТОРЫЕ ПРОСТО ВИСЯТ БЕЗ ДЕЛА
Я ДОЛЖЕН ИХ ПОМЕСТИТЬ В СПИСОК LIST<NOTES>, ДЛЯ ТОГО, ЧТОБЫ Я МОГ С НИМИ ВЗАИМОДЕЙСТВОВАТЬ В ДАЛЬНЕЙШЕМ
МОЖНО ПРЕДСТАВИТЬ ЭТО КАК ПИСЬМА (NOTES), КОТОРЫЕ Я ПОЛОЖИЛ В КОНВЕРТИК (LIST<NOTES>)
ПОЛУЧАЕТСЯ СПИСОК ИЗ СПИСКОВ LIST<REMINDER>, СОДЕРЖАЩИЙСЯ В КЛАССЕ NOTES
*/

List<Notes> TodayListNotes = new List<Notes>();
TodayListNotes.Add(todaynotes); //Добавление в TodayListNotes ( - это список заметок Notes ) заметку todaynotes
TodayListNotes.Add(previousnotes); //Добавление в TodayListNotes ( - это список заметок Notes ) заметку previousnotes
TodayListNotes.Add(nextnotes); //Добавление в TodayListNotes ( - это список заметок Notes ) заметку nextnotes


void VilualizeDateNotes(int NotesCounter) //Отрисовка менюшки с датой и списком заметок
{
    //Благодаря методу Count() мы можем посчитать количество элементов в списке
    //Через .ListNotes мы обращаемся к переменной в списке TodayListNotes, которую хотим посчитать
    int counter = TodayListNotes[NotesCounter].ListNotes.Count();
    //Таким же образом мы обращаемся к переменной Date в списке TodayListNotes
    //и переводим значение переменной в строковой тип данных
    Console.WriteLine($"Выбранная дата {TodayListNotes[NotesCounter].Date}");
    for (int i = 0; i < counter; i++)
    {
        //Далее я достаю название (переменная Name) из списка TodayListNotes[индекс_листа]
        Console.Write("  " + (i+1) + ". "); //Нумерация списка из названий заметок
        //Обращаюсь к списку ListNotes, который хранит в себе список с заметками, затем обращаюсь к переменной Name
        Console.WriteLine(TodayListNotes[NotesCounter].ListNotes[i].Name);

        /*
        ТО ЕСТЬ, ПРОГРАММА ВЫВОДИТ В КОНСОЛЬ НАЗВАНИЕ ЭЛЕМЕНТА ИЗ СПИСКА TODAYLISTNOTES ПОД ИНДЕКСОМ NOTESCOUNTER
        И, ОБРАЩАЯСЬ К ПАРАМЕТРУ NAME ПРИ ПОМОЩИ СПИСКА LISTNOTES, В КОТОРОМ СОДЕРЖАТСЯ ЗАМЕТКИ
        */ 
    }
}

void VisualizeNotes(int position, int NotesCounter) //Отрисовка внутренностей заметок
{
    /*
    АНАЛОГИЧНЫМ ОБРАЗОМ ОТРИСОВЫВАЕТСЯ ВНУТРЕННОСТЬ ЗАМЕТКИ - Я ОБРАЩАЮСЬ К СПИСКУ TODAYLISTNOTES,
    СОДЕРЖАЩЕМ В СЕБЕ СПИСОК ЗАМЕТОК С ВНУТРЕННОСТЯМИ LISTNOTES. ЗАТЕМ Я ДОСТАЮ ОТТУДА ИМЯ, ОПИСАНИЕ И ДАТУ
    ЗАМЕТКИ ПО ПОЗИЦИИ КУРСОРА POSITION И СЧЕТЧИКА NOTESCOUNTER
     */ 
    Console.Clear();
    Console.WriteLine(TodayListNotes[NotesCounter].ListNotes[position - 1].Name);
    Console.WriteLine(TodayListNotes[NotesCounter].ListNotes[position - 1].About);
    Console.WriteLine(TodayListNotes[NotesCounter].ListNotes[position - 1].DateDone);
}

while (start == true)
{
    Control(Console.ReadKey());
}

void Control(ConsoleKeyInfo key)
{
    switch (key.Key)
    { 
        case ConsoleKey.UpArrow:

            if (position == 1) //Если курсор находится в самой верхней позиции, то программа
            { }                //не будет считывать нажатие клавиш
            else
            {
                position--;
                Console.Clear();
                VilualizeDateNotes(NotesCounter);
                Console.SetCursorPosition(0, position);
                Console.WriteLine(">");
            }
            break;

        case ConsoleKey.DownArrow:
            if (position == todaynotes.ListNotes.Count()) //Если курсор находится в нижней позиции
            { }                                           //то ничего не будет происходить
            else
            { 
                position++;
                Console.Clear();
                VilualizeDateNotes(NotesCounter);
                Console.SetCursorPosition(0, position);
                Console.WriteLine(">");
            }
            break;

        case ConsoleKey.LeftArrow:
            if (NotesCounter == 0)
            { }
            else
            {
                NotesCounter--;
                Console.Clear();
                VilualizeDateNotes(NotesCounter);
            }
            break;

        case ConsoleKey.RightArrow:
            if (NotesCounter == TodayListNotes.Count() - 1)
            { }
            else
            {
                NotesCounter++;
                Console.Clear();
                VilualizeDateNotes(NotesCounter);
            }
            break;

        case ConsoleKey.Enter:
            VisualizeNotes(position, NotesCounter);
            break;

        case ConsoleKey.Backspace:
            Console.Clear();
            VilualizeDateNotes(NotesCounter);
            break;

        case ConsoleKey.Escape:
            start = false;
        break;

            default: break;
    }
}