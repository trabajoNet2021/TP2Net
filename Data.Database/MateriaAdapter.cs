using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {

            List<Materia> materias = new List<Materia>();

            try
            {
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM Materias", SqlConnection);
                this.OpenConnection();
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mtr = new Materia();

                    mtr.ID = (int)drMaterias["id_materia"];
                    mtr.Descripcion = (string)drMaterias["desc_materia"];
                    mtr.HorasSemanales = (int)drMaterias["hs_semanales"];
                    mtr.HorasTotales = (int)drMaterias["hs_totales"];
                    mtr.IdPlan = (int)drMaterias["id_plan"];

                    materias.Add(mtr);

                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return materias;
        }
        public Materia GetOne(int ID)
        {
            Materia mtr = new Materia();

            try
            {
                
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM Materias WHERE id_materia = @id", SqlConnection);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;                
                this.OpenConnection();
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read())
                {
                    mtr.ID = (int)drMaterias["id_materia"];
                    mtr.Descripcion = (string)drMaterias["desc_materia"];
                    mtr.HorasSemanales = (int)drMaterias["hs_semanales"];
                    mtr.HorasTotales = (int)drMaterias["hs_totales"];
                    mtr.IdPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de materia", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return mtr;
        }
        public void Delete(int ID)
        {

            try
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE Materias WHERE id_materia = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar la materia", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(Materia materia)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Materias SET desc_materia = @descripcion, hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan  " +
                    "WHERE id_materia = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HorasSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HorasTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos de la materia", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        protected void Insert(Materia materia)
        {
            try
            {

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Materias (desc_materia, hs_semanales, hs_totales, id_plan) " +
                    "VALUES (@descripcion, @hs_semanales, @hs_totales, @id_plan) " +
                    "SELECT @@identity",
                    SqlConnection);

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HorasSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HorasTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                this.OpenConnection();
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al crear materia", Ex);
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