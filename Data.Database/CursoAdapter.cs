using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {

        public List<Curso> GetCursoMateriaCom()
        {
            List<Curso> curMatCom = new List<Curso>();

            try
            {
                SqlCommand cmdCursoMatCom = new SqlCommand("SELECT TOP (1000) mat.desc_materia, com.desc_comision, cur.anio_calendario, " +
    "cur.cupo, cur.desc_curso, cur.id_curso FROM[AcademiaNet].[dbo].[Materias] AS mat " +
    "INNER JOIN[AcademiaNet].[dbo].[Cursos] AS cur ON(mat.id_materia = cur.id_materia) " +
    "INNER JOIN[AcademiaNet].[dbo].[Comisiones] AS com ON(cur.id_comision = com.id_comision) ", SqlConnection);
                this.OpenConnection();
                SqlDataReader drCursoMatCom = cmdCursoMatCom.ExecuteReader();
                
                while(drCursoMatCom.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursoMatCom["id_curso"];
                    cur.Descripcion = (string)drCursoMatCom["desc_curso"];
                    cur.Materia = (string)drCursoMatCom["desc_materia"];
                    cur.Comision = (string)drCursoMatCom["desc_comision"];
                    cur.AnioCalendario = (int)drCursoMatCom["anio_calendario"];
                    cur.Cupo = (int)drCursoMatCom["cupo"];
                    curMatCom.Add(cur);
                }

                drCursoMatCom.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar la lista de cursos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return curMatCom;


        }
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {

                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM Cursos", SqlConnection);
                this.OpenConnection();
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (string)drCursos["desc_curso"];
                    cursos.Add(cur);

                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar la lista de cursos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }
        public Curso GetOne(int ID)
        {

            Curso cur = new Curso();

            try
            {
                
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM Cursos WHERE id_curso = @id", SqlConnection);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (String)drCursos["desc_curso"];
                }
                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de curso", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return cur;
        }


        public void Delete(int ID)
        {

            try
            {
                
                SqlCommand cmdDelete = new SqlCommand("DELETE Cursos WHERE id_curso = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el curso", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }


        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }


        protected void Update(Curso curso)
        {
            try
            {

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Cursos SET id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo, desc_curso = @descripcion " +
                    "WHERE id_curso = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos del curso", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }


        protected void Insert(Curso curso)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Cursos (id_materia, id_comision, anio_calendario, cupo, desc_curso) " +
                    "VALUES (@id_materia, @id_comision, @anio_calendario, @cupo, @descripcion) " +
                    "SELECT @@identity",
                    SqlConnection);

                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;

                this.OpenConnection();
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al crear curso", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

    }
}