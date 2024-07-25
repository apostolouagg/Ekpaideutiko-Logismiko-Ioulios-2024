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
    public partial class DataStr_SetTypes : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");

        String username;

        public DataStr_SetTypes(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void buttonExampleHash_Click(object sender, EventArgs e)
        {
            MessageBox.Show("my_set = {1, 2, 3}\r\n"+
                "my_set.add(4)  # O(1) average case\r\nmy_set.remove(2)"+
                "# O(1) average case\r\nprint(3 in my_set)  # O(1) average case\r\n\r\n"

                , "Hash Set", MessageBoxButtons.OK);
        }

        private void buttonExampleTree_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TreeSet is not built-in in Python, but you can use the `sortedcontainers` module.\r\n\r\n" +
               "from sortedcontainers import SortedSet \r\n\r\n tree_set = SortedSet([1, 3, 2])\r\n tree_set.add(4)  # O(log n)\r\n" +
                "tree_set.remove(2)  # O(log n)\r\n print(3 in tree_set)  # O(log n) \r\n\r\n"

               , "Tree Set", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BitSet is not built-in in Python, but you can use the `bitarray` module. \r\n\r\n"+
                "from bitarray import bitarray\r\n\r\n bit_set = bitarray(10)\r\n " +
                "bit_set.setall(0)\r\n bit_set[1] = 1\r\n bit_set[3] = 1\r\n "+
                "print(bit_set)  # Output: bitarray('0101000000')\r\n\r\n"

               , "Bit Set", MessageBoxButtons.OK);
        }

        private void buttonExampleLinked_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LinkedHashSet is not built-in in Python, but you can create a similar behavior with `OrderedDict`.\r\n\r\n"+
                "from collections import OrderedDict\r\n\r\n linked_hash_set = OrderedDict()\r\nlinked_hash_set[1] = None " +
                "linked_hash_set[2] = None\r\nlinked_hash_set[3] = None\r\n del linked_hash_set[2]\r\n" +
                "print(list(linked_hash_set.keys()))  # Output: [1, 3]\r\n\r\n"

               , "Linked Hash Set", MessageBoxButtons.OK);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var DataStr = new DataStr(username);
            DataStr.Closed += (s, args) => this.Close();
            DataStr.Show();
        }

        private void DataStr_SetTypes_Load(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Clicks WHERE Username ='" + username + "' AND UnitID ='" + 5 + "' " +
                                                "AND SubunitID ='" + 3 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                conn.Open();
                String updateQuery = "UPDATE Clicks SET Clicks = Clicks + 1 " +
                                     "WHERE Username ='" + username + "' AND UnitID ='" + 5 + "' " +
                                     "AND SubunitID ='" + 3 + "'";
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
                cmd.Parameters.AddWithValue("@SubunitID", 3);
                cmd.Parameters.AddWithValue("@Clicks", 1);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
