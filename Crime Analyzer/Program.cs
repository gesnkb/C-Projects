using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Analyzer
{
    class Program
    {
        
            static void Main(string[] args)
            {
            int count = args.Length;
            Console.WriteLine(count);

            if (args.Length < 2)
            {
                Console.WriteLine("Please enter 2 arguments");
                System.Environment.Exit(1);
              
            }

            string dataFile = args[0];
            string finalFile = args[1];

            if(!File.Exists(dataFile))
            {
                Console.WriteLine("File does not exist, please copy a file path");
                System.Environment.Exit(2);
            }
            
            Console.WriteLine("Crime Analyzer");


            List<crimeStats> crimeStatsList = new List<crimeStats>();

            StreamReader reader = null;               
            
            try
            {
                reader = new StreamReader(dataFile);
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Length != 11)
                    {
                        Console.WriteLine("data error");
                    }

                }    

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message + "please ensure that 'CrimeAnalyzer <crime_csv_file_path> <report_file_path' is added into the command line");
                System.Environment.Exit(3);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(finalFile);
                writer.WriteLine("Crime Analyzer");

                var theYears = from crimeStats in crimeStatsList select crimeStats.Year;
                int MaxYear = theYears.Max();
                int minYear = theYears.Min();
                int NumberofYears = theYears.Count();

                writer.WriteLine("Period {0}-{1} ({2} years\t", minYear, MaxYear, NumberofYears);

                var murder = from crimeStats in crimeStatsList where crimeStats.Murder < 15000 select crimeStats.Year;

                foreach (var year in murder)
                {
                    writer.WriteLine("Years murders per year < 15000: {0}\t", year);
                }
                var robberies = from crimeStats in crimeStatsList where crimeStats.Robbery > 50000 select new { crimeStats.Year, crimeStats.Robbery };
                foreach (var year in robberies)
                {
                    writer.WriteLine("Robberies per year > 500000: {0} = {1}", year, robberies);
                }
                var violentcrimes = from crimeStats in crimeStatsList where crimeStats.Year == 2010 select crimeStats.ViolentCrime;
                foreach (var year in violentcrimes)
                {
                    writer.WriteLine("Violent crime per capita rate(2010): {0}", violentcrimes);
                }
                var murders = from crimeStats in crimeStatsList select crimeStats.Murder;
                writer.WriteLine("Average murder per year (all years): {0}", murders.Average());

                murders = from crimeStats in crimeStatsList where crimeStats.Year >= 1994 && crimeStats.Year <= 1997 select crimeStats.Murder;
                writer.WriteLine("Average murder per year (1994-1997): {0}", murders.Average());

                murders = from crimeStats in crimeStatsList where crimeStats.Year >= 2010 && crimeStats.Year <= 2014 select crimeStats.Murder;
                writer.WriteLine("Average murder per year (2010-2014): {0}", murders.Average());

                var thefts = from crimeStats in crimeStatsList where crimeStats.Year >= 1999 && crimeStats.Year <= 2004 select crimeStats.Theft;
                writer.WriteLine("Minimum thefts per year (1999–2004): {0}", thefts.Min());

                thefts = from crimeStats in crimeStatsList where crimeStats.Year >= 1999 && crimeStats.Year <= 2004 select crimeStats.Theft;
                writer.WriteLine("Maximum thefts per year (1999-2004): {0}", thefts.Max());

                var years = from crimeStats in crimeStatsList where crimeStats.MotorVehicleTheft >= 15000 select crimeStats.Year;
                writer.WriteLine("Year of highest number of motor vehicle thefts: {0}", years);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem with the path to your final file, please edit commands and try again" + e.Message);
                System.Environment.Exit(4);
            }
            finally
            {
                if (File.Exists(finalFile))
                {
                    Console.WriteLine("File was successfully written and saved");
                }
                else
                {
                    Console.WriteLine("File was not saved");
                }
                if (writer != null)
                {
                    writer.Close();
                }
            }

            Console.ReadKey();
            }
    }
}
