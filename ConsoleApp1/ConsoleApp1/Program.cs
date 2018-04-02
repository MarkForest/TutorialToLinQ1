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
    class Player
    {
        public string Name { get; set; }
        public string  Team { get; set; }
    }

    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Team> teams2 = new List<Team> {
                new Team{ Name = "Бавария", Country= "Германия"},
                new Team{ Name = "Барселона", Country= "Испания"}
            };
            List<Player> players = new List<Player>
            {
                new Player{Name = "Месси", Team="Барселона"},
                new Player{Name = "Неймар", Team="Барселона"},
                new Player{Name = "Роббен", Team="Бавария"},
            };
            
            List<User> users2 = new List<User> {
                new User{Name = "Tom",Age = 24, Languages = new List<string>{"Английский", "Французкий"}},
                new User{Name = "Bob",Age = 34, Languages = new List<string>{"Английский", "Французкий"}},
                new User{Name = "Jon",Age = 48, Languages = new List<string>{"Английский", "Испанский"}},
                new User{Name = "Bob",Age = 14, Languages = new List<string>{ "Французкий", "Польский"}}
            };
            List<Phone> phones = new List<Phone>
            {
                new Phone{ Name = "Lumia 630", Company="Microsoft"},
                new Phone{Name = "Mi 5", Company="Xiaomi"},
                new Phone{ Name="iPhone 6", Company="Apple"},
                new Phone{ Name="LG G 3", Company="LG"},
                new Phone{ Name="iPhone 5", Company="Apple"},
                new Phone{ Name="Lumia 930", Company="Microsoft"},
                new Phone{ Name="LG G 4", Company="LG"},
                new Phone{ Name="Lumia 430", Company="Microsoft"},
                new Phone{ Name="Prime 5", Company="Alcatele"},
                new Phone{ Name="Prime 5s", Company="Alcatele"},
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
            Console.WriteLine("----------Агрегатные операции-----------");
            Console.WriteLine("----------Метод Agrgregate-----------");
            MethodeLinQ11(numbers);
            Console.WriteLine("----------Получение размера выборки. Метод Count-----------");
            MethodeLinQ12(numbers);
            Console.WriteLine("----------Получение суммы-----------");
            MethodeLinQ13(numbers, users2);
            Console.WriteLine("----------Максимальные, минимальные, Среднее значение-----------");
            MethodeLinQ14(numbers, users2);
            Console.WriteLine("----------Методы Take-----------");
            MethodeLinQ15(numbers);
            Console.WriteLine("----------Методы Skip-----------");
            MethodeLinQ16(numbers);
            Console.WriteLine("----------Методы Take & Skip-----------");
            MethodeLinQ17(numbers);
            Console.WriteLine("----------Методы TakeWhile-----------");
            MethodeLinQ18(teams);
            Console.WriteLine("----------Методы SkipWhile-----------");
            MethodeLinQ19(teams);
            Console.WriteLine("----------Групировка-----------");
            MethodeLinQ20(phones);
            Console.WriteLine("----------Групировка Count-----------");
            MethodeLinQ21(phones);
            Console.WriteLine("----------Coeдинение Join, Zip-----------");
            MethodeLinQ22(teams2, players);
            Console.WriteLine("----------All Any-----------");
            MethodeLinQ23(users2);
            Console.WriteLine("----------Немедленные запросы-----------");
            MethodeLinQ24(teams);

        }

       









        //Основы LINQ
        private static void MethodeLinQ(string[] teams)
        {
            var selectedTeams = (from team in teams //опредиляем каждый обьект из teams как team
                                where team.StartsWith("Б")//фильтрация по определенным критериям
                                orderby team //сортируем по возростанию
                                select team); //Выбираем обьект
            foreach (string team in selectedTeams)
            {
                Console.WriteLine(team);
            }
        }
        //Фильтрация
        private static void MethodeLinQ2(int[] numbers)
        {
            var results = from i in numbers
                                       where i % 2 == 0 && i > 10
                                       select i;
            foreach (var number in results)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("---------------------");
            var results2 = numbers.Where(num => num % 2 == 0 && num > 10);
            foreach (var team in results2)
            {
                Console.WriteLine(team.ToString());
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
        //Метод Agrgregate
        private static void MethodeLinQ11(int[] numbers)
        {
            int query = numbers.Aggregate((itemOne, itemTwo) => itemOne - itemTwo); //1-2-4-5-6...
            Console.WriteLine(query);
        }
        //Получение размера выборки.Метод Count
        private static void MethodeLinQ12(int[] numbers)
        {
            int size = (from i in numbers where i % 2 == 0 select i).Count();
            Console.WriteLine(size);

            int size2 = numbers.Count(i => i % 2 == 0);
            Console.WriteLine(size2);
        }
        //Получение суммы
        private static void MethodeLinQ13(int[] numbers, List<User> users2)
        {
            int sum1 = numbers.Sum();
            var sum2 = users2.Sum(user => user.Age);
            Console.WriteLine($"sum numbers={sum1}, sum users ={sum2}");
        }
        //Максимальные, минимальные, Среднее значение
        private static void MethodeLinQ14(int[] numbers, List<User> users2)
        {
            int min1 = numbers.Min();
            int min1_2 = users2.Min(u => u.Age);

            int min2 = numbers.Max();
            int min2_2 = users2.Max(u => u.Age);

            double min3 = numbers.Average();
            double min3_2 = users2.Average(u => u.Age);

            Console.WriteLine();
        }
        //Методы Take
        private static void MethodeLinQ15(int[] numbers)
        {
            foreach (var item in numbers.Take(3))
            {
                Console.WriteLine(item);
            }

        }
        //Методы Skip
        private static void MethodeLinQ16(int[] numbers)
        {
            foreach (var item in numbers.Skip(3))
            {
                Console.WriteLine(item);
            }
        }
        //Методы Take & Skip
        private static void MethodeLinQ17(int[] numbers)
        {
            foreach (var item in numbers.Skip(4).Take(3))
            {
                Console.WriteLine(item);
            }
        }
        //Методы TakeWhile
        private static void MethodeLinQ18(string[] teams)
        {
            foreach (var item in teams.TakeWhile(t => t.StartsWith("Б")))
            {
                Console.WriteLine(item);
            }
        }
        //Методы SkipWhile
        private static void MethodeLinQ19(string[] teams)
        {
            foreach (var item in teams.SkipWhile(t => t.StartsWith("Б")))
            {
                Console.WriteLine(item);
            }
        }
        //Групировка
        private static void MethodeLinQ20(List<Phone> phones)
        {
            //var phoneGroups = from phone in phones group phone by phone.Company;
            var phoneGroups = phones.GroupBy(p => p.Company);

            foreach (IGrouping<string, Phone> item in phoneGroups)
            {
                Console.WriteLine(item.Key);

                foreach (var i in item)
                {
                    Console.WriteLine(i.Name);
                }
                Console.WriteLine();
            }


        }
        //Групировка Count
        private static void MethodeLinQ21(List<Phone> phones)
        {
            var groupGroup1 = from phone in phones
                              group phone by phone.Company into igrouping
                              select new { Name = igrouping.Key, Count = igrouping.Count() };
            foreach (var group in groupGroup1)
            {
                Console.WriteLine($"{group.Name}: {group.Count}");
            }
            var groupGroup2 = phones.GroupBy(p => p.Company)
                .Select(igrouping => new { Name = igrouping.Key, Count = igrouping.Count()});
            foreach (var group in groupGroup2)
            {
                Console.WriteLine($"{group.Name}: {group.Count}");
            }
        }
        //Coeдинение Join, Zip
        private static void MethodeLinQ22(List<Team> teams2, List<Player> players)
        {
            var result = from p1 in players
                         join t in teams2 on p1.Team equals t.Name
                         select new { Name = p1.Name, Team = p1.Team, t.Country };
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Team} {item.Country}");
            }

            var result2 = players.Join(
                    teams2, //second collection
                    p => p.Team, //property from first collection
                    t => t.Name, //property from second collection
                    (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country } //Result
                );
            foreach (var item in result2)
            {
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            }

            Console.WriteLine("ZIP");
            var result3 = players.Zip(
                teams2,
                (p, t) => new
                {
                    Name = p.Name,
                    Team = t.Name,
                    Country = t.Country
                }
                );
            foreach (var item in result3)
            {
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            }
        }
        //All Any
        private static void MethodeLinQ23(List<User> users2)
        {
            bool result = users2.All(u => u.Age>13); //true
            Console.WriteLine(result);

            //any
            bool result2 = users2.Any(u => u.Age < 14);
            Console.WriteLine(result2);
        }
        //Немедленные запросы
        private static void MethodeLinQ24(string[] teams)
        {
            var count = (from t in teams where t.StartsWith("Б") orderby t select t).Count();
            Console.WriteLine(count); //2
           // teams[1] = "Ювентус";
            Console.WriteLine(count); //2

            var count2 = from t in teams
                        where t.StartsWith("Б")
                        orderby t
                        select t;
            Console.WriteLine(count2.Count()); //2
            //teams[1] = "Ювентус";
            Console.WriteLine(count2.Count()); //1

            var selectedTeams = (from t in teams
                                 where t.StartsWith("Б")
                                 orderby t
                                 select t).ToList<string>();
            teams[1] = "Ювентус";
            foreach (var item in selectedTeams)
            {
                Console.WriteLine(item);
            }
        }
    }

}
