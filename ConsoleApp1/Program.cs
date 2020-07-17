using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    { 
        static void Main(string[] args)
        {
            StreamReader sr_tr = new StreamReader("../../Тесты/Поезда.txt");

            List<Train> trains = new List<Train>();        

            Cashier ob = new Cashier();
            ob.initial();
            Account ac = new Account();
            Passenger pas = new Passenger();


     //test test test


            Console.WriteLine("Пассажир");

            Console.WriteLine("Введите имя");
             pas.name = Console.ReadLine();



             
             Console.WriteLine("Kонечная станция/Tочное время/Число месяца");
             string inform;
             inform = Console.ReadLine();

             string[] informs = inform.Split(new char[] { '/' });
             int bol = 0;

            Request re = new Request(informs[0], informs[1], informs[2]);

            

             for (int i = 0; i < ob.trains.Count(); i++)
             {                
                 for (int j = 1; j < ob.trains[i].stations.Count(); j++)//поиск станций
                 {
                     if (re.station == Convert.ToString(ob.trains[i].stations[j]))
                     {
                         for (int z = 0; z < j; z++)//проверка на даты
                         {
                             if ((Convert.ToInt32(re.date) >= Convert.ToInt32(ob.trains[i].dates[z])))
                            
                                 {
                                     Console.WriteLine("уважаемый " + pas.name + " по вашему запросу доступны поезда: " + ob.trains[i].number + " " + ob.trains[i].station);
                                     bol++;
                                 }
                             
                         }

                     }
                 }
             }

             
             if (bol == 0)
             {
                 Console.WriteLine("неккоректный/неправильный ввод данных");
             }
             else
             {
                 Console.WriteLine("введите номер поезда который хотите выбрать");
                 ac.number = Convert.ToInt32(Console.ReadLine());
                 for (int i = 0; i < ob.trains.Count(); i++)
                 {
                     if (ac.number == ob.trains[i].number)
                     {
                         ac.price = ob.trains[i].price;
                         ac.station = re.station;
                         ac.time = re.time;
                         ac.date = re.date;
                         ac.name = pas.name;
                     }
                 }
             }

            ac.Cost();

            Console.WriteLine("Кассир");

            Console.WriteLine("Введите номер поезда/Cтанции (через пробел)/Время на станциях (через пробел)/Даты на станциях/Цену");
            inform = Console.ReadLine();

            ob.Adding(inform.Split(new char[] { '/' }));

            ob.destruct();
            

        }

        class Train
        {
            public int number;
            public string station;
            public string time;
            public string date;
            public int price;
            public string[] stations;
            public string[] times;
            public string[] dates;


            public Train(int number, string station, string time, string date, int price)
            {
                this.number = number;
                this.station = station;
                this.time = time;
                this.date = date;
                this.price = price; 
            
                stations = station.Split(' ');
                times = time.Split(' ');
                dates = date.Split(' ');
            }

        }

        class Passenger
        {
            public string name;
            public Passenger() 
            {

            }
            public Passenger(string name)
            {
                this.name = name;
            }
           
        }

        class Account
        {
            public string name;
            public int number;
            public string station;
            public string time;
            public string date;
            public int price;
            public Account()
            {

            }
            public Account(string name, int number, string station, string time, string date, int price)
            {
                this.name = name;
                this.number = number;
                this.station = station;
                this.time = time;
                this.date = date;
                this.price = price;
            }

            public void Cost()
            {
                Console.WriteLine("Name: " + name + "\n"
                    + "Train number: " + number + "; End station: " + station + "\n"
                    + "Date: " + date + "day of the month; Time: " + time + "\n"
                    + "Cost: " + price);
            }

            public void Cost(int price)
            {
                Console.WriteLine("Cost: " + price);
            }
        }

        class Cashier
        {
            public StreamReader sr_tr = new StreamReader("../../Тесты/Поезда.txt");

            public List<Train> trains = new List<Train>();

            public void initial()
            {
                for (string l = sr_tr.ReadLine(); !sr_tr.EndOfStream; l = sr_tr.ReadLine())
                {
                    Train a = new Train(Convert.ToInt32(l), sr_tr.ReadLine(), sr_tr.ReadLine(), sr_tr.ReadLine(), Convert.ToInt32(sr_tr.ReadLine()));
                    trains.Add(a);
                }

                sr_tr.Close();
            }


            public void Adding(string[] informss)
            {
                Train a = new Train(Convert.ToInt32(informss[0]), informss[1], informss[2], informss[3], Convert.ToInt32(informss[4]));
                trains.Add(a);
            }

            public void destruct()
            {
                StreamWriter sw_tr = new StreamWriter("../../Тесты/Поезда1.txt");

                for (int i = 0; i < trains.Count(); i++)
                {
                    sw_tr.WriteLine(trains[i].number);
                    sw_tr.WriteLine(trains[i].station);
                    sw_tr.WriteLine(trains[i].time);
                    sw_tr.WriteLine(trains[i].date);
                    sw_tr.WriteLine(trains[i].price);
                }

                sw_tr.Close();
            }

        }

        class Request
        {
            public string station;
            public string time;
            public string date;
            public Request(string station, string time, string date)
            {
                this.station = station;
                this.time = time;
                this.date = date;
            }
           
        }

       
    }
}
