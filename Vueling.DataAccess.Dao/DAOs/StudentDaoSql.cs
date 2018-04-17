using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.CommonResources;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;
using System.Data.SqlClient;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoSql : IStudentDao
    {
        private readonly Logger logger = new Logger();

        //private readonly string conectionstring = "s"; //sql connexion string llegir de variable d'entorn codificada
        private readonly string conectionstring = "Data Source = AM-BCN-POR-378; Initial Catalog = StudentDB;" +
            "Trusted_Connection=yes; Integrated Security = SSPI";

        private SqlCommand cmd;
        private SqlConnection conn;

        private Student studentread;
        private List<Student> liststudents;

        public Student Add(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            string sql = "INSERT INTO dbo.StudentDB (Nombre, Apellidos, Dni, Edad, FechaNacimiento, HoraRegistro, Student_Guid)" +
                " VALUES (@Nombre, @Apellidos, @Dni, @Edad, @FechaNacimiento, @HoraRegistro, @Guid)";
            try
            {
                using (conn = new SqlConnection(conectionstring))
                {
                    using (cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Guid", student.Student_Guid.ToString());
                        cmd.Parameters.AddWithValue("@Nombre", student.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", student.Apellido);
                        cmd.Parameters.AddWithValue("@Edad", student.Edad);
                        cmd.Parameters.AddWithValue("@Dni", student.Dni);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", student.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@HoraRegistro", student.HoraRegistro);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT @@IDENTITY";

                        //studentread = SelectStudentByGuid(student.Student_Guid);
                        conn.Close();
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return studentread;
        }

        private Student SelectStudentByGuid(Guid studentguid)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {              
                // SELECT * FROM table WHERE guid is 
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return studentread;
        }

        public List<Student> ReadAll()
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            liststudents = new List<Student>();
            string sql = "SELECT * FROM Students";

            try
            {
                using (conn = new SqlConnection(conectionstring))
                {
                    using (cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Student st = new Student();
                                st.IdAlumno = (int)rdr["Id"];
                                st.Nombre = rdr["Nombre"].ToString();
                                st.Apellido = rdr["Apellidos"].ToString();
                                st.Edad = (int)rdr["Edad"];
                                st.Dni = rdr["Dni"].ToString();
                                st.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                                st.HoraRegistro = Convert.ToDateTime(rdr["HoraRegistro"]);
                                st.Student_Guid = (Guid)rdr["Student_Guid"];

                                liststudents.Add(st);
                            }

                        }
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return liststudents;
        }
    }
}
