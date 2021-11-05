using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;
using Util;

namespace Business.Logic
{
    public class EspecialidadLogic
    {
        private EspecialidadAdapter especialidadData;

        public EspecialidadLogic()
        {
            especialidadData = new EspecialidadAdapter();
        }
        public List<Especialidad> GetAll()
        {
            try
            {
                List<Especialidad> especialidades = especialidadData.GetAll();
                return especialidades;
            }

            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public Especialidad GetOne(int id)
        {
            try
            {
                Especialidad esp = especialidadData.GetOne(id);
                return esp;
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de especialidad", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public void Save(Especialidad especialidad)
        {
            especialidadData.Save(especialidad);
        }
        public void Delete(int id)
        {
            try
            {
                especialidadData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar la especialidad", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }

    }
}
