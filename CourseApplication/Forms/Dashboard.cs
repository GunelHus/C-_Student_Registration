﻿using CourseApplication.DAL;
using CourseApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseApplication.Forms
{
    public partial class Dashboard : Form
    {
        private StudentDTO studentDTO;
        public Dashboard()
        {
            InitializeComponent();
            studentDTO = new StudentDTO();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            FillStudents();
        }

        public void FillStudents()
        {
          List<Student> students = studentDTO.GetAll();
            foreach (Student item in students)
            {
                dgvStudents.Rows.Add(
                    item.Id,
                    item.Firstname,
                    item.Lastname,
                    item.Group.Name,
                    item.Group.Classroom.Name
                    );
            }
        }

        

        private void ClasroomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassroomForm form = new ClassroomForm();
            form.ShowDialog();
        }
    }
}
