using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkpaideutikoLogismiko2024
{
    public partial class DataStr_MappingTypes : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");

        String username;

        public DataStr_MappingTypes(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("my_dict = {'name': 'Yolanda', 'age': 88, 'city': 'Pathsia'}\r\n"
                , "Creation", MessageBoxButtons.OK);

        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("print(my_dict['name'])  # Output: Yolanda}\r\n"
                , "Accessing Values", MessageBoxButtons.OK);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("my_dict['age'] = 26\r\nprint(my_dict)\r\n  # Output:" +
                "{'name': 'Yolanda', 'age': 26, 'city': 'Pathsia'}\r\n\r\n"
                , "Modifying Values", MessageBoxButtons.OK);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("my_dict['email'] = 'yolanda@example.com'\r\nprint(my_dict)\r\n" +
               " # Output: {'name': 'Yolanda', 'age': 26, 'city': 'Pathsia', 'email': 'yolanda@example.com'}\r\n\r\n"
                , "Adding Key-Value Pairs", MessageBoxButtons.OK);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("del my_dict['city']\r\nprint(my_dict)\r\n" +
                "# Output: {'name': 'Yolanda', 'age': 26, 'email': 'yolanda@example.com'}\r\n"+
                "value = my_dict.pop('email')\r\nprint(value)\r\n  # Output: 'yolanda@example.com'\r\nprint(my_dict)" +
                "# Output: {'name': 'Yolanda', 'age': 26}\r\n\r\n"
                , "Removing Key-Value Pairs", MessageBoxButtons.OK);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("print('name' in my_dict)\r\n" +
                "# Output: True\r\nprint('city' in my_dict)\r\n  # Output: False\r\n\r\n"
                , "Checking for Keys", MessageBoxButtons.OK);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("for key in my_dict:\r\n    print(key, my_dict[key])\r\n "+
                "# Output:\r\n# name Yolanda\r\n# age 26\r\n\r\nfor key, value in my_dict.items():\r\n"+
                "print(key, value)\r\n# Output:\r\n# name Yolanda\r\n# age 26\r\n\r\n"
                , "Iterating Over Keys and Values", MessageBoxButtons.OK);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var DataStr = new DataStr(username);
            DataStr.Closed += (s, args) => this.Close();
            DataStr.Show();
        }

        private void DataStr_MappingTypes_Load(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Clicks WHERE Username ='" + username + "' AND UnitID ='" + 5 + "' " +
             "AND SubunitID ='" + 2 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                conn.Open();
                String updateQuery = "UPDATE Clicks SET Clicks = Clicks + 1 " +
                                     "WHERE Username ='" + username + "' AND UnitID ='" + 5 + "' " +
                                     "AND SubunitID ='" + 2 + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                conn.Open();
                String insertQuery = "INSERT INTO Clicks VALUES (@Username, @UnitID, @SubunitID, @Clicks)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@UnitID", 5);
                cmd.Parameters.AddWithValue("@SubunitID", 2);
                cmd.Parameters.AddWithValue("@Clicks", 1);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
