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
    public partial class ConStr_Repetition : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");

        String username;

        public ConStr_Repetition(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ConStr = new ConStr(username);
            ConStr.Closed += (s, args) => this.Close();
            ConStr.Show();
        }

        private void buttonOutputFor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2, 4, 7, 1, 6, 4,\r\n\r\n" +
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9,",
                "For Loop Output", MessageBoxButtons.OK);
        }

        private void buttonOutputWhile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2 3 4 5 6 7 8 While loop is completed", "While Loop Output", MessageBoxButtons.OK);
        }

        private void ConStr_Repetition_Load(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Clicks WHERE Username ='" + username + "' AND UnitID ='" + 3 + "' " +
                         "AND SubunitID ='" + 4 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                conn.Open();
                String updateQuery = "UPDATE Clicks SET Clicks = Clicks + 1 " +
                                     "WHERE Username ='" + username + "' AND UnitID ='" + 3 + "' " +
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
                cmd.Parameters.AddWithValue("@UnitID", 3);
                cmd.Parameters.AddWithValue("@SubunitID", 4);
                cmd.Parameters.AddWithValue("@Clicks", 1);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
