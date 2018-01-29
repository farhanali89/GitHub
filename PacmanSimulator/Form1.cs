using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PacmanSimulator
{
    public partial class Form1 : Form
    {
        public int current_X = 0;
        public int current_Y = 0;
        public string current_Direction = "NORTH";

        public Form1()
        {
            InitializeComponent();
            
            txt_X.Text = "0";
            txt_Y.Text = "0";
            cmb_Face.SelectedIndex = 0;
            
        }

        public void placePacman(int x, int y, int new_x, int new_y, string direction)
        {
            try
            {
                if ((x >= 0 || x <= 4) && (y >= 0 || y <= 4)) //x,y should be in range between 0,0 to 4,4
                {
                    string old_btn = "btn_" + Convert.ToString(x) + Convert.ToString(y);
                    Button btn1 = this.Controls.Find(old_btn, true)[0] as Button;
                    btn1.BackColor = Color.FromArgb(225);

                    string new_btn = "btn_" + Convert.ToString(new_x) + Convert.ToString(new_y);
                    Button btn2 = this.Controls.Find(new_btn, true)[0] as Button;
                    btn2.BackColor = Color.Yellow;

                    Update_CurrentPosition(new_x, new_y, direction);
                    
                }
            }
            catch (Exception ex) 
            {
                txt_result.AppendText("\n Exception: " + ex.Message + "\n");
            }
        }


        public void Update_CurrentPosition(int x, int y, string direction) 
        {
            //update current x,y axies and direction
            current_X = x;
            current_Y = y;
            current_Direction = direction;

        }

        private void Change_Direction(string New_Direction) 
        {
            current_Direction = New_Direction;
            Update_CurrentPosition(current_X, current_Y, current_Direction);
        }

        private void btn_PlacePacman_Click(object sender, EventArgs e)
        {
            try
            {
                int new_X = Int32.Parse(txt_X.Text);
                int new_Y = Int32.Parse(txt_Y.Text);

                //current and new both will have different value.
                placePacman(current_X, current_Y, new_X, new_Y, cmb_Face.Text);         
            }
            catch (Exception ex)
            {
                txt_result.AppendText("\n Exception: " + ex.Message + "\n");
            }
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            switch (current_Direction.Trim())
            { 
                case "NORTH":
                    if (current_Y < 4)
                        placePacman(current_X, current_Y, current_X, current_Y + 1, current_Direction);
                    break;

                case "SOUTH":
                    if (current_Y > 0)
                        placePacman(current_X, current_Y, current_X, current_Y - 1, current_Direction);
                    break;

                case "EAST":
                    if (current_X < 4)
                        placePacman(current_X, current_Y, current_X + 1, current_Y, current_Direction);
                    break;

                case "WEST":
                    if (current_X > 0)
                        placePacman(current_X, current_Y, current_X - 1, current_Y, current_Direction);
                    break;
            }
        }

        private void btn_UP_Click(object sender, EventArgs e)
        {
            Change_Direction("NORTH");
        }

        private void btn_DOWN_Click(object sender, EventArgs e)
        {
            Change_Direction("SOUTH");
        }

        private void btn_LEFT_Click(object sender, EventArgs e)
        {
            Change_Direction("WEST");
        }

        private void btn_RIGHT_Click(object sender, EventArgs e)
        {
            Change_Direction("EAST");
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            //display result on textbox.
            txt_result.AppendText("Output: " + Convert.ToString(current_X) + "," + Convert.ToString(current_Y) + "," + current_Direction + "\n");
        }

    }
}
