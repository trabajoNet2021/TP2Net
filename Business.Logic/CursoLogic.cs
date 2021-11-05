using System.Collections.Generic;
using Data.Database;
using Business.Entities;
using Util;
using System;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        CursoAdapter CursoData;

        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }
        public List<Curso> GetCursoMateriaCom()
        {
            try
            {
                List<Curso> curMatCom = CursoData.GetCursoMateriaCom();
                return curMatCom;
            }

            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar la lista de cursos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

        }
        public List<Curso> GetAll()
        {
            try
            {
                List<Curso> cursos = CursoData.GetAll();
                return cursos;
            }

            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar la lista de cursos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

        }
        public Curso GetOne(int id)
        {
            try
            {
                Curso curso = CursoData.GetOne(id);
                return curso;
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de curso", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public void Delete(int id)
        {
            try
            {
                CursoData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el curso", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }

    }
}