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
                
                if (Convert.ToInt32(txtScore.Text) >= 0 && Convert.ToInt32(txtScore.Text) <= 100)
                {
                 
                    frmUpdateStudentScores.studentScore.Values.ElementAt(frmStudentScores.selected).Add(Convert.ToInt32(txtScore.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter a score between 0 and 100");
                }
            }
      
            catch (FormatException)
            {
                MessageBox.Show("Enter a valid score.");
            }
        }
    }
}
