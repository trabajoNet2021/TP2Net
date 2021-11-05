using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {

        public List<Plan> GetPlanesEspecialidad()
        {
            List<Plan> planesEspecialidad = new List<Plan>();

            try
            {
                SqlCommand cmdPlanesEspecialidad = new SqlCommand("SELECT TOP (1000) esp.desc_especialidad, "
  + "pla.id_plan, pla.descripcion FROM[AcademiaNet].[dbo].[Especialidades] AS esp " +
  "INNER JOIN[AcademiaNet].[dbo].[Planes] AS pla ON(esp.id_especialidad = pla.id_especialidad)", SqlConnection);
                this.OpenConnection();
                SqlDataReader drPlanesEspecialidad = cmdPlanesEspecialidad.ExecuteReader();

                while(drPlanesEspecialidad.Read())
                {
                    Plan pla = new Plan();
                    pla.ID = (int)drPlanesEspecialidad["id_plan"];
                    pla.Descripcion = (string)drPlanesEspecialidad["descripcion"];
                    pla.DescripcionEspecialidad = (string)drPlanesEspecialidad["desc_especialidad"];
                    planesEspecialidad.Add(pla);
                }
                drPlanesEspecialidad.Close();

            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de planes con " +
                    "especialidades", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planesEspecialidad;
        }

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM Planes", SqlConnection);
                this.OpenConnection();
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan pln = new Plan();
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    pln.Descripcion = (string)drPlanes["descripcion"];
                    planes.Add(pln);

                }

                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan pln = new Plan();

            try
            {
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM Planes WHERE id_plan = @id", SqlConnection);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    pln.Descripcion = (string)drPlanes["descripcion"];
                }
                drPlanes.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de planes", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return pln;
        }

        public void Delete(int ID)
        {

            try
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE Planes WHERE id_plan = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el plan", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Plan plan)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Planes SET id_especialidad = @id_especialidad, descripcion = @descripcion  " +
                    "WHERE id_plan = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos del plan", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Plan plan)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Planes (id_especialidad, descripcion) " +
                    "VALUES (@id_especialidad, @descripcion) " +
                    "SELECT @@identity",
                    SqlConnection);


                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                this.OpenConnection();
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());


            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al crear plan", Ex);
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