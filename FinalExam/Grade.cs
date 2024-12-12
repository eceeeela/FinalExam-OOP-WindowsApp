using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//Yiling Chen 2232775
//Final Exam
//2023.04.25


namespace FinalExam
{
    internal class Grade
    {

        private double midnumGrade, prjnumGrade, finnumGrade, totalnumGrade;
        private string alpGrade;

        public double MidNumGrade
        {
            get { return totalnumGrade; }
            set { midnumGrade = value; }
        }

        public double PrjNumGrade
        {
            get { return prjnumGrade; }
            set { prjnumGrade = value; }
        }

        public double FinNumGrade
        {
            get { return finnumGrade; }
            set { finnumGrade = value; }
        }

        public double TotalNumGrade
        {
            get { return totalnumGrade; }
            set { totalnumGrade = value; }
        }

        public string AlpGrade
        {
            get { return alpGrade; }
            set { alpGrade = value; }
        }

        public Grade() { }
        public Grade(double midnumGrade, double prjnumGrade, double finnumGrade, string alpGrade)
        {
            this.MidNumGrade = midnumGrade;
            this.PrjNumGrade = prjnumGrade;
            this.FinNumGrade = finnumGrade;
            this.AlpGrade = alpGrade;

        }

        public double ConvertMidtermGrade()
        {
  
            return midnumGrade * 0.3;
        
        }
        public double ConvertProjectGrade()
        {
            return prjnumGrade * 0.3;
            
        }
        public double ConvertFinalGrade()
        {
            return finnumGrade * 0.4;
          
        }
        public double AddTotalGrade()
        {
            return ConvertMidtermGrade() + ConvertMidtermGrade() + ConvertProjectGrade();
        }



        public string ValidateAlpGrade()
        {

            if (totalnumGrade <= 100 && totalnumGrade >= 90)
            {
                return alpGrade = "A";
            }
            else if (totalnumGrade < 90 && totalnumGrade >= 80)
            {
                return alpGrade = "B";
            }
            else if (totalnumGrade < 80 && totalnumGrade >= 70)
            {
                return alpGrade = "C";
            }
            else if (totalnumGrade < 70 && totalnumGrade >= 60)
            {
                return alpGrade = "D";
            }
            else if (totalnumGrade < 60 && totalnumGrade >= 0)
            {
                return alpGrade = "F";
            }
            else
            {
                string notice = "Please enter a valide number grade";
                return notice;
            }

        }
    }

}
