using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;
using Util;

namespace Business.Logic
{
    public class ProfesorLogic : BusinessLogic
    {
        ProfesorAdapter profesorData;

        public ProfesorLogic()
        {
            profesorData = new ProfesorAdapter();
        }

        public List<DocenteCurso> GetProCurPer()
        {
            try
            {
                List<DocenteCurso> proCurPer = profesorData.GetProCurPer();
                return proCurPer;
            }

            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }

        public List<DocenteCurso> GetAll()
        {
            try
            {
                List<DocenteCurso> profesores = profesorData.GetAll();
                return profesores;
            }

            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }

        public DocenteCurso GetOne(int id)
        {
            try
            {
                DocenteCurso dc = profesorData.GetOne(id);
                return dc;
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de profesor", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }

        public void Delete(int id)
        {
            try
            {
                profesorData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el profesor", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }

        public void Save(DocenteCurso profesor)
        {
            profesorData.Save(profesor);
        }



        static void Main(string[] args)
        {

        }
    }
}