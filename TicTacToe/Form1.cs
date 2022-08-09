using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using EasyEncrypt2;
using System.Diagnostics;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        bool Player1 = true;
        int counter = 0;
        int resetCounter = 0;
        EasyEncrypt crypto;
        SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
        bool unlock = false;
        int[,] board = new int[3, 3];
        int[,] code = new int[3, 3] {{ 1,-1, 1},
                                    {-1, 1,-1 },
                                    { 1,-1, 1 }};

        public TicTacToe()
        {
            InitializeComponent();
            Application.ApplicationExit += (s, e) => Lock();
            crypto = new EasyEncrypt("5642", "Y9iGr@dya?)7", algo);
            Properties.Settings.Default.Reload();
        }

        void ChangeField(int Index, Image image)
        {
            IEnumerable<Button> buttons = Board.Controls.OfType<Button>().Where(x => x.GetHashCode().Equals(Index));
            int Y = Convert.ToInt32(buttons.ElementAt(0).Name.First()) - 65;
            int X = Convert.ToInt32(buttons.ElementAt(0).Name.Last()) - 49;
            if (board[X, Y] != 0)
                return;
            buttons.ElementAt(0).BackgroundImage = image;
            board[X, Y] = Player1 ? 1 : -1;
            Debug.WriteLine($"{X}:{Y}");
            Test();
        }

        private void Click(object sender, EventArgs e)
        {
            counter++;
            resetCounter = 0;
            display.Text = "Round : " + counter;
            if (Player1)
            {
                ChangeField(sender.GetHashCode(), Properties.Resources.Cross);
            }
            else
            {
                ChangeField(sender.GetHashCode(), Properties.Resources.Circle);
            }

            Player1 = !Player1;
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
            board = new int[3, 3];
            Board.Enabled = true;
            display.ForeColor = Color.Black;
            counter = 0;
            display.Text = "Round : " + counter;
            foreach (Button button in Board.Controls.OfType<Button>()) button.BackgroundImage = null;
            Player1 = true;
            console.ResetText();
            console.ReadOnly = true;
            Lock();

            if (resetCounter > 10)
                Reset();
        }

        private void display_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("DisplayClick");
            if (board.ArrayTester(code))
            {
                console.ResetText();
                console.ReadOnly = false;
                Debug.WriteLine("Unlock");
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
            DialogResult result = MessageBox.Show("Do you want to save your changes?", "Attention", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Confirm();
            string temp = crypto.Encrypt(Properties.Settings.Default.Setting);
            Properties.Settings.Default.Setting = temp;
            MessageBox.Show(temp, "Locked", MessageBoxButtons.OK);
            Properties.Settings.Default.Save();
            unlock = false;
        }


        void Confirm()
        {
            if (!unlock)
                return;

            Properties.Settings.Default.Setting = console.Text;
        }

        void Reset()
        {
            console.Text = "Reset activated";
            Properties.Settings.Default.Setting = null;
            Properties.Settings.Default.Save();
        }

        void Test()
        {
            int[] Rows = Enumerable.Range(0, 3).Select(x => GetRow(board, x).Sum()).ToArray();
            int[] Columns = Enumerable.Range(0, 3).Select(x => GetColumn(board, x).Sum()).ToArray();
            if (Rows.Contains(3) || Rows.Contains(-3) || Columns.Contains(3) || Columns.Contains(-3) || DiagonalsSums(board).Contains(3) || DiagonalsSums(board).Contains(-3))
            {
                Win();
                Debug.WriteLine("Win");
            }
        }

        public int[] GetRow(int[,] board, int rowNumber)
        {
            return Enumerable.Range(0, board.GetLength(0)).Select(x => board[x, rowNumber]).ToArray();
        }

        public int[] GetColumn(int[,] board, int columnNumber)
        {
            return Enumerable.Range(0, board.GetLength(0)).Select(x => board[columnNumber, x]).ToArray();
        }

        public int[] DiagonalsSums(int[,] board)
        {
            int[] ULC = Enumerable.Range(0, board.GetLength(0)).Select(x => board[x, x]).ToArray();
            int[] numbers = Enumerable.Range(0, 3).ToArray();
            int[] URC = numbers.Select(x => board[x, numbers.Reverse().ElementAt(x)]).ToArray();
            return new int[] { ULC.Sum(), URC.Sum() };
        }
    }

    public static class Utilities
    {
        public static bool ArrayTester(this int[,] mainArray, int[,] testArray)
        {
            bool test = false;
            for (int i = 0; i < mainArray.GetLength(0); i++)
                for (int j = 0; j < mainArray.GetLength(1); j++)
                {
                    if (mainArray[i, j] == testArray[i, j])
                    {
                        test = true;
                        continue;
                    }

                    else
                    {
                        test = false;
                        break;
                        break;
                    }
                }
            return test;

        }
    }
}
