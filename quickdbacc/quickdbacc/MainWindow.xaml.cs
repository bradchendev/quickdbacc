using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace quickdbacc
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public string DBServer { get; set; }
        public string DBname { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void inputSql_MouseDown(object sender, EventArgs e)
        {

            if (inputSql.Text == "SQL")
            {
                inputSql.Clear();
            }
        }

        private void ExecSQLQuery(string dbType)
        {

            if (inputSql.Text == "SQL")
            {
                MessageBox.Show("sql invalid!!!");
                return;
            }

            DBServer = txtServer.Text;
            DBname = txtDB.Text;
            DBUser = txtUser.Text;
            DBPassword = pwBox1.Password;


            if (dbType == "SQLServer")
            {
                try
                {

                    // SqlConnection.ConnectionString
                    // https://msdn.microsoft.com/zh-tw/library/system.data.sqlclient.sqlconnection.connectionstring(v=vs.110).aspx
                    // User ID=xxxxx; Password=xxxx

                    //SqlConnection thisConnection = new SqlConnection(@"Server=WIN-D6FVJJ81S3S;Database=AdventureWorks2008R2;Trusted_Connection=Yes;");
                    //thisConnection.Open();

                    //Data Source=.;Initial Catalog=myDB;Integrated Security=true;

                    string connectionString =
                            "Server=" + DBServer +
                            ";Database=" + DBname;

                    if (rbSQL.IsChecked == true)
                    {
                        connectionString += ";User ID=" + DBUser +
                                                            ";Password=" + DBPassword;
                    }
                    else if (rbWin.IsChecked == true)
                    {
                        connectionString += ";Trusted_Connection=Yes";
                    }


                    string Get_Data = "";
                    if (string.IsNullOrEmpty(inputSql.Text) || inputSql.Text == "")
                    {
                        Get_Data = "SELECT TOP(10) [DepartmentID],[Name],[GroupName],[ModifiedDate] FROM HumanResources.Department";
                    }
                    else
                    {
                        Get_Data = inputSql.Text;
                    }

                    inputSql.Text = Get_Data;


                    DataTable dt = new DataTable("data");
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = Get_Data;
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                    }
                    dataGrid1.ItemsSource = dt.DefaultView;
                }
                catch
                {
                    MessageBox.Show("db error");
                }
            }
            else if (dbType == "MySQL")
            {
                try
                {
                    //MySqlConnection thisConnection = new MySqlConnection("server=172.16.1.1;uid=bradchen;pwd=xxxxx;database=Employees;");

                    string connectionString =
                            "server=" + DBServer +
                            ";database=" + DBname +
                            ";uid=" + DBUser +
                            ";pwd=" + DBPassword;

                    MySqlConnection thisConnection = new MySqlConnection(connectionString);
                    thisConnection.Open();

                    string Get_Data = "";
                    if (string.IsNullOrEmpty(inputSql.Text) || inputSql.Text == "")
                    {
                        Get_Data = "SELECT * FROM Employees.employees";
                    }
                    else
                    {
                        Get_Data = inputSql.Text;
                    }

                    inputSql.Text = Get_Data;

                    MySqlCommand cmd = thisConnection.CreateCommand();
                    cmd.CommandText = Get_Data;
                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable("data");
                    sda.Fill(dt);

                    dataGrid1.ItemsSource = dt.DefaultView;
                }
                catch
                {
                    MessageBox.Show("db error");
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isListBoxSelected = false;
            foreach (object item in lbxDBType.Items)
            {
                if (lbxDBType.SelectedItems.Contains(item))
                {
                    isListBoxSelected = true;
                }
            }

            if (!isListBoxSelected)
            {
                MessageBox.Show("請選擇資料庫類型!!!");
                return;
            }

            string dbType = ((ListBoxItem)this.lbxDBType.SelectedValue).Content.ToString();

            ExecSQLQuery(dbType);
        }

        private void ListBoxItemMSSQL_Selected(object sender, RoutedEventArgs e)
        {
            inputSql.Clear();
            txtServer.Text = "WIN-D6FVJJ81S3S";
            txtDB.Text = "AdventureWorks2008R2";
            txtUser.Text = "sa";
            pwBox1.Clear();

            rbSQL.IsEnabled = true;
            rbWin.IsEnabled = true;

            if (rbWin.IsChecked == true)
            {
                txtUser.IsEnabled = false;
                pwBox1.IsEnabled = false;
            }
            else
            {
                txtUser.IsEnabled = true;
                pwBox1.IsEnabled = true;
            }

        }

        private void ListBoxItemMySQL_Selected(object sender, RoutedEventArgs e)
        {
            inputSql.Clear();
            txtServer.Text = "172.16.1.1";
            txtDB.Text = "Employees";
            txtUser.Text = "bradchen";
            pwBox1.Clear();

            rbSQL.IsEnabled = false;
            rbWin.IsEnabled = false;
            txtUser.IsEnabled = true;
            pwBox1.IsEnabled = true;

        }

        private void RadioButtonWin_Checked(object sender, RoutedEventArgs e)
        {
            txtUser.IsEnabled = false;
            pwBox1.IsEnabled = false;

            // ... Get RadioButton reference.
            //var button = sender as RadioButton;

            // ... Display button content as title.
            //this.Title = button.Content.ToString();
        }

        private void RadioButtonSQL_Checked(object sender, RoutedEventArgs e)
        {
            txtUser.IsEnabled = true;
            pwBox1.IsEnabled = true;

            // ... Get RadioButton reference.
            //var button = sender as RadioButton;

            // ... Display button content as title.
            //this.Title = button.Content.ToString();
        }
    }
}
