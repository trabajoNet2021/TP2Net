using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class ProfesorAdapter : Adapter
    {

        public List<DocenteCurso> GetProCurPer()
        {
            List<DocenteCurso> proCurPer = new List<DocenteCurso>();

            try
            {
                SqlCommand cmdProCurPer = new SqlCommand("SELECT TOP (1000) per.nombre, per.apellido, pro.id_dictado, "
                + "pro.cargo, cur.desc_curso FROM[AcademiaNet].[dbo].[Personas] AS per "
                + "INNER JOIN[AcademiaNet].[dbo].[Profesores] AS pro ON(per.id_persona = pro.id_docente) "
                + "INNER JOIN[AcademiaNet].[dbo].[Cursos] AS cur ON(pro.id_curso = cur.id_curso)", SqlConnection);
                this.OpenConnection();
                SqlDataReader drProCurPer = cmdProCurPer.ExecuteReader();

                while (drProCurPer.Read())
                {
                    DocenteCurso pro = new DocenteCurso();
                    pro.ID = (int)drProCurPer["id_dictado"];
                    pro.Nombre = (string)drProCurPer["nombre"];
                    pro.Apellido = (string)drProCurPer["apellido"];
                    pro.Cargo = (string)drProCurPer["cargo"];
                    pro.Curso = (string)drProCurPer["desc_curso"];
                    proCurPer.Add(pro);
                }

                drProCurPer.Close();

            }

            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return proCurPer;
        }
        public List<DocenteCurso> GetAll()
        {

            List<DocenteCurso> profesores = new List<DocenteCurso>();

            try
            {
                SqlCommand cmdProfesores = new SqlCommand("SELECT * FROM Profesores", SqlConnection);

                this.OpenConnection();
                SqlDataReader drProfesores = cmdProfesores.ExecuteReader();

                while (drProfesores.Read())
                {
                    DocenteCurso pro = new DocenteCurso();

                    pro.ID = (int)drProfesores["id_dictado"];
                    pro.IdCurso = (int)drProfesores["id_curso"];
                    pro.IdDocente = (int)drProfesores["id_docente"];
                    pro.Cargo = (string)drProfesores["cargo"];

                    profesores.Add(pro);

                }

                drProfesores.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return profesores;
        }
        public DocenteCurso GetOne(int ID)
        {

            DocenteCurso pro = new DocenteCurso();

            try
            {
                SqlCommand cmdProfesores = new SqlCommand("SELECT * FROM Profesores WHERE id_dictado = @id", SqlConnection);
                cmdProfesores.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                SqlDataReader drProfesores = cmdProfesores.ExecuteReader();

                if (drProfesores.Read())
                {
                    pro.ID = (int)drProfesores["id_dictado"];
                    pro.IdCurso = (int)drProfesores["id_curso"];
                    pro.IdDocente = (int)drProfesores["id_docente"];
                    pro.Cargo = (string)drProfesores["cargo"];
                }
                drProfesores.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de profesor", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return pro;
        }
        public void Delete(int ID)
        {

            try
            {
                
                SqlCommand cmdDelete = new SqlCommand("DELETE Profesores WHERE id_dictado = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el profesor", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(DocenteCurso profesor)
        {
            if (profesor.State == BusinessEntity.States.Deleted)
            {
                this.Delete(profesor.ID);
            }
            else if (profesor.State == BusinessEntity.States.New)
            {
                this.Insert(profesor);
            }
            else if (profesor.State == BusinessEntity.States.Modified)
            {
                this.Update(profesor);
            }
            profesor.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(DocenteCurso profesor)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Profesores SET  id_curso = @id_curso, id_docente = @id_docente, cargo = @cargo " +
                    "WHERE id_dictado = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = profesor.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = profesor.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = profesor.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = profesor.Cargo;
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos del profesor", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        protected void Insert(DocenteCurso profesor)
        {
            try
            {

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Profesores (id_curso, id_docente, cargo) " +
                    "VALUES (@id_curso,@id_docente, @cargo) " +
                    "SELECT @@identity",
                    SqlConnection);


                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = profesor.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = profesor.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = profesor.Cargo;
                this.OpenConnection();
                profesor.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());




            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al crear profesor", Ex);
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