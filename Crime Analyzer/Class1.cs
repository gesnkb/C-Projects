using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Analyzer
{
    class crimeStats
    {
     
            public int Year;
            public int Population;
            public int ViolentCrime;
            public int Murder;
            public int Rape;
            public int Robbery;
            public int AggravatedAssault;
            public int PropertyCrime;
            public int Burglary;
            public int Theft;
            public int MotorVehicleTheft;

            public crimeStats(int Year, int Population, int ViolentCrime, int Murder, int Rape, int Robbery, int AggravatedAssault, int PropertyCrime, int Burgalry, int Theft, int MotorVehicleTheft)
            {
                this.Year = Year;
                this.Population = Population;
                this.ViolentCrime = ViolentCrime;
                this.Murder = Murder;
                this.Rape = Rape;
                this.Robbery = Robbery;
                this.AggravatedAssault = AggravatedAssault;
                this.PropertyCrime = PropertyCrime;
                this.Burglary = Burgalry;
                this.Theft = Theft;
                this.MotorVehicleTheft = MotorVehicleTheft;



            }
        }
}
