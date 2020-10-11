using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Form1 : Form
    {

        string connection = @"Data Source=.\sqlexpress;Initial Catalog=EmployeeInfo;Integrated Security=True";

        string filePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                string query = @" SELECT [DepartmentID]
                ,[DepartmentName]
                 FROM [dbo].[Department]";
                DataTable dt = fillData(query);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "DepartmentName";
                comboBox1.ValueMember = "DepartmentID";

                string query1 = @"SELECT [JobID]
                ,[JobTitle]
                ,[Salary]
                FROM [dbo].[Job]";
                DataTable dt1 = fillData(query1);
                comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "JobTitle";
                comboBox2.ValueMember = "JobID";


                dataGridView1.DataSource = fillData(@"select e.EmployeeID ,e.FirstName, e.Lastname, e.Address, e.Contact, d.DepartmentName , j.JobTitle from dbo.Employee e inner join dbo.Department d 
                                                    on e.DepartmentID = d.DepartmentID inner join  dbo.Job j 
                                                    on e.JobID = j.JobID ;");

        }

        private DataTable fillData(string query)
        {



            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {

                    da.SelectCommand = new SqlCommand(query, conn);
                    da.SelectCommand.CommandType = CommandType.Text;

                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "CustomerGender");
                    }
                    catch (Exception ee)
                    {

                    }

                    if (ds.Tables.Count == 0)
                    {
                        DataTable dt = new DataTable();
                        ds.Tables.Add(dt);
                    }
                    return ds.Tables[0];

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryInsert = @"INSERT INTO [dbo].[Employee]([EmployeeID],[FirstName],[Lastname],[Address],[Contact],[DepartmentID],[JobID],[ImageFile])
                                values ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + comboBox1.SelectedValue + "', '" + comboBox2.SelectedValue + "', " + filePath + ")";

            DataTable dtInsert = fillData(queryInsert);
            dataGridView1.DataSource = fillData(@"select e.EmployeeID ,e.FirstName, e.Lastname, e.Address, e.Contact, d.DepartmentName , j.JobTitle from dbo.Employee e inner join dbo.Department d 
                                                    on e.DepartmentID = d.DepartmentID inner join  dbo.Job j 
                                                    on e.JobID = j.JobID ;");

              
    }

        private void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog op1 = new OpenFileDialog();
            op1.Multiselect = false;
            op1.ShowDialog();
            op1.Filter = "allfiles|*";
            label4.Text = op1.FileName;
            pictureBox1.ImageLocation = label4.Text;


            int count = 0;
            string[] FName;
            foreach (string s in op1.FileNames)
            {
                FName = s.Split('\\');
                File.Copy(s, "D:\\" + FName[FName.Length - 1], true);
                filePath = "D:\\" + FName[FName.Length - 1];
                count++;
            }

            MessageBox.Show(Convert.ToString(count) + " File(s) copied");
        }

       

        
    }
}
