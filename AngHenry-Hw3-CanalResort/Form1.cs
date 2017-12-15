using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngHenry_Hw3_CanalResort
{
    public partial class CanalResortForm : Form
    {
        public CanalResortForm()
        {
            InitializeComponent();
            numNightsNumericUpDown.Value = 1;
            twoQueenRadioButton.Checked = true;
            standardRadioButton.Checked = true;
            visaRadioButton.Checked = true;
            numRoomNumericUpDown.Maximum = 10;
            numNightsNumericUpDown.Maximum = 7;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // display charges for room
            decimal numNights = numNightsNumericUpDown.Value;
            decimal numRoom = numRoomNumericUpDown.Value;
            double roomCost = 0.0; 
            if (standardRadioButton.Checked == true & twoQueenRadioButton.Checked == true)
            {
                roomCost = (284.00 * (double)numRoom) * (double)numNights;
                roomOutpuLabel.Text = "$" + roomCost.ToString();
            }
            else if (atriumRadioButton.Checked == true & twoQueenRadioButton.Checked == true)
            {
                roomCost = (325.00 * (double)numRoom) * (double)numNights;
                roomOutpuLabel.Text = "$" + roomCost.ToString();
            }
            else if (standardRadioButton.Checked == true & oneKingRadioButton.Checked == true)
            {
                roomCost = (290.00 * (double)numRoom) * (double)numNights;
                roomOutpuLabel.Text = "$" + roomCost.ToString();
            }
            else if (atriumRadioButton.Checked == true & oneKingRadioButton.Checked == true)
            {
                roomCost = (350.00 * (double)numRoom) * (double)numNights;
                roomOutpuLabel.Text = "$" + roomCost.ToString();
            }
            else
            {
                roomOutpuLabel.Text = ""; 
            }

            // display charges for tax
            double tax = 0.15;
            double taxAmount = roomCost * tax; 
            taxOutputLabel.Text = "$" + taxAmount.ToString();

            // display charges for parking 
            double parkingCost = 0.00;
            if (parkingCheckBox.Checked == true)
            {
                parkingCost = 12.75;
            }
            parkingOutputLabel.Text = "$" + parkingCost.ToString();

            // display charges for resort fee
            decimal numRoomReserved = numRoomNumericUpDown.Value; 
            double resortFee = (15 * (double)numNights) * (double)numRoomReserved;
            resortFeeOutputLabel.Text = "$" + resortFee.ToString();

            // display charges for total Due 
            double totalDue = roomCost + taxAmount + parkingCost + resortFee; 
            totaldueOutputLabel.Text = "$" + totalDue.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // reset/clear all controls to default
            nameTextBox.Clear();
            twoQueenRadioButton.Checked = true;
            oneKingRadioButton.Checked = false;
            standardRadioButton.Checked = true;
            atriumRadioButton.Checked = false;
            numRoomNumericUpDown.Value = 0;
            numNightsNumericUpDown.Value = 1;
            numAdultsNumericUpDown.Value = 0;
            numChildrenNumericUpDown.Value = 0;
            parkingCheckBox.Checked = false;
            visaRadioButton.Checked = true;
            discoverRadioButton.Checked = false;
            mastercardRadioButton.Checked = false;
            americanExpressRadioButton.Checked = false;
            cardNumberMaskedTextBox.Clear();
            expirationDateMaskedTextBox.Clear();
            roomOutpuLabel.Text = "";
            taxOutputLabel.Text = "";
            parkingOutputLabel.Text = "";
            resortFeeOutputLabel.Text = "";
            totaldueOutputLabel.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // close the program
            this.Close(); 
        }

        private void visaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cardNumberMaskedTextBox.Mask = "4000-0000-0000-0000";
        }

        private void discoverRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cardNumberMaskedTextBox.Mask = "6000-0000-0000-0000";
        }

        private void mastercardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cardNumberMaskedTextBox.Mask = "5000-0000-0000-0000";
        }

        private void americanExpressRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cardNumberMaskedTextBox.Mask = "3000-0000000-00000";
        }

        private void numRoomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal numRooms = (decimal)(numRoomNumericUpDown.Value);

            numAdultsNumericUpDown.Maximum = numRooms * 6;
            numAdultsNumericUpDown.Minimum = numRooms;
            numChildrenNumericUpDown.Maximum = (numRooms * 6) - 1; 
            numChildrenNumericUpDown.Minimum = 0;
      
        }

        private void numAdultsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal numRooms = (decimal)(numRoomNumericUpDown.Value);
            decimal currentNumAdult = (decimal)(numAdultsNumericUpDown.Value);
            decimal currentNumChild = (decimal)(numChildrenNumericUpDown.Value);
            decimal numAdultChild = currentNumAdult + currentNumChild; 
            decimal maxInRoom = numRooms * (decimal)6;
            if (numAdultChild > maxInRoom)
            {
                if ((int)(numAdultsNumericUpDown.Value) == 0 | (int)(numChildrenNumericUpDown.Value) == 0)
                {
                    numChildrenNumericUpDown.Maximum = 0;
                    numAdultsNumericUpDown.Maximum = 0;
                }
                else
                {
                    numAdultsNumericUpDown.Value = Math.Abs(maxInRoom - numChildrenNumericUpDown.Value);
                }
            } 

        }
 
        private void numChildrenNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal numRooms = (decimal)(numRoomNumericUpDown.Value);
            decimal currentNumAdult = (decimal)(numAdultsNumericUpDown.Value);
            decimal currentNumChild = (decimal)(numChildrenNumericUpDown.Value);
            decimal numAdultChild = currentNumAdult + currentNumChild;
            decimal maxInRoom = numRooms * (decimal)6;
            if (numAdultChild > maxInRoom)
            {
                if ((int)(numAdultsNumericUpDown.Value) == 0 | (int)(numChildrenNumericUpDown.Value) == 0)
                {
                    numChildrenNumericUpDown.Maximum = 0;
                    numAdultsNumericUpDown.Maximum = 0;
                }
                else
                {
                    numChildrenNumericUpDown.Value = Math.Abs(maxInRoom - numAdultsNumericUpDown.Value);
                }
            }
        }
    }
}
