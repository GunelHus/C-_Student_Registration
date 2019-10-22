using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseApplication.Models;
using System.Data.SqlClient;

namespace CourseApplication.DAL
{
    class StudentDTO: Base
    {
        public List<Student> GetAll()
        {
            _conn.Open();

            string query = @"SELECT Students.*, g.*, Classrooms.* FROM Students
                            INNER JOIN Groups AS g ON Students.GroupId = g.Id
                            INNER JOIN Classrooms ON g.ClasroomId = Classrooms.Id";

            SqlCommand command = new SqlCommand(query, _conn);
            SqlDataReader reader = command.ExecuteReader();

            List<Student> students = new List<Student>();

            while (reader.Read())
            {

                Classroom cl = new Classroom
                {
                    Id = reader.GetInt32(8),
                    Name = reader.GetString(9),
                    Capacity = reader.GetInt32(10)
                };

                Group g = new Group
                {

                    Id = reader.GetInt32(5),
                    Name = reader.GetString(6),
                    ClassromId = reader.GetInt32(7),
                    Classroom = cl
                };

                Student s = new Student()
                {
                    Id = reader.GetInt32(0),
                    Firstname = reader.GetString(1),
                    Lastname = reader.GetString(2),
                    Email = reader.GetString(3),
                    GroupId = reader.GetInt32(4),
                    Group = g

                };

                students.Add(s);

            }

            _conn.Close();

            return students;
        }
    }
}

