using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }
    }
    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<User> users2 = new List<User> {
                new User{Name = "Tom",Age = 24, Languages = new List<string>{"Английский", "Французкий"}},
                new User{Name = "Bob",Age = 34, Languages = new List<string>{"Английский", "Французкий"}},
                new User{Name = "Jon",Age = 48, Languages = new List<string>{"Английский", "Испанский"}},
                new User{Name = "Bob",Age = 14, Languages = new List<string>{ "Французкий", "Польский"}}
            };
            List<Phone> phones = new List<Phone>
            {
                new Phone{ Name = "Lumia 630", Company="Microsoft"},
                new Phone{ Name="iPhone 6", Company="Apple"}
            };

            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };


            int[] numbers = { 1, 2, 4, 5, 6, 65, 76, 23, 46, 68, 244 };
            string[] teams = { "Бавария","Борусия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона"};

            Console.WriteLine("----------Основы LINQ-----------");
            MethodeLinQ(teams);
            Console.WriteLine("----------Фильтрация-----------");
            MethodeLinQ2(numbers);
            Console.WriteLine("----------Выборка сложных обьектов-----------");
            MethodeLinQ3(users2);
            Console.WriteLine("----------Выборка из нескольких источников-----------");
            MethodeLinQ4(users2);
            Console.WriteLine("----------Сортировка-----------");
            MethodeLinQ5(users2, phones);
            Console.WriteLine("----------Разность множеств-----------");
            MethodeLinQ7(soft, hard);
            Console.WriteLine("----------Пересечение множеств-----------");
            MethodeLinQ8(soft, hard);
            Console.WriteLine("----------Обьединение множеств-----------");
            MethodeLinQ9(soft, hard);
            Console.WriteLine("----------Удаление дубликатов-----------");
            MethodeLinQ10(soft, hard);

        }
        //Основы LINQ
        private static void MethodeLinQ(string[] teams)
        {
            var selectedTeams = from team in teams //опредиляем каждый обьект из teams как team
                                where team.StartsWith("Б")//фильтрация по определенным критериям
                                orderby team //сортируем по возростанию
                                select team; //Выбираем обьект
            foreach (string team in selectedTeams)
            {
                Console.WriteLine(team);
            }
        }
        //Фильтрация
        private static void MethodeLinQ2(int[] numbers)
        {
            IEnumerable<int> results = from i in numbers
                                       where i % 2 == 0 && i > 10
                                       select i;
            foreach (int number in results)
            {
                Console.WriteLine(numbers);
            }

            Console.WriteLine("---------------------");
            IEnumerable<int> results2 = numbers.Where(team => team % 2 == 0 && team > 10);
            foreach (int team in results2)
            {
                Console.WriteLine(team);
            }
        }
        //Выборка сложных обьектов
        private static void MethodeLinQ3(List<User> users)
        {
            var selectedUsers = from user in users
                                where user.Age > 25
                                select user;
            foreach (var user in selectedUsers)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine("---------------------");

            var selectedUsereWithEnglish = from user in users
                                           from lang in user.Languages
                                           where user.Age > 25
                                           where lang == "Английский"
                                           select user;
            foreach (var user in selectedUsereWithEnglish)
            {
                Console.WriteLine(user.Name);
            }

        }
        //Проекция
        private static void MethodeLinQ4(List<User> users2)
        {
            
            foreach (var user in from user in users2 select user.Name)
            {
                Console.WriteLine(user);
            }

            var items = from user in users2
                        select new
                        {
                            FirstName = user.Name,
                            UserAge = user.Age
                        };
            foreach (var item in items)
            {
                Console.WriteLine(item.FirstName+" "+item.UserAge);
            }

            //Выборка имен с помощью методов расширения
            foreach (var item in users2.Select(user => user.Name))
            {
                Console.WriteLine(item);
            }

            //Выборка обьектов ананимного типа, методов расширения
            var items2 = users2.Select(user => new {
                FirstName = user.Name,
                UserAge = user.Age
            });
        }
        //Выборка из нескольких источников
        private static void MethodeLinQ5(List<User> users2, List<Phone> phones)
        {
            var people = from user in users2
                         from phone in phones
                         select new {
                             Name = user.Name, 
                             Phone = phone.Name
                         };
            foreach (var item in people)
            {
                Console.WriteLine(item.Name+ " "+item.Phone );
            }
        }
        //Сортировка
        private static void MethodeLinQ6(List<User> users2)
        {
            var result = from user in users2
                         orderby user.Name, user.Age
                         select user;
            foreach (var item in result)
            {
                Console.WriteLine(item.Age+"...");
            }

            Console.WriteLine("---------------------");

            var result2 = users2.OrderBy(user => user.Name).ThenBy(user => user.Age);
            foreach (var item in result2)
            {
                Console.WriteLine(item.Name+" "+item.Age);
            }
        }
        //Работа с множествами 
        //Разность множеств
        private static void MethodeLinQ7(string[] soft, string[] hard)
        {
            foreach (var item in soft.Except(hard))
            {
                Console.WriteLine(item);
            } 
        }
        //Пересечение множеств
        private static void MethodeLinQ8(string[] soft, string[] hard)
        {
            foreach (var item in soft.Intersect(hard))
            {
                Console.WriteLine(item);
            }
        }
        //Обьединение множеств
        private static void MethodeLinQ9(string[] soft, string[] hard)
        {
            foreach (var item in soft.Union(hard))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------");

            foreach (var item in soft.Concat(hard))
            {
                Console.WriteLine(item);
            }
        }
        //Удаление дубликатов
        private static void MethodeLinQ10(string[] soft, string[] hard)
        {
            foreach (var item in soft.Concat(hard).Distinct())
            {
                Console.WriteLine(item);
            }
        }




    }



}
