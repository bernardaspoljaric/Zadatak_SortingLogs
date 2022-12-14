using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs
{
    class Program
    {
        public static void Main(string[] args)
        {
            string textFile = @"C:\Users\Windows10\OneDrive\Desktop\Zadatak\log20201104.txt";
            string[] logs;

            if (File.Exists(textFile))
            {
                logs = File.ReadAllLines(textFile);
            }
            else
            {
                Console.WriteLine("Cannot find text file.");
                return;
            }

            ChooseCategory(logs);

        }

        public static void ChooseCategory(string[] logs)
        {
            Console.WriteLine("Choose sorting category: \n 1) Date\n 2) Type\n 3) M-files vault\n 4) Modul\n 5) Date and Type\n 6) Date and M-files vault\n 7) Date and Modul\n 8) Date, Type and M-flies vault\n 9) Date, Type and Modul\n 10) Date, M-files and Modul\n 11) Cernain Date, Type, M-files and Modul");
            Console.WriteLine("Type a number of category: ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    ChooseDateSorting(logs);
                    break;
                case "2":
                    ChooseTypeSorting(logs);
                    break;
                case "3":
                    ChooseMfilesVaultSorting(logs);
                    break;
                case "4":
                    ChooseModulSorting(logs);
                    break;
                case "5":
                    ChooseDateAndTypeSorting(logs);
                    break;
                case "6":
                    ChooseDateAndMfilesSorting(logs);
                    break;
                case "7":
                    ChooseDateAndModulSorting(logs);
                    break;
                case "8":
                    ChooseDateTypeMfilesSorting(logs);
                    break;
                case "9":
                    ChooseDateTypeModulSorting(logs);
                    break;
                case "10":
                    ChooseDateMfilesModulSorting(logs);
                    break;
                case "11":
                    ChooseCertainDateTypeMfilesModulSorting(logs);
                    break;
            }
        }

        public static void ChooseDateSorting(string[] logs)
        {
            string dateSorting = GetDateSorting();

            switch (dateSorting)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortByYear(logs);
                    break;
                case "2":
                    SortByMonth(logs);
                    break;
                case "3":
                    SortByDay(logs);
                    break;
                case "4":
                    SortByHour(logs);
                    break;
                case "5":
                    SortByBetweenHours(logs);
                    break;
            }
        }

        public static string GetDateSorting()
        {
            Console.WriteLine("Choose date sorting category: \n 1) Year\n 2) Month\n 3) Day\n 4) Hour\n 5) Between hours");
            Console.WriteLine($"Type a number of category: ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static void CheckSortingResults(List<string> results, string errorMsg)
        {
            if (results.Any())
            {
                foreach (string log in results)
                {
                    Console.WriteLine(log);
                }
            }
            else
            {
                Console.WriteLine(errorMsg);
            }
        }

        public static void SortByYear(string[] logs)
        {
            string year = GetYear();
            string errorMsg = $"There is no logs for the year {year}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
            
        }

        public static void SortByMonth(string[] logs)
        {
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs for the {month}/{year}";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortByDay(string[] logs)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs for the {day}/{month}/{year}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortByHour(string[] logs)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs for the {day}/{month}/{year} {hour}h.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortByBetweenHours(string[] logs)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs between {startingHour} and {finishingHour} for the {day}/{month}/{year}.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if(i < 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i))
                            {
                                results.Add(log);
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour.");
            }
            
            CheckSortingResults(results, errorMsg);
        }

        public static string GetYear()
        {
            Console.WriteLine("Write a year you want to sort logs by: ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static string GetMonth()
        {
            Console.WriteLine("Write a month you want to sort logs by (e.g. 01, 02, 03...): ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static string GetDay()
        {
            Console.WriteLine("Write a day you want to sort logs by (e.g. 01, 02, 03...): ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static string GetHour()
        {
            Console.WriteLine("Write an hour (00-23) you want to sort logs by (e.g. 01, 02, 03...): ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static void ChooseTypeSorting(string[] logs)
        {
            string type = GetLogType();
            type = CheckType(type);

            string errorMsg = $"There is no logs with type {type}.";

            List<string> results = new List<string>();
            foreach (string log in logs)
            {
                if (log.Substring(32, 35).Contains(type))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static string GetLogType()
        {
            Console.WriteLine("Choose sorting type category: \n 1) VRB\n 2) DBG\n 3) INF\n 4) WRN\n 5) ERR");
            Console.WriteLine("Type a number of category: ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static string CheckType(string type)
        {
            if (type == "1")
            {
                return "VRB";
            }
            else if (type == "2")
            {
                return "DBG";
            }
            else if (type == "3")
            {
                return "INF";
            }
            else if (type == "4")
            {
                return "WRN";
            }
            else if (type == "5")
            {
                return "ERR";
            }
            else
            {
                return "No valid type";
            }
        }    

        public static void ChooseMfilesVaultSorting(string[] logs)
        {
            string mfilesVault = GetMfilesVault();
            mfilesVault = CheckMfilesVault(mfilesVault);

            string errorMsg = $"There is no logs with M-files vault '{mfilesVault}'.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Contains(mfilesVault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static string GetMfilesVault()
        {
            Console.WriteLine("Choose M-files vault category: \n 1) E2C67223-862D-40D5-B85E-47D75BF7C4A3\n 2) other");
            Console.WriteLine("Type a number of category: ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static string CheckMfilesVault(string mfilesVault)
        {
            if (mfilesVault == "1")
            {
                return "E2C67223-862D-40D5-B85E-47D75BF7C4A3";
            }
            else if (mfilesVault == "2")
            {
                return "other";
            }
            else
            {
                return "No valid M-files vault";
            }

        }

        public static void ChooseModulSorting(string[] logs)
        {
            string modul = GetModul();
            modul = CheckModul(modul);

            string errorMsg = $"There is no logs with modul '{modul}'.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);             

        }

        public static string GetModul()
        {
            Console.WriteLine("Choose sorting modul category: \n 1) Extended property builder\n 2) Extended property operations\n 3) Extended e-mail notifications\n 4) HTTP integration\n 5) Extended document processing\n 6) Extended property calculations");
            Console.WriteLine("Type a number of category: ");
            string answer = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            return answer;
        }

        public static string CheckModul(string modul)
        {
            if (modul == "1")
            {
                return "Extended property builder";
            }
            else if (modul == "2")
            {
                return " Extended property operations";
            }
            else if (modul == "3")
            {
                return "Extended e-mail notifications";
            }
            else if (modul == "4")
            {
                return "HTTP integration";
            }
            else if (modul == "5")
            {
                return "Extended document processing";
            }
            else if (modul == "6")
            {
                return "Extended property calculations";
            }
            else
            {
                return "No valid modul";
            }

        }

        public static void ChooseDateAndTypeSorting(string[] logs)
        {
            string answer = GetDateSorting();

            string type = GetLogType();
            type = CheckType(type);

            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortYearAndType(logs, type);
                    break;
                case "2":
                    SortMonthAndType(logs, type);
                    break;
                case "3":
                    SortDayAndType(logs, type);
                    break;
                case "4":
                    SortHourAndType(logs, type);
                    break;
                case "5":
                    SortBetweenHoursAndType(logs, type);
                    break;
            }

        }

        public static void SortYearAndType(string[] logs, string type)
        {
            string year = GetYear();

            string errorMsg = $"There is no logs in year {year} with type {type}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year) && log.Substring(32, 35).Contains(type))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortMonthAndType(string[] logs, string type)
        {
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs in {month}/{year} with type {type}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month) && log.Substring(32, 35).Contains(type))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortDayAndType(string[] logs, string type)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with type {type}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day) && log.Substring(32, 35).Contains(type))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortHourAndType(string[] logs, string type)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs at {hour}h on {day}/{month}/{year} with type {type}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour) && log.Substring(32, 35).Contains(type))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortBetweenHoursAndType(string[] logs, string type)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} between {startingHour}h and {startingHour}h with type {type}.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if(i < 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i) && log.Substring(32, 35).Contains(type))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i) && log.Substring(32, 35).Contains(type))
                            {
                                results.Add(log);
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour!");
            }
            
            CheckSortingResults(results, errorMsg);
        }

        public static void ChooseDateAndMfilesSorting(string[] logs)
        {
            string answer = GetDateSorting();
            string mfilesVault = GetMfilesVault();
            mfilesVault = CheckMfilesVault(mfilesVault);

            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortYearAndMfiles(logs, mfilesVault);
                    break;
                case "2":
                    SortMonthAndMfiles(logs, mfilesVault);
                    break;
                case "3":
                    SortDayAndMfiles(logs, mfilesVault);
                    break;
                case "4":
                    SortHourAndMfiles(logs, mfilesVault);
                    break;
                case "5":
                    SortBetweenHoursAndMfiles(logs, mfilesVault);
                    break;
            }
        }

        public static void SortYearAndMfiles(string[] logs, string vault)
        {
            string year = GetYear();

            string errorMsg = $"There is no logs in year {year} with M-files vault '{vault}'.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year) && log.Contains(vault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortMonthAndMfiles(string[] logs, string vault)
        {
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs in {month}/{year} with M-files vault '{vault}'.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month) && log.Contains(vault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortDayAndMfiles(string[] logs, string vault)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with M-files vault '{vault}'.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day) && log.Contains(vault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortHourAndMfiles(string[] logs, string vault)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs at {hour}h on {day}/{month}/{year} with M-files vault '{vault}'.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour) && log.Contains(vault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortBetweenHoursAndMfiles(string[] logs, string vault)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} between {startingHour}h and {finishingHour}h with M-files vault '{vault}'.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if (i < 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i) && log.Contains(vault))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i) && log.Contains(vault))
                            {
                                results.Add(log);
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour!");
            }


            CheckSortingResults(results, errorMsg);

        }

        public static void ChooseDateAndModulSorting(string[] logs)
        {
            string answer = GetDateSorting();
            string modul = GetModul();
            modul = CheckModul(modul);

            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortYearAndModul(logs, modul);
                    break;
                case "2":
                    SortMonthAndModul(logs, modul);
                    break;
                case "3":
                    SortDayAndModul(logs, modul);
                    break;
                case "4":
                    SortHourAndModul(logs, modul);
                    break;
                case "5":
                    SortBetweenHoursAndModul(logs, modul);
                    break;
            }

        }

        public static void SortYearAndModul(string[] logs, string modul)
        {
            string year = GetYear();

            string errorMsg = $"There is no logs in year {year} with modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortMonthAndModul(string[] logs, string modul)
        {
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs in {month}/{year} with modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortDayAndModul(string[] logs, string modul)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortHourAndModul(string[] logs, string modul)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);

        }

        public static void SortBetweenHoursAndModul(string[] logs, string modul)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} between {startingHour}h and {finishingHour}h with modul {modul}.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if (i < 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour!");
            }
            
            CheckSortingResults(results, errorMsg);

        }

        public static void ChooseDateTypeMfilesSorting(string[] logs)
        {
            string answer = GetDateSorting();
            string type = GetLogType();
            type = CheckType(type);
            string mfilesVault = GetMfilesVault();
            mfilesVault = CheckMfilesVault(mfilesVault);

            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortYearTypeMfiles(logs, type, mfilesVault);
                    break;
                case "2":
                    SortMonthTypeMfiles(logs, type, mfilesVault);
                    break;
                case "3":
                    SortDayTypeMfiles(logs, type, mfilesVault);
                    break;
                case "4":
                    SortHourTypeMfiles(logs, type, mfilesVault);
                    break;
                case "5":
                    SortBetweenHoursTypeMfiles(logs, type, mfilesVault);
                    break;
            }
        }

        public static void SortYearTypeMfiles(string[] logs, string type, string mfilesVault)
        {
            string year = GetYear();

            string errorMsg = $"There is no logs in year {year} with type {type} and M-files vault {mfilesVault}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortMonthTypeMfiles(string[] logs, string type, string mfilesVault)
        {
            string month= GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs in {month}/{year} with type {type} and M-files vault {mfilesVault}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortDayTypeMfiles(string[] logs, string type, string mfilesVault)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with type {type} and M-files vault {mfilesVault}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortHourTypeMfiles(string[] logs, string type, string mfilesVault)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs at {hour}h on {day}/{month}/{year} with type {type} and M-files vault {mfilesVault}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortBetweenHoursTypeMfiles(string[] logs, string type, string mfilesVault)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} between {startingHour}h and {finishingHour}h with type {type} and M-files vault {mfilesVault}.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if (i< 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault))
                            {
                                results.Add(log);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour!");
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void ChooseDateTypeModulSorting(string[] logs)
        {
            string answer = GetDateSorting();
            string type = GetLogType();
            type = CheckType(type);
            string modul = GetModul();
            modul = CheckModul(modul);

            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortYearTypeModul(logs, type, modul);
                    break;
                case "2":
                    SortMonthTypeModul(logs, type, modul);
                    break;
                case "3":
                    SortDayTypeModul(logs, type, modul);
                    break;
                case "4":
                    SortHourTypeModul(logs, type, modul);
                    break;
                case "5":
                    SortBetweenHoursTypeModul(logs, type, modul);
                    break;
            }
        }

        public static void SortYearTypeModul(string[] logs, string type, string modul)
        {
            string year = GetYear();

            string errorMsg = $"There is no logs in year {year} with type {type} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year) && log.Substring(32, 35).Contains(type) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortMonthTypeModul(string[] logs, string type, string modul)
        {
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs in {month}/{year} with type {type} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month) && log.Substring(32, 35).Contains(type) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortDayTypeModul(string[] logs, string type, string modul)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with type {type} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day) && log.Substring(32, 35).Contains(type) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortHourTypeModul(string[] logs, string type, string modul)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs at {hour}h on {day}/{month}/{year} with type {type} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour) && log.Substring(32, 35).Contains(type) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortBetweenHoursTypeModul(string[] logs, string type, string modul)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} between {startingHour}h and {finishingHour}h with type {type} and modul {modul}.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if (i < 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i) && log.Substring(32, 35).Contains(type) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i) && log.Substring(32, 35).Contains(type) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour!");
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void ChooseDateMfilesModulSorting(string[] logs)
        {
            string answer = GetDateSorting();
            string mfilesVault = GetMfilesVault();
            mfilesVault = CheckMfilesVault(mfilesVault);
            string modul = GetModul();
            modul = CheckModul(modul);

            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortYearMfilesModul(logs, mfilesVault, modul);
                    break;
                case "2":
                    SortMonthMfilesModul(logs, mfilesVault, modul);
                    break;
                case "3":
                    SortDayMfilesModul(logs, mfilesVault, modul);
                    break;
                case "4":
                    SortHourMfilesModul(logs, mfilesVault, modul);
                    break;
                case "5":
                    SortBetweenHoursMfilesModul(logs, mfilesVault, modul);
                    break;
            }
        }

        public static void SortYearMfilesModul(string[] logs, string mfilesVault, string modul)
        {
            string year = GetYear();

            string errorMsg = $"There is no logs in year {year} with M-files vault {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortMonthMfilesModul(string[] logs, string mfilesVault, string modul)
        {
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs in {month}/{year} with M-files vault {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortDayMfilesModul(string[] logs, string mfilesVault, string modul)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with M-files vault {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortHourMfilesModul(string[] logs, string mfilesVault, string modul)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs at {hour}h on {day}/{month}/{year} with M-files {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortBetweenHoursMfilesModul(string[] logs, string mfilesVault, string modul)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} between {startingHour}h and {finishingHour}h with M-files {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if (i < 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i) && log.Contains(mfilesVault) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i) && log.Contains(mfilesVault) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour!");
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void ChooseCertainDateTypeMfilesModulSorting(string[] logs)
        {
            string answer = GetDateSorting();
            string type = GetLogType();
            type = CheckType(type);
            string mfilesVault = GetMfilesVault();
            mfilesVault = CheckMfilesVault(mfilesVault);
            string modul = GetModul();
            modul = CheckModul(modul);

            switch (answer)
            {
                default:
                    Console.WriteLine("Not valid category!");
                    break;
                case "1":
                    SortYearTypeMfilesModul(logs, type, mfilesVault, modul);
                    break;
                case "2":
                    SortMonthTypeMfilesModul(logs, type, mfilesVault, modul);
                    break;
                case "3":
                    SortDayTypeMfilesModul(logs, type, mfilesVault, modul);
                    break;
                case "4":
                    SortHourTypeMfilesModul(logs, type, mfilesVault, modul);
                    break;
                case "5":
                    SortBetweenHoursTypeMfilesModul(logs, type, mfilesVault, modul);
                    break;
            }
        }

        public static void SortYearTypeMfilesModul(string[] logs, string type, string mfilesVault, string modul)
        {
            string year = GetYear();

            string errorMsg = $"There is no logs in year {year} with type {type}, M-files vault {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 4).Contains(year) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortMonthTypeMfilesModul(string[] logs, string type, string mfilesVault, string modul)
        {
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs in {month}/{year} with type {type}, M-files vault {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 7).Contains(year + "-" + month) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortDayTypeMfilesModul(string[] logs, string type, string mfilesVault, string modul)
        {
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} with type {type}, M-files vault {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 10).Contains(year + "-" + month + "-" + day) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortHourTypeMfilesModul(string[] logs, string type, string mfilesVault, string modul)
        {
            string hour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs at {hour}h on {day}/{month}/{year} with type {type}, M-files {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            foreach (string log in logs)
            {
                if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + hour) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault) && log.Contains(modul))
                {
                    results.Add(log);
                }
            }

            CheckSortingResults(results, errorMsg);
        }

        public static void SortBetweenHoursTypeMfilesModul(string[] logs, string type, string mfilesVault, string modul)
        {
            string startingHour = GetHour();
            string finishingHour = GetHour();
            string day = GetDay();
            string month = GetMonth();
            string year = GetYear();

            string errorMsg = $"There is no logs on {day}/{month}/{year} between {startingHour}h and {finishingHour}h with type {type}, M-files {mfilesVault} and modul {modul}.";

            List<string> results = new List<string>();

            if (Int16.Parse(startingHour) < Int16.Parse(finishingHour))
            {
                foreach (string log in logs)
                {
                    for (int i = Int16.Parse(startingHour); i < Int16.Parse(finishingHour); i++)
                    {
                        if (i < 10)
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " 0" + i) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }
                        else
                        {
                            if (log.Substring(0, 13).Contains(year + "-" + month + "-" + day + " " + i) && log.Substring(32, 35).Contains(type) && log.Contains(mfilesVault) && log.Contains(modul))
                            {
                                results.Add(log);
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Starting hour has to be smaller than finishing hour!");
            }

            CheckSortingResults(results, errorMsg);
        }
    }
}
