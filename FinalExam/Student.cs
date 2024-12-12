using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinalExam
{
    internal class Student
    {
        private string stuName, session, courseNum;
        int year;
        public string StuName
        {
            get { return stuName; }
            set { stuName = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string Session
        {
            get { return session; }
            set { session = value; }
        }
        public string CourseNum
        {
            get { return courseNum; }
            set { courseNum = value; }
        }
        public Student() { }
        public Student(string stuName, string session, int year)
        {
            this.StuName = stuName; 
            this.session = session; 
            Year = year; 
        }
        public Boolean ValidateStudentName()
        {
            Regex rgxName = new Regex(@"^[a-zA-Z]{2}([a-zA-Z\s]){0,48}$");

            if (rgxName.IsMatch(StuName.Trim()) == true)
            {
                StuName = StuName.Trim();
                MessageBox.Show(StuName + "\nIs a valid Name", "Valid Name");
                return true;
            }
            else
            {
                MessageBox.Show("The name " + StuName + " is not valid\nEnter a valid name!\n up to 23 characters.", "Error");
                return false;
            }
        }
        public Boolean ValidateSession()
        {
            Regex rgxName = new Regex(@"^[a-zA-Z]{2}([a-zA-Z\s]){0,48}$");

            if (rgxName.IsMatch(Session.Trim()) == true && Session == "Winter" || Session =="Summer" || Session =="Fall")
            {
                MessageBox.Show(Session + "\nIs a valid session", "Valid session");
                return true;
            }
            else
            {
                MessageBox.Show("The session " + Session + " is not valid\nEnter a valid session!\n E.g: Winter, Summer, Fall.", "Error");
                return false;
            }
        }
        public Boolean ValidateCourseNum()
        {
            Regex rgxName = new Regex(@"^[a-zA-Z]{2}([a-zA-Z\s]){0,48}$");

            if (rgxName.IsMatch(CourseNum.Trim()) == true && CourseNum == "420-CT2-AS" || CourseNum == "420-DW2-AS")
            {
                MessageBox.Show(CourseNum + "\nIs a valid session", "Valid session");
                return true;
            }
            else
            {
                MessageBox.Show("The session " + CourseNum + " is not valid\nEnter a valid session!\n E.g: Winter, Summer, Fall.", "Error");
                return false;
            }
        }
        public Boolean ValidateYear()
        {
            Regex rgxName = new Regex(@"^[a-zA-Z]{2}([a-zA-Z\s]){0,48}$");

            if (rgxName.IsMatch(Year.ToString()) == true && Year >= 2022 && Year <= 2026)
            {
                MessageBox.Show(Year + "\nIs a valid year", "Valid Name");
                return true;
            }
            else
            {
                MessageBox.Show("The year " + Year + " is not valid\nEnter a valid year!\n down to 2022 and up to year 2026.", "Error");
                return false;
            }
        }

    }
    
    

}


