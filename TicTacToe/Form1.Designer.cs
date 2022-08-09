
namespace TicTacToe
{
    partial class TicTacToe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.A1 = new System.Windows.Forms.Button();
            this.A2 = new System.Windows.Forms.Button();
            this.A3 = new System.Windows.Forms.Button();
            this.B1 = new System.Windows.Forms.Button();
            this.B2 = new System.Windows.Forms.Button();
            this.B3 = new System.Windows.Forms.Button();
            this.C3 = new System.Windows.Forms.Button();
            this.C2 = new System.Windows.Forms.Button();
            this.C1 = new System.Windows.Forms.Button();
            this.Board = new System.Windows.Forms.GroupBox();
            this.console = new System.Windows.Forms.TextBox();
            this.display = new System.Windows.Forms.Label();
            this.restart = new System.Windows.Forms.Button();
            this.Board.SuspendLayout();
            this.SuspendLayout();
            // 
            // A1
            // 
            this.A1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.A1.Location = new System.Drawing.Point(2, 9);
            this.A1.Name = "A1";
            this.A1.Size = new System.Drawing.Size(87, 87);
            this.A1.TabIndex = 0;
            this.A1.Text = "\r\n";
            this.A1.UseVisualStyleBackColor = true;
            this.A1.Click += new System.EventHandler(this.Click);
            // 
            // A2
            // 
            this.A2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.A2.Location = new System.Drawing.Point(102, 9);
            this.A2.Name = "A2";
            this.A2.Size = new System.Drawing.Size(87, 87);
            this.A2.TabIndex = 0;
            this.A2.Text = "\r\n";
            this.A2.UseVisualStyleBackColor = true;
            this.A2.Click += new System.EventHandler(this.Click);
            // 
            // A3
            // 
            this.A3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.A3.Location = new System.Drawing.Point(202, 9);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(87, 87);
            this.A3.TabIndex = 1;
            this.A3.Text = "\r\n";
            this.A3.UseVisualStyleBackColor = true;
            this.A3.Click += new System.EventHandler(this.Click);
            // 
            // B1
            // 
            this.B1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B1.Location = new System.Drawing.Point(2, 109);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(87, 87);
            this.B1.TabIndex = 0;
            this.B1.Text = "\r\n";
            this.B1.UseVisualStyleBackColor = true;
            this.B1.Click += new System.EventHandler(this.Click);
            // 
            // B2
            // 
            this.B2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B2.Location = new System.Drawing.Point(102, 109);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(87, 87);
            this.B2.TabIndex = 0;
            this.B2.Text = "\r\n";
            this.B2.UseVisualStyleBackColor = true;
            this.B2.Click += new System.EventHandler(this.Click);
            // 
            // B3
            // 
            this.B3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B3.Location = new System.Drawing.Point(202, 109);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(87, 87);
            this.B3.TabIndex = 1;
            this.B3.Text = "\r\n";
            this.B3.UseVisualStyleBackColor = true;
            this.B3.Click += new System.EventHandler(this.Click);
            // 
            // C3
            // 
            this.C3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.C3.Location = new System.Drawing.Point(202, 209);
            this.C3.Name = "C3";
            this.C3.Size = new System.Drawing.Size(87, 87);
            this.C3.TabIndex = 4;
            this.C3.Text = "\r\n";
            this.C3.UseVisualStyleBackColor = true;
            this.C3.Click += new System.EventHandler(this.Click);
            // 
            // C2
            // 
            this.C2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.C2.Location = new System.Drawing.Point(102, 209);
            this.C2.Name = "C2";
            this.C2.Size = new System.Drawing.Size(87, 87);
            this.C2.TabIndex = 2;
            this.C2.Text = "\r\n";
            this.C2.UseVisualStyleBackColor = true;
            this.C2.Click += new System.EventHandler(this.Click);
            // 
            // C1
            // 
            this.C1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.C1.Location = new System.Drawing.Point(2, 209);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(87, 87);
            this.C1.TabIndex = 3;
            this.C1.UseVisualStyleBackColor = true;
            this.C1.Click += new System.EventHandler(this.Click);
            // 
            // Board
            // 
            this.Board.Controls.Add(this.B3);
            this.Board.Controls.Add(this.C3);
            this.Board.Controls.Add(this.A1);
            this.Board.Controls.Add(this.C2);
            this.Board.Controls.Add(this.A2);
            this.Board.Controls.Add(this.C1);
            this.Board.Controls.Add(this.B1);
            this.Board.Controls.Add(this.A3);
            this.Board.Controls.Add(this.B2);
            this.Board.Location = new System.Drawing.Point(21, 81);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(291, 300);
            this.Board.TabIndex = 5;
            this.Board.TabStop = false;
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(332, 90);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(130, 291);
            this.console.TabIndex = 6;
            // 
            // display
            // 
            this.display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.display.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.display.ForeColor = System.Drawing.SystemColors.ControlText;
            this.display.Location = new System.Drawing.Point(20, 31);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(290, 29);
            this.display.TabIndex = 7;
            this.display.Text = "Round : 0";
            this.display.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.display.Click += new System.EventHandler(this.display_Click);
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(332, 31);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(130, 29);
            this.restart.TabIndex = 8;
            this.restart.Text = "New Game";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // TicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 411);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.display);
            this.Controls.Add(this.console);
            this.Controls.Add(this.Board);
            this.Name = "TicTacToe";
            this.Text = "Form1";
            this.Board.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button A1;
        private System.Windows.Forms.Button A2;
        private System.Windows.Forms.Button A3;
        private System.Windows.Forms.Button B1;
        private System.Windows.Forms.Button B2;
        private System.Windows.Forms.Button B3;
        private System.Windows.Forms.Button C3;
        private System.Windows.Forms.Button C2;
        private System.Windows.Forms.Button C1;
        private System.Windows.Forms.GroupBox Board;
        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.Label display;
        private System.Windows.Forms.Button restart;
    }
}

