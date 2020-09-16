using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintain_Student_Scores
{
    public partial class frmAddScore : Form
    {
        public frmAddScore()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //check if the score value is between the range of 0 and 100
                if (Convert.ToInt32(txtScore.Text) >= 0 && Convert.ToInt32(txtScore.Text) <= 100)
                {
                    //if it is, then the score is added to student score list box
                    frmUpdateStudentScores.studentScore.Values.ElementAt(frmStudentScores.selected).Add(Convert.ToInt32(txtScore.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 100", "Entry Error");
                }
            }
            //catch and format exception
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid score.", "Entry Error");
            }
        }
    }
}
