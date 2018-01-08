using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        bool turn = true;//true= x turn,false=y turn;
        int turn_count = 0;
        int TestNum = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vista © 2017", "关于");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Image == null)
            {
                if (turn)
                {
                    b.Image = WindowsFormsApplication1.Resource1.dog;
                    b.Text = " ";
                }

                else
                {
                    b.Image = WindowsFormsApplication1.Resource1.cat;
                    b.Text = "  ";
                }

                turn = !turn;
                turn_count++;
                checkForWiner ( );
            }
            else
            {
                MessageBox.Show ( "亲，您不可以选择这里！");
            }
        }

        private void checkForWiner()
        {
            bool there_is_a_winer = false;
            //horizontal checks
            if ((A1.Text == A2.Text )&& (A2.Text == A3.Text)&&(A1.Image!=null))
                there_is_a_winer = true;
            else if ((B1.Text == B2.Text )&& (B2.Text == B3.Text) && (B1.Image != null)) 
                there_is_a_winer = true;
            else if ((C1.Text == C2.Text )&&( C2.Text == C3.Text) && (C1.Image != null))
                there_is_a_winer = true;


            //vertical checks
            else if ((A1.Text == B1.Text) && (B1 .Text == C1.Text) && (A1.Image != null))
                there_is_a_winer = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (A2.Image != null))
                there_is_a_winer = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (A3.Image != null))
                there_is_a_winer = true;


            //diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (A1.Image != null))
                there_is_a_winer = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (C1.Image != null))
                there_is_a_winer = true;
            if (there_is_a_winer )
            {
                disableButtons();
                string winer="";
                if (turn)
                    winer = "Cate";
                else
                    winer = "Doge";
                MessageBox.Show(winer + "   Win!!!", "Yay！");
            }//END IF
            else
            {
                if(turn_count ==9)
                    MessageBox.Show("Draw!", "Bummer!");
            }
            TestNum = 100;
        }//END checkForWiner

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }//end foreach
            catch { }
        }

        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Image = null;
                    b.Text = "";
                    b.Enabled = true;
                }
            }//end foreach
            catch { }
        }
    }
}
