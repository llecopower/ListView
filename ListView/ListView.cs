using ListView.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView
{
    public partial class ListView : Form
    {
        public ListView()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
           Employee oEmp = new Employee();

            oEmp.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text);
            oEmp.FirstName = textBoxFirstName.Text;
            oEmp.LastName = textBoxLastName.Text;

            oEmp.SaveEmployee(oEmp);

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(textBoxEmployeeId.Text));

            if (emp != null)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);

                listViewEmployee.Items.Add(item);
            }

            else
            {
                MessageBox.Show("Files not found!");
            }


        }
    }
}
