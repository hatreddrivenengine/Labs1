using System;
using System.Collections.Generic;
using System.Text;

namespace Labs1_phoneBook
{
    public class Page
    {
        public int Id { get; private set; }
        public static int Count { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public int PhoneNum { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string AddInfo { get; set; }
        public DateTime Birthdate { get; set; }
        /* public Page(string name, string surname, string givenName, int phoneNum, string country, string company, string position, string addInfo, DateTime birthDate)
         {
             // обязательные
             Id ++;
             this.Name = name;
             this.Surname = surname;
             this.PhoneNum = phoneNum;
             this.Country = country;
             // необязательные
             this.GivenName = givenName;
             this.Company = company;
             this.Position = position;
             this.AddInfo = addInfo;
             this.Birthdate = birthDate;
         } */
        public Page(string name, string surname, int phoneNum, string country)
        {
            this.Id = Count + 1;
            Count++;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNum = phoneNum;
            this.Country = country;
        }

        public override string ToString()
        {
            return $"ID {this.Id} \nИмя: {this.Name} \nФамилия: {this.Surname} \nОтчество: {this.GivenName} \nНомер: {this.PhoneNum} \nСтрана: {this.Country} \nМесто работы: {this.Company} \nДоп инфо: {this.AddInfo} \nДР: {this.Birthdate}";
        }
    }
}
