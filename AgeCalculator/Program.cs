using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter you birth date to calculate your age");
            Console.WriteLine("Use yyyy/MM/dd or dd/MM/yyyy formats");

            var input = Console.ReadLine();
            input = input.Replace(" ", String.Empty);
            string[] inputArr = input.Split('/');
            var birthDate = "";

            if (inputArr[0].Length == 4)
            {
                try { birthDate = DateTime.ParseExact(inputArr[2] + "/" + inputArr[1] + "/" + inputArr[0], "dd/MM/yyyy", null).ToString("dd/MM/yyyy"); }
                catch { Console.WriteLine("Please enter a valid day or month value!");
                    
                };
            }
            else
            {
                try { birthDate = DateTime.ParseExact(input, "dd/MM/yyyy", null).ToString("dd/MM/yyyy"); }
                catch { Console.WriteLine("Please enter a valid day or month value!");
                  
                };
                 }

            DateTime inputDate = DateTime.Parse(birthDate);
            Console.WriteLine("Input date after conv.: " + birthDate);

            string ageCalc(DateTime userDate)
            {

                DateTime today = DateTime.Today;
                int months = today.Month - userDate.Month;
                int years = today.Year - userDate.Year;

                if(today.Day < userDate.Day)
                {
                    months--;
                }
                if (months < 0)
                {
                    years--;
                    months += 12;
                }
                int days = (today - inputDate.AddMonths((years * 12) + months)).Days;

                if(years < 0) { return string.Format( "Please enter a valid date, you are not even born yet!!"); }

                else { return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                    years, (years == 1) ? "" : "s",
                    months, (months == 1) ? "" : "s",
                    days, (days == 1) ? "" : "s"
                     ); }
                

                
            }

             Console.WriteLine(ageCalc(inputDate)); 

          
            
        }
    }
}
