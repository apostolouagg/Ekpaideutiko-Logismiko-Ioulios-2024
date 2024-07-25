using System;
using System.Windows.Forms;

namespace EkpaideutikoLogismiko2024
{
    public partial class File : Form
    {
        String username;

        public File(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new Menu(username);
            Menu.Closed += (s, args) => this.Close();
            Menu.Show();
        }

        private void open_read_Click(object sender, EventArgs e)
        {
            this.Hide();
            var File_OpenRead = new File_OpenRead(username);
            File_OpenRead.Closed += (s, args) => this.Close();
            File_OpenRead.Show();
        }

        private void labelCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            var File_CreateWrite = new File_CreateWrite(username);
            File_CreateWrite.Closed += (s, args) => this.Close();
            File_CreateWrite.Show();
        }

        private void labelDel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var File_Delete = new File_Delete(username);
            File_Delete.Closed += (s, args) => this.Close();
            File_Delete.Show();
        }
    }
}
