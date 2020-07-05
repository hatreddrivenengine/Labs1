using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;


namespace Labs1_phoneBook
{

    public class Book
    {
        public static List<Page> phoneBook = new List<Page>();
        class Program
        {
            static void Main(string[] args)
            {
                string key = "";
                Console.WriteLine("****************************************************");
                Console.WriteLine("************************Телефонная книга версия 0.1*");
                CreatePage();

                Console.WriteLine("****************************************************");
                Console.Write("Чем ещё займёмся? /help = помощь ");
                key = Console.ReadLine();
                while (key != "/exit" && key != "/q")
                {
                    if (key == "/help") { Help(); }
                    else if (key == "/create") { CreatePage(); }
                    else if (key == "/showall") { ShowAll(); }
                    else if (key == "/showbook") { ShowBook(); }
                    else if (key == "/show") { ShowX(); }
                    else if (key == "/del") { Delete(); }
                    else if (key == "/upd") { Update(); }


                    Console.Write("Введите команду");
                    key = Console.ReadLine();
                }
                Console.WriteLine("******************Работа программы завершена********");
                Console.WriteLine("****************************удачки******************");

            }

        }

        public static string FirstUpper(string anyString)
        {
            if (String.IsNullOrEmpty(anyString)) return "";
            else return anyString.First().ToString().ToUpper() + anyString.Substring(1).ToLower();
        }
        public static void CreatePage()
        {
            Console.WriteLine("Пожалуйста, заполните необходимую информацию о контакте");
            int phone = 0;
            Console.Write("Номер телефона: ");
            bool isPhoneNumeric = Int32.TryParse(Console.ReadLine(), out phone);
            while (phoneBook.Any(x => x.PhoneNum == phone))
            {
                Console.WriteLine("Такой номер уже существует. Введите новый телефон или отредактируйте существующую запись ()");

                isPhoneNumeric = Int32.TryParse(Console.ReadLine(), out phone);
            }
            while (!isPhoneNumeric || phone.ToString().Length != 9)
            {
                Console.Write("Номер должен состоять из 9 цифр, пожалуйста, повторите ввод: ");
                isPhoneNumeric = Int32.TryParse(Console.ReadLine(), out phone);
            }

            Console.Write("Имя: ");
            string name = FirstUpper(Console.ReadLine());
            while (String.IsNullOrEmpty(name))
            {
                Console.Write("Поле Имя не должно быть пустым, введите имя: ");
                name = FirstUpper(Console.ReadLine());
            }
            Console.Write("Фамилия: ");
            string surname = FirstUpper(Console.ReadLine());
            while (String.IsNullOrEmpty(surname))
            {
                Console.Write("Поле Фамилия не должно быть пустым, введите фамилию: ");
                surname = FirstUpper(Console.ReadLine());
            }

            Console.Write("Страна: ");
            string country = FirstUpper(Console.ReadLine());
            while (String.IsNullOrEmpty(country))
            {
                Console.Write("Поле Страна не должно быть пустым, введите название страны: ");
                country = FirstUpper(Console.ReadLine());
            }

            Page personInfo = new Page(name, surname, phone, country);

            Console.Write("Хотите ли вы дополнить информацию по контакту? y/n: ");
            string choice = Console.ReadLine();
            while (choice != "y" && choice != "n")
            {
                Console.Write("Ожидаемый формат ответа Yes or No. y/n: ");
                choice = Console.ReadLine();
            }
            if (choice == "y")
            {
                Console.Write("Отчество: ");
                string givenName = FirstUpper(Console.ReadLine());
                Console.Write("Место работы: ");
                string company = Console.ReadLine();
                Console.Write("Должность: ");
                string position = Console.ReadLine();
                Console.Write("Доп инфа: ");
                string addInfo = Console.ReadLine();

                DateTime birthDate;
                Console.Write("Дата рождения: ");
                bool isDateAccurate = DateTime.TryParse(Console.ReadLine(), out birthDate);
                while (!isDateAccurate)
                {
                    Console.Write("Формат даты должен соответствовать ДД/ММ/ГГГГ или ДД.ММ.ГГГГ: ");
                    isDateAccurate = DateTime.TryParse(Console.ReadLine(), out birthDate);
                }
                personInfo.Company = company;
                personInfo.Position = position;
                personInfo.AddInfo = addInfo;
                personInfo.Birthdate = birthDate;
                personInfo.GivenName = givenName;
                Console.WriteLine("Пользователь внесён в вашу записную книгу!");
            }
            else if (choice == "n") { Console.WriteLine("Пользователь внесён в вашу записную книгу!"); }
            phoneBook.Add(personInfo);
            Console.WriteLine("***************************************************************");

        }
        public static void Help()
        {
            Console.WriteLine("Список доступных команд: \n/help - помощь \n/create - создать новую запись \n/showall - вывести весь список \n/show - вывести конкретную запись \n/del - удалить запись \n/update x - редактировать запись с id x \n/delete x - удалить запись с id x \n/find name - поиск в справочинике по имени \n/findN xxx - поиск в справочнике по телефону \n/exit - завершить работу со справочиником");
        }
        public static void ShowAll()
        {
            Console.WriteLine("***список будет здесь****");
            foreach (var item in phoneBook)
            {
                Console.WriteLine(item);
            }
        }
        public static void ShowBook()
        {
            foreach (var item in phoneBook)
            {
                Console.WriteLine($"ID {item.Id} *** tel No: {item.PhoneNum} *** ФИО: {item.Surname} {item.Name} {item.GivenName} ");
                Console.WriteLine("*****************************************************************************");
            }
        }
        public static void ShowX()
        {
            //Console.WriteLine($"***вывод будет здесь****");
            ShowBook();
            int id;
            Console.Write("Выберите ID (0 для отмены): ");
            bool isPhoneNumeric = Int32.TryParse(Console.ReadLine(), out id);
            if (id == 0) return;
            while (!isPhoneNumeric)
            {
                Console.Write("id должен состоять из цифр, пожалуйста, повторите ввод: ");
                isPhoneNumeric = Int32.TryParse(Console.ReadLine(), out id);
                
            }
            try
            {
                Console.WriteLine(phoneBook.First(x => x.Id == id));
            }
            catch (Exception)
            {
                Console.WriteLine("некорректное значение, введите существующий id");
                ShowX();
            }
            

        }
        public static void Delete()
        {
            ShowBook();
            int id;
            Console.Write("Выберите ID удаляемой записи (0 для отмены): ");
            bool isPhoneNumeric = Int32.TryParse(Console.ReadLine(), out id);
            if (id == 0) return;
            while (!isPhoneNumeric) 
            {
                Console.Write("id должен состоять из цифр, пожалуйста, повторите ввод: ");
                isPhoneNumeric = Int32.TryParse(Console.ReadLine(), out id);

            }
            try
            {
                phoneBook.Remove(phoneBook.First(x => x.Id == id));
                Console.WriteLine($"Запись с id {id} успешно удалена");
                ShowBook();
            }
            catch (Exception)
            {
                Console.WriteLine("некорректное значение, введите существующий id");
                Delete();
            }
        }
        public static void Update()
        {
            ShowBook();
            int id;
            string key;
            int phone;
            DateTime birthDate;
            //string change;

            Console.Write("Выберите ID изменяемой записи (0 для отмены): ");
            bool isNumeric = Int32.TryParse(Console.ReadLine(), out id);
            if (id == 0) return;
            while (!isNumeric)
            {
                Console.Write("id должен состоять из цифр, пожалуйста, повторите ввод: ");
                isNumeric = Int32.TryParse(Console.ReadLine(), out id);
            }
            try
            {
                Console.WriteLine(phoneBook.First(x => x.Id == id));
                var obj = phoneBook.First(x => x.Id == id);
                Console.WriteLine("***************************************************************");
                Console.WriteLine("редактировать поле: \nИмя: /name \n Фамилия: /sur \nОтчество: /giv \nТелефон: /tel \nСтрана: /cnt \nМесто работы: /cmp \nДолжность: /pos \nДоп. информация: /add \nЗакончить редактирование: 0");
                key = Console.ReadLine();
                while (key != "0") 
                {
                    if (key == "/name") 
                    {
                        Console.Write("Введитие имя: ");
                        obj.Name = FirstUpper(Console.ReadLine());
                        Console.WriteLine("Закончить редактирование: 0\nРедактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/sur") 
                    {
                        Console.Write("Введитие фамилию: ");
                        obj.Surname = FirstUpper(Console.ReadLine());
                        Console.WriteLine("Редактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/giv") 
                    {
                        Console.Write("Введитие отчество: ");
                        obj.GivenName = FirstUpper(Console.ReadLine());
                        Console.WriteLine("Закончить редактирование: 0\nРедактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/tel")
                    {
                        Console.Write("Введитие Телефон: ");
                        isNumeric = Int32.TryParse(Console.ReadLine(), out phone);
                        while (!isNumeric || phone.ToString().Length != 9)
                        {
                            Console.Write("Номер должен состоять из 9 цифр, пожалуйста, повторите ввод: ");
                            isNumeric = Int32.TryParse(Console.ReadLine(), out phone);
                        }
                        obj.PhoneNum = phone;
                        Console.WriteLine("Закончить редактирование: 0\nРедактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/cnt") 
                    {
                        Console.Write("Введитие страну: ");
                        obj.Country = FirstUpper(Console.ReadLine());
                        Console.WriteLine("Редактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/cmp") 
                    {
                        Console.Write("Введитие место работы: ");
                        obj.Company = FirstUpper(Console.ReadLine());
                        Console.WriteLine("Закончить редактирование: 0\nРедактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/pos") 
                    {
                        Console.Write("Введитие должность: ");
                        obj.Position = FirstUpper(Console.ReadLine());
                        Console.WriteLine("Закончить редактирование: 0\nРедактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/add") 
                    {
                        Console.Write("Введитие дополнительную инфомрацию: ");
                        obj.AddInfo = FirstUpper(Console.ReadLine());
                        Console.WriteLine("Закончить редактирование: 0\nРедактировать далее: ");
                        key = Console.ReadLine();
                    }
                    else if (key == "/bd")
                    {
                        Console.Write("Введитие дату рождения (формат ДД/ММ/ГГГГ или ДД.ММ.ГГГГ): ");
                        bool isDateAccurate = DateTime.TryParse(Console.ReadLine(), out birthDate);
                        while (!isDateAccurate)
                        {
                            Console.Write("Формат даты должен соответствовать ДД/ММ/ГГГГ или ДД.ММ.ГГГГ: ");
                            isDateAccurate = DateTime.TryParse(Console.ReadLine(), out birthDate);
                        }
                        obj.Birthdate = birthDate;
                        Console.WriteLine("Закончить редактирование: 0\nРедактировать далее: ");
                        key = Console.ReadLine();
                    }

                }
                Console.WriteLine(phoneBook.First(x => x.Id == id));
                Console.WriteLine($"Запись с id {id} успешно изменена");
                ShowBook();
            }
            catch (Exception)
            {
                Console.WriteLine("некорректное значение, введите существующий id");
                Update();
            }
        }


    }
}
