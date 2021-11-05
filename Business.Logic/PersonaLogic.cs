using System.Collections.Generic;
using Data.Database;
using Business.Entities;
using Util;
using System;

namespace Business.Logic
{
    public class PersonaLogic: BusinessLogic
    {
        PersonaAdapter personaData;

        public PersonaLogic()
        {
            personaData = new PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            try
            {
                List<Persona> personas = personaData.GetAll();
                return personas;
            }

            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public Persona GetOne(int id)
        {
            try
            {
                Persona per = personaData.GetOne(id);
                return per;
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de persona", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public void Delete(int id)
        {
            try
            {
                personaData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de persona", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }
        public void Save(Persona per)
        {
            personaData.Save(per);
        }
        public Persona GetByUser(string usuario, string clave)
        {
            try
            {
                return personaData.GetByUser(usuario, clave);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("No se encontro una persona con esos datos", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }


    }
}
