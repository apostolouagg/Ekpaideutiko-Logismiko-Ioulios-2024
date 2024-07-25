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
    public partial class Func_AdvFunc : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");

        String username;

        public Func_AdvFunc(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Functions = new Functions(username);
            Functions.Closed += (s, args) => this.Close();
            Functions.Show();
        }

        private void buttonPassList_Click(object sender, EventArgs e)
        {
            MessageBox.Show("apple\r\n" +
                            "banana\r\n" +
                            "cherry", 
                            "Passing a List as an Argument Output", MessageBoxButtons.OK);
        }

        private void buttonReturnVals_Click(object sender, EventArgs e)
        {
            MessageBox.Show("15\r\n" +
                            "25\r\n" +
                            "45", 
                            "Return Values Output", MessageBoxButtons.OK);
        }

        private void buttonRecursion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recursion Example Results\r\n" +
                            "1\r\n" +
                            "3\r\n" +
                            "6\r\n" +
                            "10\r\n" +
                            "15\r\n" +
                            "21", 
                            "Recursion Output", MessageBoxButtons.OK);
        }

        private void buttonOnlyArgs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("3\r\n" +
                            "3\r\n",
                            "Positional-Only and Keyword-Only Arguments Output", MessageBoxButtons.OK);
        }

        private void Func_AdvFunc_Load(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Clicks WHERE Username ='" + username + "' AND UnitID ='" + 4 + "' " +
             "AND SubunitID ='" + 4 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                conn.Open();
                String updateQuery = "UPDATE Clicks SET Clicks = Clicks + 1 " +
                                     "WHERE Username ='" + username + "' AND UnitID ='" + 4 + "' " +
                                     "AND SubunitID ='" + 4 + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                conn.Open();
                String insertQuery = "INSERT INTO Clicks VALUES (@Username, @UnitID, @SubunitID, @Clicks)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@UnitID", 4);
                cmd.Parameters.AddWithValue("@SubunitID", 4);
                cmd.Parameters.AddWithValue("@Clicks", 1);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
