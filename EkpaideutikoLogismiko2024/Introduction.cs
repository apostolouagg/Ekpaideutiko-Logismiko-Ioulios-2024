using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkpaideutikoLogismiko2024
{
    public partial class Introduction : Form
    {
        String username;

        public Introduction(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void intro_and_setup_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Intro_Installation_Setup = new Intro_Installation_Setup(username);
            Intro_Installation_Setup.Closed += (s, args) => this.Close();
            Intro_Installation_Setup.Show();
        }

        private void labelBasicSyntax_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Intro_BasicSyntax = new Intro_BasicSyntax(username);
            Intro_BasicSyntax.Closed += (s, args) => this.Close();
            Intro_BasicSyntax.Show();
        }

        private void labelRunAndDeb_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Intro_Running_Debugging = new Intro_Running_Debugging(username);
            Intro_Running_Debugging.Closed += (s, args) => this.Close();
            Intro_Running_Debugging.Show();
        }

        private void labelBasicComms_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Intro_BasicCommands = new Intro_BasicCommands(username);
            Intro_BasicCommands.Closed += (s, args) => this.Close();
            Intro_BasicCommands.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new Menu(username);
            Menu.Closed += (s, args) => this.Close();
            Menu.Show();
        }
    }
}
