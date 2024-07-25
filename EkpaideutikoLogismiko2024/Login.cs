using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace EkpaideutikoLogismiko2024
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-9RR5NNA6\MSSQLSERVER01;Initial Catalog=Learn;Integrated Security=True;");


        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            String username;

            try
            {
                String query = "SELECT * FROM Users WHERE " +
                               "Username ='"+textBoxUsername.Text+ "' AND Password = '"+textBoxPassword.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    username = textBoxUsername.Text;
                }
                else
                {
                    throw new Exception();
                }

                //succsesful login
                MessageBox.Show("Login Successful! \r\n" + "Click OK to continue.", "Status",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                var Menu = new Menu(username);
                Menu.Closed += (s, args) => this.Close();
                Menu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Unsuccessful! \r\n" + "Wrong Username or Password! \r\n" +
                                "Please try again.", "Status", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxUsername.Clear();
                textBoxPassword.Clear();

                textBoxUsername.Focus();
            }
            finally
            {
                conn.Close();
            }
        }

        private void labelSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            var SignUp = new SignUp();
            SignUp.Closed += (s, args) => this.Close();
            SignUp.Show();
        }

        private void labelSignUp_MouseEnter(object sender, EventArgs e)
        {
            labelSignUp.Font = new Font(labelSignUp.Font, FontStyle.Underline);
        }

        private void labelSignUp_MouseLeave(object sender, EventArgs e)
        {
            labelSignUp.Font = new Font(labelSignUp.Font, FontStyle.Regular);
        }
    }
}
