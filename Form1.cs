using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Challenge_App
{
    public partial class RoomCalculator : Form
    {
        public bool valid { get; private set; } //boolean which is checked to ensure user entered data is valid

        public RoomCalculator()
        {
            InitializeComponent();
        }


        public void validate(string var) //validation method which checks user entered data to ensure it is only numerical data
        {
            
            if (var == null)
            {
                valid = false;
            }
            else if (var == "0")
            {
                valid = false;
            }
            bool allDigits = var.All(char.IsDigit);
            if (allDigits == false)
            {
                valid = false;
            }
        }

        public void calcVolume() //method which calulates volume based on measurements
        {
            double height = Convert.ToInt32(txtHeight.Text);
            double width1 = Convert.ToInt32(txtWidth1.Text);
            double width2 = Convert.ToInt32(txtWidth2.Text);
            double width3 = Convert.ToInt32(txtWidth3.Text);
            double width4 = Convert.ToInt32(txtWidth4.Text);
            double s = (width1 + width2 + width3 + width4) / 2;
            double floorArea = Math.Sqrt((s - width1) * (s - width2) * (s - width3) * (s - width4)); //formula to calculate area of quadrilateral
            double volume = Math.Round((floorArea * height), 2); //multiplies area by height to return volume
            if (rdoFeet.Checked == true)//If the user entered measurements in feet, multiply result by 3.28
                {
                volume = Math.Round((volume * 3.28), 2);
                lblVolume.Text = "Volume of room(Feet Cubed):" + Convert.ToString(volume);//display result
            }

            else
            {
                lblVolume.Text = "Room Volume(Metres Cubed):" + Convert.ToString(volume);//display result
            }
        }

        public void calcArea()
        {
            double height = Convert.ToInt32(txtHeight.Text);
            double width1 = Convert.ToInt32(txtWidth1.Text);
            double width2 = Convert.ToInt32(txtWidth2.Text);
            double width3 = Convert.ToInt32(txtWidth3.Text);
            double width4 = Convert.ToInt32(txtWidth4.Text);
            double s = (width1 + width2 + width3 + width4) / 2; 
            double floorArea = Math.Round(Math.Sqrt((s - width1) * (s - width2) * (s - width3) * (s - width4)),2); //formula to calculate area of quadrilateral
            if (rdoFeet.Checked == true) //If the user entered measurements in feet, multiply result by 3.28

                {
                floorArea = Math.Round(floorArea * 3.28,2);
                lblFloorArea.Text = "Floor Area(Feet Sqaured):" + Convert.ToString(floorArea);//display result
                }

            else
            {
                lblFloorArea.Text = "Floor Area(Metres Squared):" + Convert.ToString(floorArea);//display result
                }
        }

        public void calcPaint()
        {
            int height = Convert.ToInt32(txtHeight.Text);
            int width1 = Convert.ToInt32(txtWidth1.Text);
            int width2 = Convert.ToInt32(txtWidth2.Text);
            int width3 = Convert.ToInt32(txtWidth3.Text);
            int width4 = Convert.ToInt32(txtWidth4.Text);
            int wallArea = (width1 + width2 + width3 + width4) * height;
            double paint = Math.Round(wallArea * 0.1, 2);
            if (rdoFeet.Checked == true)
            {
                paint = Math.Round(paint * 3.28, 2); //If the user entered measurements in feet, multiply result by 3.28
            }

            lblPaint.Text = "Amount of paint(Litres):" + Convert.ToString(paint); //display result

        }
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            valid = true;
            validate(txtHeight.Text); //validates fields
            validate(txtWidth1.Text);
            validate(txtWidth2.Text);
            validate(txtWidth3.Text);
            validate(txtWidth4.Text);
            if (valid == true)
            {
                calcVolume();
                calcPaint();
                calcArea();
            }
            else
            {
                MessageBox.Show("Please enter valid measurements", "Invalid Measurements", MessageBoxButtons.OK, MessageBoxIcon.Error); //error is displayed if validation finds invalid data
            }
            
        }

    }
}
