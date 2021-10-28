using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp
{
    public partial class teacherform : Form
    {
        List<User> Users = new List<User>();
        User Self = new User();

        public teacherform(List<User> registeredusers, User self)
        {
            InitializeComponent();
            this.Users = registeredusers;
            this.Self = self;
        }

        XmlDocument xmlcourses = new XmlDocument();
        Course Course = new Course();
        private void teacher_form_Load(object sender, EventArgs e)
        {
        name1.Text = Self.username + " " + Self.lastname + " " + Self.course;
        }

        public User FSudById(int id)
        {
            foreach (User user in Users)
                if (user.id == id)
                    return user;
            return null;
        }
        public void loadCourses()
        {
            Course.name = Self.course;
            Course.teacher = Self;
            Course.grades.Clear();
            xmlcourses.Load("../../CourseList.xml");

            foreach (XmlNode course in xmlcourses.SelectSingleNode("Courses").ChildNodes)
            {
                try
                {
                    if (course.SelectSingleNode("name").InnerText == Course.name)
                    {
                        foreach (XmlNode studentid in course.SelectSingleNode("Students").ChildNodes)
                        {
                            User student = FSudById(int.Parse(studentid.InnerText));
                            Course.students.Add(student);
                        }
                        foreach (XmlNode gr in course.SelectSingleNode("Grades").ChildNodes)
                        {
                            Grade grade = new Grade();
                            grade.date = gr.SelectSingleNode("date").InnerText;
                            grade.mark = int.Parse(gr.SelectSingleNode("mark").InnerText);
                            grade.studentid = int.Parse(gr.SelectSingleNode("studentid").InnerText);

                            Course.grades.Add(grade);
                        }
                    }

                }
                catch
                {

                }
            }
        }

    }
}
