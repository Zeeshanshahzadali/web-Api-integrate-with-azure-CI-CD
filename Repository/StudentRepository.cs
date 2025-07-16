using MyFirstApi.Models;
using System.Data.SqlClient;

namespace MyFirstApi.Repository
{
    public class StudentRepository
    {
        private readonly IConfiguration _configuration;
        public StudentRepository(IConfiguration configuration)
        {
            _configuration =  configuration;
        }

        public List<Student> Getll()
        {
            var students = new List<Student>();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    students.Add(new Student()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            return students;
        }

        public void AddStudent(Student student)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO Students (Name, Email) VALUES (@Name, @Email)";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name",student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(int id, Student student)
        {
            var connStr = _configuration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var query = "UPDATE Students SET Name = @Name, Email = @Email WHERE Id = @Id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            var connStr = _configuration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var query = "DELETE FROM Students WHERE Id = @Id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

    }

}
