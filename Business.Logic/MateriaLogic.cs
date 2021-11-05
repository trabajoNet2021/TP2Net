using System.Collections.Generic;
using Data.Database;
using Business.Entities;
using Util;
using System;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        MateriaAdapter MateriaData;


        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }
        public List<Materia> GetAll()
        {
            try
            {
                List<Materia> materias = MateriaData.GetAll();
                return materias;
            }

            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public Materia GetOne(int id)
        {
            try
            {
                Materia materia = MateriaData.GetOne(id);
                return materia;
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de materia", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public void Delete(int id)
        {
            try
            {
                MateriaData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar la materia", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }
        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }


    }
}