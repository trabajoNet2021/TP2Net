using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class EspecialidadAdapter: Adapter
    {

        public List<Especialidad> GetAll()
        {

            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM Especialidades", SqlConnection);
                this.OpenConnection();
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidades.Add(esp);

                }

                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return especialidades;
        }
        public void Save(Especialidad esp)
        {
            if (esp.State == BusinessEntity.States.Deleted)
            {
                this.Delete(esp.ID);
            }
            else if (esp.State == BusinessEntity.States.New)
            {
                this.Insert(esp);
            }
            else if (esp.State == BusinessEntity.States.Modified)
            {
                this.Update(esp);
            }
            esp.State = BusinessEntity.States.Unmodified;
        }
        public void Delete(int ID)
        {
            try
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE Especialidades WHERE id_especialidad = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar la especialidad", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        protected void Update(Especialidad esp)
        {
            try
            {
                

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Especialidades SET desc_especialidad = @desc_especialidad " +
                    "WHERE id_especialidad = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = esp.ID;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.Descripcion;
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos de la especialidad", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public Especialidad GetOne(int ID)
        {

            Especialidad esp = new Especialidad();

            try
            {
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM Especialidades WHERE id_especialidad = @id", SqlConnection);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }

                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de especialidad", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return esp;
        }

        protected void Insert(Especialidad esp)
        {
            try
            {
                

                SqlCommand cmdSave = new SqlCommand("INSERT INTO Especialidades (desc_especialidad) " +
                    "VALUES (@desc_especialidad) " +
                    "SELECT @@identity",
                    SqlConnection);

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.Descripcion;
                this.OpenConnection();
                esp.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al crear la especialidad", Ex);
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
