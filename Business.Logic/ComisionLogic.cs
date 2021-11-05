using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;
using Util;

namespace Business.Logic
{
    public class ComisionLogic: BusinessLogic
    {
        ComisionAdapter comisionData;

        public ComisionLogic()
        {
            comisionData = new ComisionAdapter();
        }
        public List<Comision> GetAll()
        {
            try
            {
                List<Comision> comisiones = comisionData.GetAll();
                return comisiones;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

        }
        public Comision GetOne(int id)
        {
            try
            {
                Comision com = comisionData.GetOne(id);
                return com;
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de la comision", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public void Delete(int id)
        {
            try
            {
                comisionData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar la comision", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }
        public void Save(Comision com)
        {
            comisionData.Save(com);
        }


    }
}
