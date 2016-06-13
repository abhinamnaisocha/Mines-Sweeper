using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinesweeperTry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[,] b = new Button[100, 100];
        int random, count = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 0, y = 27;
            int width = 25, height = 23;
            for (int i = 0; i < 10; i++)
            {
                x = 0;
                for (int j = 0; j < 11; j++)
                {
                    Button bu = new Button();
                    bu.Location = new System.Drawing.Point(x, y);
                    bu.Size = new System.Drawing.Size(width, height);
                    this.Controls.Add(bu);
                    b[i, j] = bu;
                    x += 24;
                }
                y += 25;
            }

            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                random = r.Next(11);
                for (int j = 0; j < 11; j++)
                {
                    if (i == random || j == random || i + 4 == random || j + 5 == random)
                    {
                        b[i, j].Name = "mine";
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    b[i, j].Click += new EventHandler(b_Click);
                }

            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button bc = sender as Button;
            if (bc.Name == "mine")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (b[i, j].Name == "mine")
                        {
                            b[i, j].Text = "¤";
                        }
                        
                    }
                }
                
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        b[i, j].Enabled = false;
                    }

                }
                MessageBox.Show("LoL,Gotch ya Score: " + count);
            }
            else
            {
                bc.Text = "1";
                bc.Enabled = false;
                count++;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Try your luck and seee how much you score without hitting any mine, LoL");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("© CopyRight MBA  ®MBA Minesweeper");

        }

    }
}

