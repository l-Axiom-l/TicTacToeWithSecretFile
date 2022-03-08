using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using EasyEncrypt2;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool Player1 = true;
        int counter = 0;
        int resetCounter = 0;
        List<string> Rules = new List<string>();
        List<string> Player1List = new List<string>();
        List<string> Player2List = new List<string>();
        string P1 = "A1 A3 C1 C3 B2";
        string P2 = "A2 B1 B3 C2";
        EasyEncrypt crypto;
        SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
        bool unlock = false;

        public Form1()
        {
            InitializeComponent();
            Application.ApplicationExit += (s, e) => Lock();
            console.KeyDown += (s, e) => { if (e.KeyCode == Keys.F1) Confirm(); };
            crypto = new EasyEncrypt("5642", "Y9iGr@dya?)7", algo);
            Properties.Settings.Default.Reload();
            Rules = Properties.Resources.TicTacToeRules.Split('\n').ToList();
        }

        void ChangeField(int Index, Image image, ref List<string> list)
        {
            IEnumerable<Button> buttons = Board.Controls.OfType<Button>().Where(x => x.GetHashCode().Equals(Index));

            if (Player1List.Contains(buttons.ElementAt(0).Name) || Player2List.Contains(buttons.ElementAt(0).Name))
                return;

            buttons.ElementAt(0).BackgroundImage = image;
            list.Add(buttons.ElementAt(0).Name);
        }

        private void Click(object sender, EventArgs e)
        {
            counter++;
            resetCounter = 0;
            display.Text = "Round : " + counter;
            if (Player1)
            {
                ChangeField(sender.GetHashCode(), Properties.Resources.Cross, ref Player1List);
                console.AppendText("Player1 : " + Player1List.Last() + Environment.NewLine);
                Check(Player1List);
            }
            else
            {
                ChangeField(sender.GetHashCode(), Properties.Resources.Circle, ref Player2List);
                console.AppendText("Player2 : " + Player2List.Last() + Environment.NewLine);
                Check(Player2List);
            }


            Player1 = !Player1;
        }
        void Check(List<string> list)
        {
            foreach (string item in Rules)
            {
                string[] split = item.Split(' ');
                if (list.Contains(split[0]) && list.Contains(split[1]) && list.Contains(split[2]))
                    Win();
            }
        }
        void Win()
        {
            string player;
            if (Player1) player = "Player1"; else player = "Player2";
            Board.Enabled = false;
            display.ForeColor = Color.Green;
            display.Text = player + " Won";
        }

        private void restart_Click(object sender, EventArgs e)
        {
            resetCounter++;
            Board.Enabled = true;
            display.ForeColor = Color.Black;
            counter = 0;
            display.Text = "Round : " + counter;

            foreach (Button button in Board.Controls.OfType<Button>()) button.BackgroundImage = null;
            Player1List.Clear();
            Player2List.Clear();
            Player1 = true;
            console.ResetText();
            console.ReadOnly = true;
            Lock();

            if (resetCounter > 10)
                Reset();
        }

        private void display_Click(object sender, EventArgs e)
        {
            string[] split = P1.Split(' ');
            string[] split2 = P2.Split(' ');
            if (Player1List.All(x => split.Contains(x)) && Player2List.All(x => split2.Contains(x)) && Player1List.Count > 0 && Player2List.Count > 0)
            {
                console.ResetText();
                console.ReadOnly = false;
                Unlock();
            }
        }

        void Unlock()
        {
            unlock = true;

            if (Properties.Settings.Default.Setting == null)
                return;


            string temp = Properties.Settings.Default.Setting;
            console.Text = temp;
            temp = crypto.Decrypt(temp);
            Properties.Settings.Default.Setting = temp;
            console.Text = Properties.Settings.Default.Setting;


        }

        void Lock()
        {
            if (!unlock)
                return;

            string temp = crypto.Encrypt(Properties.Settings.Default.Setting);
            Properties.Settings.Default.Setting = temp;
            MessageBox.Show(temp, "Attention", MessageBoxButtons.OK);
            Properties.Settings.Default.Save();
        }


        void Confirm()
        {
            if (!unlock)
                return;

            Properties.Settings.Default.Setting = console.Text;
            MessageBox.Show("Saved");
        }

        void Reset()
        {
            console.Text = "Reset activated";
            Properties.Settings.Default.Setting = null;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            Properties.Settings.Default.Setting = crypto.Decrypt(Properties.Settings.Default.Setting);
            console.Text = Properties.Settings.Default.Setting;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Setting = crypto.Encrypt(Properties.Settings.Default.Setting);
            console.AppendText(Properties.Settings.Default.Setting);
            Properties.Settings.Default.Save();
        }
    }
}
