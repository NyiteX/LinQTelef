using System.Collections.Generic;

Kniga K = new();

char vvod;
do
{
    Console.Clear();
    Console.WriteLine("1.Добавление\n2.Изменение\n3.Поиск\n4.Sort\n5.Вывод на экран всей базы");
    Console.WriteLine("Esc - Выход\n");
    vvod = Console.ReadKey().KeyChar;
    switch (vvod)
    {
        case '1':
            Console.Clear();
            K.Add();
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();
            break;
        case '2':
            if (K.GetCount() > 0)
            {
                char vvod2;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1.Изменить имя\n2.Добавить телеф\n");
                    Console.WriteLine("Esc - Выход\n");
                    vvod2 = Console.ReadKey().KeyChar;
                    switch (vvod2)
                    {
                        case '1':
                            Console.Clear();
                            Console.Write("Имя абонента: ");
                            string? str2 = Console.ReadLine();
                            K.EditName(str2);
                            Console.WriteLine("Press any key to continue.\n");
                            Console.ReadKey();
                            break;
                        case '2':
                            Console.Clear();
                            Console.Write("Имя абонента: ");
                            string? str = Console.ReadLine();
                            K.AddTelef(str);
                            Console.WriteLine("Press any key to continue.\n");
                            Console.ReadKey();
                            break;
                    }
                } while (vvod2 != 27);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Список пуст.");
                Console.WriteLine("Press any key to continue.\n");
                Console.ReadKey();
            }
            break;
        case '3':
            if (K.GetCount() > 0)
            {
                char vvod2;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1.Поиск по имени\n2.Поиск по номеру\n3.Поиск по фамилии\n");
                    Console.WriteLine("Esc - Выход\n");
                    vvod2 = Console.ReadKey().KeyChar;
                    switch (vvod2)
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine("name: ");
                            string? str = Console.ReadLine();
                            K.PrintAll(K.SortByName(str));
                            Console.WriteLine("Press any key to continue.\n");
                            Console.ReadKey();
                            break;
                        case '2':
                            Console.Clear();
                            Console.WriteLine("telef: ");
                            string? str2 = Console.ReadLine();
                            K.PrintAll(K.SortByTelef(str2));
                            Console.WriteLine("Press any key to continue.\n");
                            Console.ReadKey();
                            break;
                        case '3':
                            Console.Clear();
                            Console.WriteLine("secondname: ");
                            string? str3 = Console.ReadLine();
                            K.PrintAll(K.SortBySecondName(str3));
                            Console.WriteLine("Press any key to continue.\n");
                            Console.ReadKey();
                            break;
                    }
                } while (vvod2 != 27);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Список пуст.");
                Console.WriteLine("Press any key to continue.\n");
                Console.ReadKey();
            }
            break;
        case '4':
            if (K.GetCount() > 0)
            {
                char vvod2;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1.Sort по первой букве\n2.Sort по слогану\n");
                    Console.WriteLine("Esc - Выход\n");
                    vvod2 = Console.ReadKey().KeyChar;
                    switch (vvod2)
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine("Буква: ");
                            string? str = Console.ReadLine();
                            K.PrintAll(K.SortByFirst(str[0]));
                            Console.WriteLine("Press any key to continue.\n");
                            Console.ReadKey();
                            break;
                        case '2':
                            Console.Clear();
                            Console.WriteLine("Slogan: ");
                            string? str2 = Console.ReadLine();
                            K.PrintAll(K.SortBySlogan(str2));
                            Console.WriteLine("Press any key to continue.\n");
                            Console.ReadKey();
                            break;
                    }
                } while (vvod2 != 27);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Список пуст.");
                Console.WriteLine("Press any key to continue.\n");
                Console.ReadKey();
            }
            break;
        case '5':
            Console.Clear();
            K.PrintAll(K.Sort());
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();
            break;
    }
} while (vvod != 27);

class Kniga
{
    List<Person> people = new List<Person>();

    public void Add()
    {
        string? name, secondname;
        Console.Write("Имя: ");
        name = Console.ReadLine();
        Console.Write("Фамилия: ");
        secondname = Console.ReadLine();
        Console.Write("Телефон: ");
        List<string>? telef = new();
        try
        {
            telef.Add(Console.ReadLine());
            people.Add(new(name, secondname, telef));
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    public void AddTelef(string name)
    {
        foreach (var p in people)
        {
            if (p.Name.ToUpper() == name.ToUpper())
            {
                Console.Write("telef: ");
                string? telef = Console.ReadLine();
                p.telef.Add(telef);
                break;
            }
        }
    }
    void Print(Person p)
    {
        Console.Write("Имя: " + p.Name + "\t Фамилия: " + p.secondname + "\nТелефон: ");
        foreach (var p2 in p.telef)
            Console.Write(p2 + " ");
        Console.WriteLine('\n');
    }
    public IOrderedEnumerable<Person> Sort()
    {
        var sortedPeople1 = from p in people
                            orderby p.Name
                            select p;
        return sortedPeople1;
    }
    public int GetCount() { return people.Count; }
    public IOrderedEnumerable<Person> SortByFirst(char ch)
    {
        ch = Char.ToUpper(ch);
        var sortedPeople1 = from p in people
                            where p.Name.ToUpper()[0] == ch
                            orderby p.Name
                            select p;
        return sortedPeople1;
    }
    public IOrderedEnumerable<Person> SortByName(string str)
    {
        str = str.ToUpper();
        var sortedPeople1 = from p in people
                            where p.Name.ToUpper() == str
                            orderby p.Name
                            select p;
        return sortedPeople1;
    }
    public IOrderedEnumerable<Person> SortBySecondName(string str)
    {
        str = str.ToUpper();
        var sortedPeople1 = from p in people
                            where p.secondname.ToUpper() == str
                            orderby p.Name
                            select p;
        return sortedPeople1;
    }
    public IOrderedEnumerable<Person> SortByTelef(string str)
    {
        var sortedPeople1 = from p in people
                            where p.telef.Contains(str)
                            orderby p.Name
                            select p;
        return sortedPeople1;
    }
    public IOrderedEnumerable<Person> SortBySlogan(string str)
    {
        str = str.ToUpper();
        var sortedPeople1 = from p in people
                            where p.Name.ToUpper().Contains(str)
                            orderby p.Name
                            select p;
        return sortedPeople1;
    }
    public void PrintAll(IOrderedEnumerable<Person> sortedpeople)
    {
        foreach (var p in sortedpeople)
            Print(p);
    }
    public void EditName(string name)
    {
        Console.Write("Новое имя абонента: ");
        string? str = Console.ReadLine();

        for (int i = 0; i < people.Count; i++)
            if (people[i].Name.ToUpper() == name.ToUpper())
            {
                Person tmp = new(str, people[i].secondname, people[i].telef);
                people[i] = tmp;
                break;
            }
    }
}

record class Person(string? Name, string? secondname, List<string?> telef);