using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {

        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM Personas", SqlConnection);
                this.OpenConnection();
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nacimiento"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.IdPlan = (int)drPersonas["id_plan"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Clave = (string)drPersonas["clave"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.TipoPersona = (string)drPersonas["tipo_persona"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    personas.Add(per);

                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return personas;
        }
        public Persona GetOne(int ID)
        {
            Persona per = new Persona();

            try
            {
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM Personas WHERE id_persona = @id", SqlConnection);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.IdPlan = (int)drPersonas["id_plan"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nacimiento"];
                    per.Clave = (string)drPersonas["clave"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.TipoPersona = (string)drPersonas["tipo_persona"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                }
                drPersonas.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de persona", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return per;
        }
        public void Delete(int ID)
        {

            try
            {
                SqlCommand cmdDelete = new SqlCommand("DELETE Personas WHERE id_persona = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                this.OpenConnection();
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar la persona", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(Persona per)
        {
            if (per.State == BusinessEntity.States.Deleted)
            {
                this.Delete(per.ID);
            }
            else if (per.State == BusinessEntity.States.New)
            {
                this.Insert(per);
            }
            else if (per.State == BusinessEntity.States.Modified)
            {
                this.Update(per);
            }
            per.State = BusinessEntity.States.Unmodified;
        }
        protected void Update(Persona per)
        {
            try
            {

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Personas SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email, " +
                    "telefono = @telefono, direccion = @direccion, fecha_nacimiento = @fecha_nacimiento, " +
                    "id_plan = @id_plan, legajo = @legajo, tipo_persona = @tipo_persona " +
                    "WHERE id_persona = @id", SqlConnection);
                

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = per.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = per.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = per.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = per.Telefono;
                cmdSave.Parameters.Add("@fecha_nacimiento", SqlDbType.DateTime).Value = per.FechaNacimiento;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = per.IdPlan;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = per.Legajo;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = per.Clave;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = per.NombreUsuario;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.VarChar, 50).Value = per.TipoPersona;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = per.Habilitado;
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception excepcionManejada = new Exception("Error al modificar datos de la persona", e);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        protected void Insert(Persona per)
        {

            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Personas (nombre, apellido, direccion, email, telefono, fecha_nacimiento, " +
                    "id_plan, legajo, clave, nombre_usuario, tipo_persona, habilitado) " +
                    "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nacimiento, " +
                    "@id_plan, @legajo, @clave, @nombre_usuario, @tipo_persona, @habilitado)" +
                    "SELECT @@identity",
                    SqlConnection);

                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = per.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = per.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = per.Telefono;
                cmdSave.Parameters.Add("@fecha_nacimiento", SqlDbType.DateTime).Value = per.FechaNacimiento;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = per.IdPlan;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = per.Legajo;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = per.Clave;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = per.NombreUsuario;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.VarChar, 50).Value = per.TipoPersona;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = per.Habilitado;
                this.OpenConnection();
                per.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al crear la persona", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
        public Persona GetByUser(string nombreUsuario, string clave)
        {
            Persona per = new Persona();
            try
            {
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM Personas WHERE nombre_usuario = @nombre_usuario AND clave = @clave", SqlConnection);
                cmdPersonas.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = nombreUsuario;
                cmdPersonas.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
                this.OpenConnection();
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.IdPlan = (int)drPersonas["id_plan"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nacimiento"];
                    per.Clave = (string)drPersonas["clave"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.TipoPersona = (string)drPersonas["tipo_persona"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                }
                else
                {
                    per = null;
                }

                drPersonas.Close();
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("No se encontro una persona con esos datos", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return per;
        }


        static void Main(String [] args)
        {

        }

    }
}