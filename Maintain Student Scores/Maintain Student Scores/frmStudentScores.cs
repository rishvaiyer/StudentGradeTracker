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
    public partial class frmStudentScores : Form
    {
      //dictonary 
        public static Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
        public static int selected;

        public frmStudentScores()
        {
            InitializeComponent();
        }

        private void frmStudentScores_Load(object sender, EventArgs e)
        {
           
            students.Add("Joel Murach", new List<int> { 75, 73, 33 });
            students.Add("Doug Lowe", new List<int> { 59, 23, 97 });
            students.Add("Anne Boehm", new List<int> { 10, 100, 100 });
            addToLB();
        }
       
        
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form updateScores = new frmUpdateStudentScores();
      
            selected = lblxstudents.SelectedIndex;
            
            if (lblxstudents.Items.Count > 0)
            {
                updateScores.ShowDialog();
            }
            else
            {
                MessageBox.Show("Student info not in data");
            }
          
            addToLB();
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {

            Form addNewStudent = new frmAddNewStudent();
            addNewStudent.ShowDialog();
            lblxstudents.Items.Clear();
            addToLB();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            students.Remove(students.Keys.ElementAt(lblxstudents.SelectedIndex));
            lblxstudents.Items.Clear();
            addToLB();
            
            if (students.Count == 0)
            {
                txtAverage.Text = "";
                txtScoreCount.Text = "";
                txtScoreTotal.Text = "";
            }
        }
        
        private void addToLB()
        {
       
            
            foreach (var student in students)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(student.Key.ToString());
                sb.Append(" :   ");
             
                for (int i = 0; i < student.Value.Count; i++)
                {
                    sb.Append(student.Value[i]);
                    if (i != student.Value.Count - 1)
                    {
                        sb.Append(" ");
                    }
                }
                lblxstudents.Items.Add(sb);
                lblxstudents.SetSelected(0, true);
                Display();
            }
        }
        
        private void Display()
        {
            try
            { 
                txtAverage.Text = Math.Round(students.Values.ElementAt(lblxstudents.SelectedIndex).Average()).ToString();
                txtScoreCount.Text = students.Values.ElementAt(lblxstudents.SelectedIndex).Count().ToString();
                txtScoreTotal.Text = students.Values.ElementAt(lblxstudents.SelectedIndex).Sum().ToString();
            }
            
            catch (Exception)
            {
                txtAverage.Text = "";
                txtScoreCount.Text = "";
                txtScoreTotal.Text = "";
            }
        }

        private void lbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Display();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
       
            this.Close();
        }
    }
}