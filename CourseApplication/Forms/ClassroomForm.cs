using CourseApplication.DAL;
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
    public partial class ClassroomForm : Form
    {
        ClassroomDTO dto;
        public ClassroomForm()
        {
            InitializeComponent();
            dto = new ClassroomDTO();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Classroom c = new Classroom();
            c.Name = txtClassroomName.Text;
            c.Capacity = (int)numericCapacity.Value;
            if (dto.Create(c))
            {
                MessageBox.Show("Created");
            }else
            {
                MessageBox.Show("Not Created");
            }

        }
    }
}
