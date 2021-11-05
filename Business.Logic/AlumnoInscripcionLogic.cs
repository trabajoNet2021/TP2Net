using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;
using Util;


namespace Business.Logic
{
    public class AlumnoInscripcionLogic: BusinessLogic
    {
        
        AlumnoInscripcionAdapter alumnoData;


        public AlumnoInscripcionLogic()
        {
            alumnoData = new AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAlumnosPersonas()
        {
            try
            {
                List<AlumnoInscripcion> alumnos = alumnoData.GetAlumnosPersonas();
                return alumnos;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }

        }

        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                List<AlumnoInscripcion> alumnos = alumnoData.GetAll();
                return alumnos;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                Logger.WriteLog(ExceptionManejada.ToString());
                throw ExceptionManejada;
            }
        }

        public AlumnoInscripcion GetOne(int id)
        {
            try
            {
                AlumnoInscripcion alumno = alumnoData.GetOne(id);
                return alumno;
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos del alumno", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }

        public void Save(AlumnoInscripcion alumno)
        {
            alumnoData.Save(alumno);
        }

        public void Delete(int id)
        {
            try
            {
                alumnoData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el alumno", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }
    }
}
