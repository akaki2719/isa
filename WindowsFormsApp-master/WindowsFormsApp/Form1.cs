﻿using System;
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
    public partial class Form1 : Form
    {
        XmlDocument XmlDocument = new XmlDocument();
        XmlDocument Xmlcourses = new XmlDocument();
        int lastId = 0;
        List<User> registeredUsers = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }

        public void loadRegisteredUsers()
        {
            XmlDocument.Load("../../UserList.xml");
            Xmlcourses.Load("../../Course.xml");

            foreach (XmlNode user in XmlDocument.SelectSingleNode("Users").ChildNodes)
            {
                try
                {
                    User registeredUser = new User();
                    registeredUser.id = int.Parse(user.SelectSingleNode("id").InnerText);
                    lastId = registeredUser.id;
                    registeredUser.username = user.SelectSingleNode("username").InnerText;
                    registeredUser.password = user.SelectSingleNode("password").InnerText;
                    registeredUser.role = user.SelectSingleNode("role").InnerText;
                    registeredUser.course = user.SelectSingleNode("Course").InnerText;
                    registeredUsers.Add(registeredUser);
                }
                catch
                {

                }
            }
        }


        private void login_button_Click(object sender, EventArgs e)
        {
            bool success = false;
            foreach (User user in registeredUsers)
            {
                if (user.username == usernameLogin.Text && user.password == passwordLogin.Text)
                {
                    responseLogin.ForeColor = Color.Brown;
                    responseLogin.Text = "Response: Log In Successful. ID - " + user.id;
                    success = true;
                    if (user.role == "teacher")
                    {
                        teacherform teacherform = new teacherform(registeredUsers, user);
                        this.Hide();
                        teacherform.ShowDialog();
                        this.Show();
                    }

                }
            }
            if (!success)
            {
                responseLogin.ForeColor = Color.Red;
                responseLogin.Text = "Response: Could not log in";
            }
            responseLogin.Show();
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            bool success = true;
            foreach (User user in registeredUsers)
            {
                if (user.username == registerusername.Text)
                {
                    responseRegister.Text = "Response: Username already taken";
                    success = false;
                    break;
                }
            }
            if (passwordRegister.Text != confirmPasswordRegister.Text)
            {
                responseRegister.Text = "Response: Passwords do not match";
                success = false;
            }
            if (confirmPasswordRegister.Text == string.Empty || passwordRegister.Text == string.Empty || registerusername.Text == string.Empty || nameRegister.Text == string.Empty || lastnameRegister.Text == string.Empty)
            {
                responseRegister.Text = "Response: Some fields are not filled";
                success = false;
            }
            if (success)
            {
                responseRegister.Show();

                XmlNode newUser = XmlDocument.CreateElement("user");

                XmlNode newUserId = XmlDocument.CreateElement("id");
                newUserId.InnerText = (lastId + 1).ToString();
                newUser.AppendChild(newUserId);

                XmlNode newUsername = XmlDocument.CreateElement("username");
                newUsername.InnerText = registerusername.Text;
                newUser.AppendChild(newUsername);

                XmlNode newName = XmlDocument.CreateElement("name");
                newName.InnerText = nameRegister.Text;
                newUser.AppendChild(newName);

                XmlNode newLastname = XmlDocument.CreateElement("lastname");
                newLastname.InnerText = lastnameRegister.Text;
                newUser.AppendChild(newLastname);

                XmlNode newPassword = XmlDocument.CreateElement("password");
                newPassword.InnerText = passwordRegister.Text;
                newUser.AppendChild(newPassword);

                XmlNode newRole = XmlDocument.CreateElement("role");
                newRole.InnerText = ComboBoxRegister.Text;
                newUser.AppendChild(newRole);

                XmlNode newCourse = XmlDocument.CreateElement("Course");
                newCourse.InnerText = ComboBoxCourse.Text;
                newUser.AppendChild(newCourse);

                XmlDocument.DocumentElement.AppendChild(newUser);
                XmlDocument.Save("../../UserList.xml");

                responseRegister.ForeColor = Color.Brown;
                responseRegister.Text = "Response: Registration completed";
                loadRegisteredUsers();

                if (ComboBoxCourse.Text == "Student")
                {
                    XmlNode studentid = Xmlcourses.CreateElement("studentid");
                    studentid.InnerText = (lastId + 1).ToString();
                    foreach (XmlNode course in Xmlcourses.DocumentElement.ChildNodes)
                    {
                        if (course.SelectSingleNode("name").InnerText == ComboBoxRegister.Text)
                        {
                            course.SelectSingleNode("Students").AppendChild(studentid);
                        }
                    }
                    Xmlcourses.Save("../../Course.xml");
                }
            }
            responseRegister.Show();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            passwordRegister.PasswordChar = '*';
            confirmPasswordRegister.PasswordChar = '*';
            passwordLogin.PasswordChar = '*';

            loadRegisteredUsers();
        }
    }
}
