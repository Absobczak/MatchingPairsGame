using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairsGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;

        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "l", "l", "m", "m", "N", "N", "J", "J",
            "z", "z", "b", "b", "?", "?", "s", "s", "#", "#",

            "Q", "Q", "Z", "Z", "~", "~", "$", "$",
            "%", "%", "!", "!", "t", "t", "Y", "Y", "O", "O"

        };

        System.Timers.Timer t;
        int m, s;
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
        //    t = new System.Timers.Timer();
        //    t.Interval = 1000;
        //    t.Elapsed += OnTimeEvent;
        //}


        ////public void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        ////{
        //    //Invoke(new Action(() =>
        //    //{
        //        s += 1;
        //        if (s == 60)
        //        {
        //            s = 0;
        //            m += 1;

        //        }
        //        txtResult.Text = string.Format("{1}:{2}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
        //    }));
        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label_click(object sender, EventArgs e)
        {
           
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;
            if (clickedLabel !=null)
            {
                if (clickedLabel.ForeColor == Color.Aquamarine)
                    return;

                //clickedLabel.ForeColor = Color.Black;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Aquamarine;

                    return;

                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Aquamarine;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        int i=0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            i++;
            txtResult.Text = i.ToString() + " seconds";
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
              
                }
            }

            timer2.Stop();

            MessageBox.Show("You matched all the tiles!", "Congratulations and well done!");
            Close();
        }

    }
}
