using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            // Departments List
            Dictionary<Department, int> Departments = new Dictionary<Department, int>();

            // Doctors List
            List<Doctors> DocList = new List<Doctors>();

            // Creating Const Departments
            Department Urology = new Department("Urology");
            Departments.Add(Urology, 1);
            Department Cardiology = new Department("Cardiology");
            Departments.Add(Cardiology, 2);
            Department Microbiology = new Department("Microbiology");
            Departments.Add(Microbiology, 3);

            // Department Create Function
            void CreateDept()
            {
                Console.WriteLine("Please, enter the name of Department: ");
                string Name = Console.ReadLine();
                Department a = new Department(Name);
                Departments.Add(a, (Departments.Count + 1));
            }

            //foreach (KeyValuePair<string, Department> item in Departments)
            //{
            //    Console.WriteLine(item.Key);
            //}

            // Doctor Create Function
            void AddDoctor()
            {
                Console.WriteLine("Please, enter doctor's Fullname: ");
                string Fullname = Console.ReadLine();
                Console.WriteLine("-------------------------------------");

                Console.WriteLine("Please, enter doctor's Department: ");
                string Dept = Console.ReadLine();
                Console.WriteLine("-------------------------------------");

                Console.WriteLine("Please, enter doctor's Shift: ");
                string Shift = Console.ReadLine();
                Console.WriteLine("=======================================================");

                Doctors a = new Doctors(Fullname, Shift);
                string d = Dept;
                Department dname = new Department("Temp");
                foreach (KeyValuePair<Department, int> item in Departments)
                {
                    if(Dept == item.Key.Name)
                    {
                        a.Dept = item.Key;
                        item.Key.Docs.Add(a);
                        DocList.Add(a);
                        Console.WriteLine("Doctor successfully added!");
                        Console.WriteLine(a.Fullname + " - " + a.Dept.Name + " - " + a.Shift);
                    }
                    else
                    {
                        Console.WriteLine("There is no such Department. If you want to add it, please, choose 'Add New Department' in the main menu.");
                        break;
                    }
                }
            }

            // Creating Const Doctors
            Doctors dct1 = new Doctors("Hasan Aghayev", "10.00 - 14.00");
            dct1.Dept = Cardiology;
            Doctors dct2 = new Doctors("Rafig Babayev", "14.00 - 18.00");
            dct2.Dept = Cardiology;
            Cardiology.Docs.Add(dct1);
            Cardiology.Docs.Add(dct2);
            DocList.Add(dct1);
            DocList.Add(dct2);

            Doctors dct3 = new Doctors("Fuad Babayev", "11.00 - 18.00");
            dct3.Dept = Urology;
            Doctors dct4 = new Doctors("Khalid Farzaliyev", "10.00 - 11.00; 15.00 - 20.00");
            dct4.Dept = Urology;
            Urology.Docs.Add(dct3);
            Urology.Docs.Add(dct4);
            DocList.Add(dct3);
            DocList.Add(dct4);

            Doctors dct5 = new Doctors("Najaf Guliyev", "10.00 - 15.00");
            dct5.Dept = Microbiology;
            Doctors dct6 = new Doctors("Fariz Akjundov", "18.00 - 01.00");
            dct6.Dept = Microbiology;
            Microbiology.Docs.Add(dct5);
            Microbiology.Docs.Add(dct6);
            DocList.Add(dct5);
            DocList.Add(dct6);


            // Menu
            string select = "";
            do
            {
                Console.WriteLine("GRAND MEDICAL HOSPITAL");
                Console.WriteLine("=========================================");
                Console.WriteLine("DEPARTMENTS");
                Console.WriteLine("-----------------------------------------");
                foreach (KeyValuePair<Department, int> item in Departments)
                {
                    Console.WriteLine(item.Value + ". " + item.Key.Name);
                }
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine((Departments.Count + 1) + ". Doctors List");
                Console.WriteLine((Departments.Count + 2) + ". Add New Department");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("0. Exit");

                select = Console.ReadLine();
                int result = 0;
                while(!Int32.TryParse(select, out result))
                {
                    Console.WriteLine("Invalid input! Try again!");
                    select = Console.ReadLine();
                }

                foreach (KeyValuePair<Department, int> item in Departments)
                {
                    if(result == item.Value)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Department: " + item.Key.Name);
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Doctors and Shifts:");
                        Console.WriteLine("=========================================");
                        foreach (Doctors doc in item.Key.Docs)
                        {
                            Console.WriteLine((item.Key.Docs.IndexOf(doc) + 1) + ": " + doc.Fullname);
                            Console.WriteLine("Working time: " + doc.Shift);
                            Console.WriteLine("\n");
                        }
                    }
                }

                if (result == Departments.Count + 1)
                {
                    foreach (Doctors dct in DocList)
                    {
                        Console.WriteLine("");
                        Console.WriteLine((DocList.IndexOf(dct) + 1) + ". " + dct.Fullname);
                        Console.WriteLine("Department: " + dct.Dept.Name);
                        Console.WriteLine("Working time: " + dct.Shift);
                        Console.WriteLine("\n");
                    }
                    Console.WriteLine("Enter N to add a Doctor.");
                    if(Console.ReadLine() == "n")
                    {
                        AddDoctor();
                    }
                }

                if(result == Departments.Count + 2)
                {
                    CreateDept();
                }

            } while (select != "0");

        }
    }
}
