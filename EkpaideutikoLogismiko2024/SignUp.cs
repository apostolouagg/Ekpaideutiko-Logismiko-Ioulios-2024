using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EkpaideutikoLogismiko2024
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "SELECT * FROM Users WHERE Username ='" +textBoxUsername.Text+ "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0 || string.IsNullOrEmpty(textBoxFirstName.Text) || string.IsNullOrEmpty(textBoxSurname.Text)
                                      || string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
                {
                    throw new Exception();
                }
                else
                {
                    conn.Open();
                    String insertQuery = "INSERT INTO Users VALUES (@Username, @Password, @Name, @Surname)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@Username", textBoxUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@Name", textBoxSurname.Text);
                    cmd.Parameters.AddWithValue("@Surname", textBoxFirstName.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sign Up Successful! \r\n" + "Click OK to continue.", "Status",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    var Login = new Login();
                    Login.Closed += (s, args) => this.Close();
                    Login.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sign Up Unsuccessful! \r\n" + 
                                "Username must be unique and Fields must NOT be empty! Please try again.", "Status",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxUsername.Clear();
                textBoxPassword.Clear();
                textBoxSurname.Clear();
                textBoxFirstName.Clear();

                textBoxUsername.Focus();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
