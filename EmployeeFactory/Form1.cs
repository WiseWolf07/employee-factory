using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeFactory
{
    public partial class Form1 : Form
    {
        private List<IEmployee> employees;
        public Form1()
        {

            InitializeComponent();

            employees = new List<IEmployee>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employees.Add(new PermanentEmployee("John", 1000));
            employees.Add(new PermanentEmployee("Jane", 1500));
            employees.Add(new PermanentEmployee("Jack", 2000));

            employees.Add(new TempEmployee("Tom", 500));
            employees.Add(new TempEmployee("Tim", 600));
            employees.Add(new TempEmployee("Tina", 700));

            foreach (IEmployee employee in employees)
            {
                listEmployees.Items.Add(employee.GetName());
            }
        }

        private int getEmployeeIndex(string name)
        {
            int indexEmployee;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].GetName() == name)
                {
                    
                    indexEmployee = i;
                    return indexEmployee;
                }
            }
            return -1;
        }

        private string getType(int index)
        {
            if (employees[index].GetType().ToString() == "PermanentEmployee")
            {
                return "Permanent";
            }
            else
            {
                return "Temporary";
            }
        }

        private void listEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string selectedEmployee;
            int indexEmployee;
            string employeeType;
            if (listEmployees.SelectedItem != null)
            {
                textBoxName.Text = "";
                textBoxType.Text = "";
                textBoxSalary.Text = "";

                selectedEmployee = listEmployees.SelectedItem.ToString();
                indexEmployee = getEmployeeIndex(selectedEmployee);
                employeeType = getType(indexEmployee);

                textBoxName.Text = employees[indexEmployee].GetName();
                textBoxSalary.Text = employees[indexEmployee].GetIncome().ToString();
                textBoxType.Text = employeeType;

            }    
        }

        private bool isPermant(string type)
        {
            if (type == "Permanent")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int indexEmployee;
            int bonification;

            indexEmployee = getEmployeeIndex(textBoxName.Text);

            if(isPermant(textBoxType.Text))
            {
                PermanentEmployee permanentEmployee = (PermanentEmployee)employees[indexEmployee];
                bonification = permanentEmployee.calculateBonification();
                int totalSalary = bonification + int.Parse(textBoxSalary.Text);
                textBoxBonification.Text = totalSalary.ToString();
            }
            else
            {
                MessageBox.Show("The selectioned employee is temporary, they cant get a bonification", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
