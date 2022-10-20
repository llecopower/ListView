using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListView.Business;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace ListView.DataAccess
{
    public static class EmployeeIO
    {
        //location where the data will be saved
        //@"" means that the data/file will be saved always at the root of the app folders
        private const string dir = @"";

        //name of the file where the data will be saved.
        private const string filepath = dir + "employee.dat";


        public static void SaveRecord(Employee emp)
        {
            StreamWriter sWriter = new StreamWriter(filepath,true);
            sWriter.WriteLine(emp.EmployeeId + "," + emp.FirstName + "," + emp.LastName);
            MessageBox.Show("Record saved Successfully");
            sWriter.Close();

        }

        public static Employee SearchRecord(int id)
        {
            Employee emp = new Employee();

            if (File.Exists(filepath))
            {
                StreamReader sReader = new StreamReader(filepath);
                string line = sReader.ReadLine();
                bool found = false;

                while (line != null)
                {
                    string[] fields = line.Split(',');

                    if (Convert.ToInt32(fields[0]) == id)
                    {
                        emp.EmployeeId = Convert.ToInt32(fields[0]);
                        emp.FirstName = fields[1];
                        emp.LastName = fields[2];

                        found = true;
                        break;
                    }

                    line = sReader.ReadLine();
                }

                sReader.Close();

                if (!found) // run with found and !found
                {
                    emp = null;
                }
            }

          
            else
            { //add here the emp = null and remove the extra if
                MessageBox.Show("File not found");
            }

            return emp;   
            
            //HOMEWORK SEARCH BY FIRST NAME
            
        }
    }
}
