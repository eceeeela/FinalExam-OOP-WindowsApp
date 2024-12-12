using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//Yiling Chen 2232775
//Final Exam
//2023.04.25



namespace FinalExam
{
    public partial class Form1 : Form
    {
        string dir = @".\W2023\";
        string pathtext = @"..\W2023\Final.txt";
        private const string pathxml = @"..\W2023\Final.xml";
        FileStream fs = null;
        Student datavalidator;

        public Form1()
        {
            InitializeComponent();
        }

        private void fbt_validata_Click(object sender, EventArgs e)
        {
            double varIn1 = 0,varIn2 =0, varIn3 = 0, varIn4 = 0,
                varOut1 = 0;
            try
            {
                varIn1 = Convert.ToDouble(ftx_midnum.Text);
                Grade objectm = new Grade();
                objectm.MidNumGrade = varIn1;
                ftx_midper.Text = objectm.ConvertMidtermGrade().ToString();

                varIn2 = Convert.ToDouble(ftx_prjnum.Text);
                Grade objectp = new Grade();
                objectp.PrjNumGrade = varIn2;
                ftx_prjper.Text = objectp.ConvertProjectGrade().ToString();

                varIn3 = Convert.ToDouble(ftx_finnum.Text);
                Grade objectf = new Grade();
                objectf.FinNumGrade = varIn3;
                ftx_finper.Text = objectf.ConvertFinalGrade().ToString();

                varIn4 = Convert.ToDouble(ftx_totnum.Text);
                Grade objt = new Grade();
                objectf.TotalNumGrade = varIn3;
                ftx_totnum.Text = objectf.AddTotalGrade().ToString();






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void fbt_addtxt_Click(object sender, EventArgs e)
        {
            if (ftx_stname.Text.Trim() != "" && fbt_validata.Enabled == false)
            {
                if (ftx_stnum.Text.Trim() != "" && fbt_validata.Enabled == false)
                {
                    if (ftx_year.Text.Trim() != "" && fbt_validata.Enabled == false)
                    {
                        try
                        {
                            fs = new FileStream(pathtext, FileMode.Append, FileAccess.Write);
                            StreamWriter textOut = new StreamWriter(fs);

                            textOut.WriteLine("Name: " + datavalidator.StuName + "\t, Session: " + datavalidator.Session + "\t, Course Number: " + datavalidator.CourseNum
                                + "\t, Year: " + datavalidator.Year);

                            textOut.Close();
                            MessageBox.Show("The user was appended to the Text File", "User Registered");
                            fbt_validata.Enabled = true;
                            ftx_stname.Text = "";
                            ftx_stnum.Text = "";
                            ftx_year.Text = "";
                        }
                        catch (IOException ex)
                        { MessageBox.Show(ex.Message, "IOException"); }
                        finally
                        {
                            if (fs != null) fs.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valid Year?");
                        ftx_year.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Valid Course Number?");
                    ftx_stnum.Focus();
                }
            }//end if
            else
            {
                MessageBox.Show("Valid Name?");
                ftx_stname.Focus();
            }
        }

        private void fbt_crexml_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(pathtext, FileMode.Open, FileAccess.Read);
                StreamReader textIn = new StreamReader(fs);
                string textToPrint = "";
               
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true; settings.IndentChars = (" ");
                
                XmlWriter xmlOut = XmlWriter.Create(pathxml, settings);
                
                xmlOut.WriteStartDocument();
                xmlOut.WriteStartElement("Student");
                {
                    string row = "";
                    while (textIn.Peek() != -1)
                    {
                        row = textIn.ReadLine();
                        
                        textToPrint += row + "\n";
                        
                        xmlOut.WriteStartElement("Student");
                        xmlOut.WriteElementString("Grade", row);
                        xmlOut.WriteEndElement();
                        
                    }
                    xmlOut.WriteEndElement();
                    MessageBox.Show(textToPrint);
                   
                    textIn.Close();
                }
                xmlOut.Close();
            }
            catch (IOException ex)
            { MessageBox.Show(ex.Message, "IOException"); }
            finally { if (fs != null) fs.Close(); }
        }

        private void fbt_readxml_Click(object sender, EventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            
            XmlReader xmlIn = XmlReader.Create(pathxml, settings);
            string tempStr = "", row = "";
           
            if (xmlIn.ReadToDescendant("User"))
            {
              
                do
                {
                    xmlIn.ReadStartElement("User");
                    row = xmlIn.ReadElementContentAsString();

                    tempStr += row + "\n";
                }
                while (xmlIn.ReadToNextSibling("User"));
            }
            
            MessageBox.Show(tempStr, "Reading");
            xmlIn.Close();
        }

        private void fbt_exit_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you want to quit this Application",
             "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
