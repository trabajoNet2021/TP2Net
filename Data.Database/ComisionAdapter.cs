using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM Comisiones", SqlConnection);
                this.OpenConnection();
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();

                    com.IdPlan = (int)drComisiones["id_plan"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.ID = (int)drComisiones["id_comision"];
                    comisiones.Add(com);

                }

                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }
        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.New)
            {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }
        public void Delete(int id)
        {
            try
            {

                SqlCommand cmdDelete = new SqlCommand("DELETE Comisiones WHERE id_comision = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar la comision", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        protected void Update(Comision com)
        {
            try
            {

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Comisiones SET id_plan = @idPlan, desc_comision = @descripcion, anio_especialidad = @anioEspecialidad " +
                    "WHERE id_comision = @idComision", SqlConnection);

                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = com.IdPlan;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@anioEspecialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@idComision", SqlDbType.Int).Value = com.ID;
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos de la comision", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        public Comision GetOne(int idComision)
        {

            Comision com = new Comision();

            try
            {
                
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM Comisiones WHERE id_comision = @idComision", SqlConnection);
                cmdComisiones.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                this.OpenConnection();
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();


                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.IdPlan = (int)drComisiones["id_plan"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];

                }

                drComisiones.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de la comision", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return com;
        }
        protected void Insert(Comision com)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Comisiones (desc_comision, id_plan, anio_especialidad) " +
                    "VALUES (@descComision, @idPlan, @anioEspecialidad) "+
                    "SELECT @@identity", SqlConnection);

                cmdSave.Parameters.Add("@descComision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = com.IdPlan;
                cmdSave.Parameters.Add("@anioEspecialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                this.OpenConnection();
                com.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());


            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comisión", Ex);
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