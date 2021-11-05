using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter:Adapter
    {
        public List<AlumnoInscripcion> GetAlumnosPersonas()
        {
            List<AlumnoInscripcion> alumnosPersonas = new List<AlumnoInscripcion>();

            try
            {
                SqlCommand cmdAlumnosPersonas = new SqlCommand("SELECT TOP (1000) per.nombre, " +
  "per.apellido, alu.id_inscripcion, alu.id_alumno, alu.id_curso, alu.condicion, alu.nota " +
  "FROM[AcademiaNet].[dbo].[Personas] AS per INNER JOIN[AcademiaNet].[dbo].[Alumnos_inscripciones] " +
  "AS alu ON(per.id_persona = alu.id_alumno)", SqlConnection);
                this.OpenConnection();
                SqlDataReader drAlumnosPersonas = cmdAlumnosPersonas.ExecuteReader();

                while(drAlumnosPersonas.Read())
                {
                    AlumnoInscripcion alu = new AlumnoInscripcion();
                    alu.ID = (int)drAlumnosPersonas["id_inscripcion"];
                    alu.IdAlumno = (int)drAlumnosPersonas["id_alumno"];
                    alu.IdCurso = (int)drAlumnosPersonas["id_curso"];
                    alu.Nota = (int)drAlumnosPersonas["nota"];
                    alu.Condicion = (string)drAlumnosPersonas["condicion"];
                    alu.Nombre = (string)drAlumnosPersonas["nombre"];
                    alu.Apellido = (string)drAlumnosPersonas["apellido"];
                    alumnosPersonas.Add(alu);
                }

                drAlumnosPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return alumnosPersonas;
        }
        public List<AlumnoInscripcion> GetAll()
        {

            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();
            
            try
            {
                SqlCommand cmdAlumnos = new SqlCommand("SELECT * FROM Alumnos_inscripciones", SqlConnection);
                this.OpenConnection();
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripcion alu = new AlumnoInscripcion();

                    alu.ID = (int)drAlumnos["id_inscripcion"];
                    alu.IdAlumno = (int)drAlumnos["id_alumno"];
                    alu.IdCurso = (int)drAlumnos["id_curso"];
                    alu.Nota = (int)drAlumnos["nota"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                    alumnos.Add(alu);
                }


                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            
            return alumnos;
        }
        public AlumnoInscripcion GetOne(int ID)
        {

            AlumnoInscripcion alu = new AlumnoInscripcion();

            try
            {
                
                SqlCommand cmdAlumnos = new SqlCommand("SELECT * FROM Alumnos_inscripciones WHERE id_inscripcion = @id", SqlConnection);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                if (drAlumnos.Read())
                {
                    alu.ID = (int)drAlumnos["id_inscripcion"];
                    alu.IdAlumno = (int)drAlumnos["id_alumno"];
                    alu.IdCurso = (int)drAlumnos["id_curso"];
                    alu.Nota = (int)drAlumnos["nota"];
                    alu.Condicion = (string)drAlumnos["condicion"];
                }

                drAlumnos.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos del alumno", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return alu;
        }
        public void Delete(int ID)
        {

            try
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE Alumnos_inscripciones WHERE id_inscripcion = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el alumno", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(AlumnoInscripcion alu)
        {
            if (alu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alu.ID);
            }
            else if (alu.State == BusinessEntity.States.New)
            {
                this.Insert(alu);
            }
            else if (alu.State == BusinessEntity.States.Modified)
            {
                this.Update(alu);
            }
            alu.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(AlumnoInscripcion alu)
        {
            try
            {
                
                SqlCommand cmdSave = new SqlCommand("UPDATE Alumnos_inscripciones SET " +
                    "id_curso = @id_curso, nota = @nota, " +
                    "condicion = @condicion, id_alumno = @id_alumno WHERE id_inscripcion = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alu.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alu.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alu.IdCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alu.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alu.Condicion;

                this.OpenConnection();
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos del alumno", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        protected void Insert(AlumnoInscripcion alu)
        {
            try
            {

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Alumnos_inscripciones (id_curso, nota, condicion, id_alumno) " +
                    "VALUES (@id_curso, @nota, @condicion, @id_alumno) " +
                    "SELECT @@identity",    
                    SqlConnection);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alu.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alu.IdCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alu.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alu.Condicion;
                this.OpenConnection();
                alu.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el alumno", Ex);
                Logger.WriteLog(ExcepcionManejada.ToString());
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

    }
}
