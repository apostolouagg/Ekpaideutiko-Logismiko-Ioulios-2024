using System;
using System.Windows.Forms;

namespace EkpaideutikoLogismiko2024
{
    public partial class ConStr : Form
    {
        String username;

        public ConStr(string username)
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

        private void labelConIntro_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ConStr_ConStrInPython = new ConStr_ConStrInPython(username);
            ConStr_ConStrInPython.Closed += (s, args) => this.Close();
            ConStr_ConStrInPython.Show();
        }

        private void labelSequential_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ConStr_Sequential = new ConStr_Sequential(username);
            ConStr_Sequential.Closed += (s, args) => this.Close();
            ConStr_Sequential.Show();
        }

        private void labelSelection_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ConStr_Selection = new ConStr_Selection(username);
            ConStr_Selection.Closed += (s, args) => this.Close();
            ConStr_Selection.Show();
        }

        private void labelRepetition_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ConStr_Repetition = new ConStr_Repetition(username);
            ConStr_Repetition.Closed += (s, args) => this.Close();
            ConStr_Repetition.Show();
        }
    }
}
