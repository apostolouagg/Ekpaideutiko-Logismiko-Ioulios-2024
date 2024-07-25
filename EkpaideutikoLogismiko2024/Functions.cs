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
    public partial class Functions : Form
    {
        String username;

        public Functions(string username)
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

        private void labelFuncIntro_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Func_FuncIntro = new Func_FuncIntro(username);
            Func_FuncIntro.Closed += (s, args) => this.Close();
            Func_FuncIntro.Show();
        }

        private void labelFuncArgs_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Func_FuncArgs = new Func_FuncArgs(username);
            Func_FuncArgs.Closed += (s, args) => this.Close();
            Func_FuncArgs.Show();
        }

        private void labelKeyArgs_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Func_KeyArgs = new Func_KeyArgs(username);
            Func_KeyArgs.Closed += (s, args) => this.Close();
            Func_KeyArgs.Show();
        }

        private void labelAdvFunc_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Func_AdvFunc = new Func_AdvFunc(username);
            Func_AdvFunc.Closed += (s, args) => this.Close();
            Func_AdvFunc.Show();
        }
    }
}
