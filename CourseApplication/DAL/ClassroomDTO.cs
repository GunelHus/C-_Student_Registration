using CourseApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApplication.DAL
{
    class ClassroomDTO: Base
    {
        public List<Classroom> GetAll()
        {
            _conn.Open();

            string query = @"SELECT * FROM Classrooms";

            SqlCommand command = new SqlCommand(query, _conn);
            SqlDataReader reader = command.ExecuteReader();

            List<Classroom> classrooms = new List<Classroom>();

            while (reader.Read())
            {

                Classroom cl = new Classroom
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Capacity = reader.GetInt32(2)
                };

                

                classrooms.Add(cl);

            }

            _conn.Close();

            return classrooms;
        
        }

        public Classroom Get(int id)
        {
            _conn.Open();

            string query = @"SELECT * FROM Classrooms WHERE Classrooms.Id = @crid";

            SqlCommand command = new SqlCommand(query, _conn);
            command.Parameters.AddWithValue("@crid" , id);
            SqlDataReader reader = command.ExecuteReader();

            Classroom classroom = new Classroom();

            while (reader.Read())
            {
                classroom.Id = reader.GetInt32(0);
                classroom.Name = reader.GetString(1);
                classroom.Capacity = reader.GetInt32(2);
                

            }

            _conn.Close();

            return classroom;

        }

        public bool Create(Classroom cr)
        {
            _conn.Open();

            string query = @"INSERT INTO Classrooms(Name, Capacity) Values(@name , @capacity)";

            SqlCommand command = new SqlCommand(query, _conn);
            command.Parameters.AddWithValue("@name", cr.Name);
            command.Parameters.AddWithValue("@capacity", cr.Capacity);

            int rowAff = command.ExecuteNonQuery();

            _conn.Close();

            if (rowAff > 0)
            {
                return true;
            }
            return false;
        }

        public void Update(Classroom cr)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
