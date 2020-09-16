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
        //declare a dictionary that contain strings and lists that will store scores of the students.
        public static Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
        public static int selected;

        public frmStudentScores()
        {
            InitializeComponent();
        }

        private void frmStudentScores_Load(object sender, EventArgs e)
        {
            //default students that are in the list box when the program runs.
            students.Add("Joel Murach", new List<int> { 97, 71, 83 });
            students.Add("Doug Lowe", new List<int> { 99, 93, 97 });
            students.Add("Anne Boehm", new List<int> { 100, 100, 100 });
            addToListBox();
        }
        //user can add new student info.
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //display add new student form using showDiaglog.
            Form addNewStudent = new frmAddNewStudent();
            addNewStudent.ShowDialog();
            //clear the previous student information in the list box
            lbxStudents.Items.Clear();
            //add student info to student list box
            addToListBox();
        }
        //method where user can update student information
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form updateScores = new frmUpdateStudentScores();
            //selecting the index of the list box can update student information
            selected = lbxStudents.SelectedIndex;
            //if-else statment that checks for existing student data.
            if (lbxStudents.Items.Count > 0)
            {
                updateScores.ShowDialog();
            }
            else
            {
                MessageBox.Show("Student's information not in the data", "Error");
            }
            //clears the list box
            lbxStudents.Items.Clear();
            //add student to list box
            addToListBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //remove a student information in the student list box
            students.Remove(students.Keys.ElementAt(lbxStudents.SelectedIndex));
            lbxStudents.Items.Clear();
            addToListBox();
            //if the student list box is empty, then empty the socre total, count, and average text boxes. 
            if (students.Count == 0)
            {
                txtAverage.Text = "";
                txtScoreCount.Text = "";
                txtScoreTotal.Text = "";
            }
        }
        //method that add a student information to list box
        private void addToListBox()
        {
            //for each loop that is used to add each student to stringbuilder so it can be
            //stored as string
            foreach (var student in students)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(student.Key.ToString());
                sb.Append(" :   ");
                //use for loop to add student scores 
                for (int i = 0; i < student.Value.Count; i++)
                {
                    sb.Append(student.Value[i]);
                    if (i != student.Value.Count - 1)
                    {
                        sb.Append(" ");
                    }
                }
                lbxStudents.Items.Add(sb);
                lbxStudents.SetSelected(0, true);
                Display();
            }
        }
        //method that displays the vaule of the score total, count and average in the text boxes.
        private void Display()
        {
            try
            {
                //passes string value to each text box
                txtAverage.Text = Math.Round(students.Values.ElementAt(lbxStudents.SelectedIndex).Average()).ToString();
                txtScoreCount.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Count().ToString();
                txtScoreTotal.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Sum().ToString();
            }
            //catch any exception and empty the text boxes.
            catch (Exception)
            {
                txtAverage.Text = "";
                txtScoreCount.Text = "";
                txtScoreTotal.Text = "";
            }
        }

        private void lbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //display the student information in the list box using display method.
            Display();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }
    }
}