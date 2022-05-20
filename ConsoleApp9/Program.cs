using ConsoleApp9;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace MyApp
{

    public class Program
    {

        static void Main(string[] args)
        {
            string format = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}  {NewLine}";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: format, theme: AnsiConsoleTheme.Code)
                .WriteTo.File("myLog.txt", outputTemplate: format)
                .CreateLogger();


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@$"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@&& &@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&& &@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@########@@@@@@&&@@@@@@@&&&&&@@@@@@@@@@&####B#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@##BBB###B#@@@@#B#@@@@&#BBBBBBB&@@@@@@&#BBB##B#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@&#B@&B#BB#@@&BBB&@@@#BBBB#BBBB@@@@@@#BBB#@#B#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@BBBBB &@&BBBG@@&BBBB &@&&#&@@@@@&BBBB&@#BB@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@BBBB#&#BBBB#&#BBB#@@@@@@@@@@@#BBBB@@#B#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@BBBBBBBBBBBB#BBBG#@@@&&&&&@@@BBBB#@&BG&@@@&&&&@@@@@@@&&&&&@@@@@@&&&&&&&&@@&&&&@@@@@@@@@&&#&&@@
@@@@@#BBBBBBBBBBBBBBGB&@&#BBBBB#B@BBBGB&BG#@@##BBGG#B&@@&#BBBBBBB&@@&BBBBBB##BBBBBBB#@@@@@&##BBB#B@@
@@@@&BGGBBGB#BBBBBGG#@&BBBBB&#BBBGBGGPGGB&&#BBBB#GBBB@&BBB##B##BBB@&BBBB#&##BBB###BB#@@@#BBBB#&BB#@@
@@@@BGGGGG#@#BGGGGB&@BGBBBG#BGB&BGGGG##&@&BBBBB&@&#&&BBBB#@#B&#BB@&BBBBB@&BBBB&&BBBB@@&BBBBG#BGB&@@@
@@@BGGGPG &@&GGGPG#@@BGBBBGPGB&@#GGGP#@@@#BBBGG@@@@@&BBBGB@@BBBBG&&GBBGB@&BBBG&@#BBB@@&BBBBGPGB&@&BGB
@@#P55P#@@@G55P#@@@@GBGGPP&@@#GPPPP5&@&B5GGGPG@@@&BGGGGGB&#BGGGPGGGGGB@&BGGG&@#GGGB&BGGGGGG#&@&BGGG&
@B55P#@@@&PY5B@@@@@@#GP555PP555PG55Y55YY5GG555PP555PGPPP555PGBGGPPP5B@#G55P&@@#PPP55PB#GPP5PPP55PB@@
BPG &@@@@@PP#@@@@@@@@@&#BGPPPGB&@&BGPPPG#@@#BGPPPGB#&#BPPPG#&@@@#BGG#@@BGGB&@@@@&BBB&@@@&#BGGGB#&@@@@".Replace("@", " "));


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("Click any key for continue, E-for exit");
            Console.WriteLine();

            Console.ResetColor();
            string[] workingHours = { "9:00-11:00", "12:00-14:00", "15:00-17:00" };
            var patientList = new List<Patient>();

            List<Doctor> traumatologists = new()
            {
                new Doctor("Ceyhun", "Aliyev", 10, "Traumatology", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" }),
                new Doctor("Lala", "Muradova", 4, "Traumatology", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" }),
                new Doctor("Aydin", "Muxtarov", 18, "Traumatology", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" }),
                new Doctor("Sevinj", "Naghiyeva", 9, "Traumatology", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" })

            };

            List<Doctor> dentists = new()
            {
                new Doctor("Hasan", "Abbasov", 15, "Dentistry", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" }),
                new Doctor("Gunel", "Abdulla", 13, "Dentistry", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" })
            };

            List<Doctor> pediatricDoctors = new()
            {
                new Doctor("Ali", "Asgarli", 20, "Pediatrics", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" }),
                new Doctor("Murad", "Hasanov", 7, "Pediatrics", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" }),
                new Doctor("Aygul", "Nadjafova", 12, "Pediatrics", workingHours, new string[3] { "UnReserved", "UnReserved", "UnReserved" })
            };


            void ShowPediatricDoctors()
            {
                foreach (var doctor in pediatricDoctors)
                {
                    Console.WriteLine(doctor);
                }
            }
            void ShowDentists()
            {
                foreach (var doctor in dentists)
                {
                    Console.WriteLine(doctor);
                }
            }
            void ShowTraumatologists()
            {
                foreach (var doctor in traumatologists)
                {
                    Console.WriteLine(doctor);
                }
            }


            bool isChecked;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            while (Console.ReadKey().Key != ConsoleKey.E)
            {
                Console.Clear();
                string name, surname, email = "", phoneNumber = "";
                Console.WriteLine("Enter your Name: ");
                name = Console.ReadLine();

                Console.WriteLine("Enter your Surname: ");
                surname = Console.ReadLine();
                bool emailCheck = true;
                while (emailCheck)
                {
                    Console.WriteLine("Enter your Email: ");
                    email = Console.ReadLine();
                    Regex r = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (!r.IsMatch(email))
                    {

                        Log.Warning("Wrong email format");
                        continue;
                    }
                    emailCheck = false;

                }
                bool phoneCheck = true;


                while (phoneCheck)
                {
                    Console.WriteLine("Enter your Phone Number: ");
                    phoneNumber = Console.ReadLine();
                    Regex r = new(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
                    if (!r.IsMatch(phoneNumber))
                    {

                        Log.Warning("Wrong phone number format");
                        continue;
                    }
                    phoneCheck = false;

                }
                isChecked = true;
                Thread.Sleep(500);
                Console.Clear();
                Patient patient = new(name, surname, email, phoneNumber);

                while (isChecked)
                {
                    Console.WriteLine("Pls choose one of the branches below");
                    var menu = new Menu(new string[] { "Traumatology", "Dentistry", "Pediatrics" });
                    var menuPainter = new ConsoleMenuPainter(menu);

                    bool done = false;

                    do
                    {
                        menuPainter.Paint(8, 5);

                        var keyInfo = Console.ReadKey();

                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow: menu.MoveUp(); break;
                            case ConsoleKey.DownArrow: menu.MoveDown(); break;
                            case ConsoleKey.Enter: done = true; break;
                        }
                    }
                    while (!done);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Thread.Sleep(500);
                    Console.Clear();
                    switch (menu.SelectedOption)
                    {
                        case "Traumatology":
                            ShowTraumatologists();
                            break;
                        case "Dentistry":
                            ShowDentists();
                            break;
                        case "Pediatrics":
                            ShowPediatricDoctors();
                            break;

                        default:
                            Log.Warning("Wrong input");
                            continue;
                    }

                    while (isChecked)
                    {
                        Console.Write("Pls enter the name the doctor you want to have appointment: ");
                        string? doctorName = Console.ReadLine();
                        Console.Write("Pls enter the surname the doctor you want to have appointment: ");
                        string? doctorSurname = Console.ReadLine();

                        if (menu.SelectedOption == "Traumatology")
                        {
                            bool isFound = false;

                            foreach (var doctor in traumatologists)
                            {
                                if (doctorName == doctor.Name && doctorSurname == doctor.Surname)
                                {
                                    isFound = true;
                                    while (isChecked)
                                    {
                                        Console.Write(@"Enter the hour you reserve for(for example: xx:00-xx:00): ");
                                        string? hour = Console.ReadLine();
                                        if (hour == workingHours[0])
                                        {
                                            if (doctor.ReservedHours[0] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[0]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[0] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[0];
                                                isChecked = false;
                                                break;
                                            }
                                            else
                                            {

                                                Log.Warning("This hour was taken please choose another time");
                                                continue;

                                            }

                                        }
                                        else if (hour == workingHours[1])
                                        {
                                            if (doctor.ReservedHours[1] != "Reserved")
                                            {

                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[1]} in {doctor.Name} {doctor.Surname} was reserved successfully");
                                                doctor.ReservedHours[1] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[1];
                                                isChecked = false;
                                                break;


                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");
                                                continue;

                                            }
                                        }

                                        else if (hour == workingHours[2])
                                        {
                                            if (doctor.ReservedHours[2] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[2]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[2] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[2];
                                                isChecked = false;
                                                break;

                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");

                                                continue;
                                            }

                                        }
                                        else
                                        {
                                            Log.Warning("Wrong working hour format!Please enter again");

                                            continue;
                                        }
                                    }

                                }

                            }
                            if (!isFound)
                            {

                                Log.Warning("There is no such a doctor in our clinic");
                                continue;
                            }
                            Thread.Sleep(1500);
                            Console.Clear();
                        }
                        else if (menu.SelectedOption == "Dentistry")
                        {
                            bool isFound = false;
                            foreach (var doctor in dentists)
                            {

                                if (doctorName == doctor.Name && doctorSurname == doctor.Surname)
                                {
                                    isFound = true;
                                    while (isChecked)
                                    {
                                        Console.Write(@"Enter the hour you reserve for(for example: xx:00-xx:00): ");
                                        string? hour = Console.ReadLine();
                                        if (hour == workingHours[0])
                                        {
                                            if (doctor.ReservedHours[0] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[0]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[0] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[0];
                                                isChecked = false;
                                                break;
                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");
                                                continue;
                                            }

                                        }

                                        else if (hour == workingHours[1])
                                        {
                                            if (doctor.ReservedHours[1] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[1]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[1] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[1];
                                                isChecked = false;
                                                break;


                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");
                                                continue;
                                            }
                                        }

                                        else if (hour == workingHours[2])
                                        {
                                            if (doctor.ReservedHours[2] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[2]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[2] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[2];
                                                isChecked = false;
                                                break;

                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");
                                                continue;
                                            }

                                        }
                                        else
                                        {

                                            Log.Warning("Wrong working hour format!");
                                            continue;
                                        }


                                    }

                                }


                            }
                            if (!isFound)
                            {
                                Log.Warning("There is no such a doctor in our clinic");
                                continue;
                            }
                            Thread.Sleep(500);
                            Console.Clear();
                        }

                        else if (menu.SelectedOption == "Pediatrics")
                        {
                            bool isFound = false;

                            foreach (var doctor in pediatricDoctors)
                            {
                                if (doctorName == doctor.Name && doctorSurname == doctor.Surname)
                                {
                                    isFound = true;
                                    while (isChecked)
                                    {
                                        Console.Write(@"Enter the hour you reserve for(for example: xx:00-xx:00): ");
                                        string? hour = Console.ReadLine();
                                        if (hour == workingHours[0])
                                        {
                                            if (doctor.ReservedHours[0] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[0]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[0] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[0];
                                                isChecked = false;
                                                break;
                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");

                                                continue;
                                            }

                                        }
                                        else if (hour == workingHours[1])
                                        {
                                            if (doctor.ReservedHours[1] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[1]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[1] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[1];
                                                isChecked = false;
                                                break;


                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");
                                                continue;
                                            }
                                        }

                                        else if (hour == workingHours[2])
                                        {
                                            if (doctor.ReservedHours[2] != "Reserved")
                                            {
                                                Log.Information($"{patient.Name} {patient.Surname},{DateOnly.FromDateTime(DateTime.Now)} {workingHours[2]} in {doctor.Name} {doctor.Surname} was reserved successfully");

                                                doctor.ReservedHours[2] = "Reserved";
                                                patient.Doctor = doctor;
                                                patient.ReservedTime = workingHours[2];
                                                isChecked = false;
                                                break;

                                            }
                                            else
                                            {
                                                Log.Warning("This hour was taken please choose another time");

                                                continue;
                                            }

                                        }
                                        else
                                        {
                                            Log.Warning("Wrong working hour format!");

                                            continue;
                                        }

                                    }

                                }
                            }
                            if (!isFound)
                            {

                                Log.Warning("There is no such a doctor in our clinic");

                                continue;
                            }
                            Thread.Sleep(1500);
                            Console.Clear();

                        }

                    }

                }

                void JSONSerializeMethod()
                {
                    patientList.Add(patient);
                    var jsonString = JsonConvert.SerializeObject(patientList, Newtonsoft.Json.Formatting.Indented);

                    File.WriteAllText("patientWithNewtonsoft.json", jsonString);

                }
                void JSONDeSerializeMethod()
                {
                    var stringData = File.ReadAllText("patientWithNewtonsoft.json");
                    var data = JsonConvert.DeserializeObject<List<Patient>>(stringData);

                    foreach (var patient in data)
                    {
                        Console.WriteLine($"Patient Name: {patient.Name}\nPatient Surname: {patient.Surname}\n" +
                            $"Reserved Time: {DateOnly.FromDateTime(DateTime.Now)}, {workingHours[2]}\nDoctor Name: {patient.Doctor.Name}" +
                            $"\nDoctor Surname: {patient.Doctor.Surname}\nwas reserved successfully\n");

                    }

                }
                JSONSerializeMethod();
                JSONDeSerializeMethod();
                Console.WriteLine("Click any key to continue or E- for exit");

            }


        }
    }
}


