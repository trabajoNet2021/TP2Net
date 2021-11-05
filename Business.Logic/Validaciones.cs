using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Business.Entities;

namespace Business.Logic
{
    public static class Validaciones
    {

        //Método para validar emails
        public static bool IsMailValue(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        //Método para validar campos vacíos
        public static bool IsFieldEmpty(string cadena)
        {
            bool bandera = true;
            if (Regex.IsMatch(cadena, "^$"))
            {
                bandera = false;
            }
            
            return bandera;
        }


        //Método para validar una nota para AlumnosInscripcion
        public static bool IsScoreValid(string cadena)
        {
            int nota;
            nota = int.Parse(cadena);

            if(nota >= 1 && nota <= 10)
            {
                return true;
            }

            return false;
        }


        //Valida que existan especialidades en la base de datos
        public static bool ExisteEspecialidad()
        {
            EspecialidadLogic eLogic = new EspecialidadLogic();
            List<Especialidad> especialidades = eLogic.GetAll();

            if (especialidades.Count == 0)
            {
                return false;
            }

            return true;
        }


        //Valida que existan planes en la base de datos
        public static bool ExistePlan()
        {
            PlanLogic pLogic = new PlanLogic();
            List<Plan> planes = pLogic.GetAll();

            if(planes.Count == 0)
            {
                return false;
            }

            return true;
        }


        //Valida que existan personas en la base de datos
        public static bool ExistePersona()
        {
            PersonaLogic pLogic = new PersonaLogic();
            List<Persona> personas = pLogic.GetAll();
            
            if(personas.Count == 0)
            {
                return false;
            }

            return true;
        }
        

        public static bool ValidaNumero(string cadena)
        {
            Regex rx = new Regex(@"[\d]");

            if(rx.IsMatch(cadena))
            {
                return true;
            }

            else
            {
                return false;
            }
        }


        //Al inscribirse un alumno a un curso, se debe disminuir el cupo
        public static void DisminuyeCupo(string numCurso)
        {
            CursoLogic cLogic = new CursoLogic();
            Curso cur = cLogic.GetOne(int.Parse(numCurso));
            cur.Cupo = cur.Cupo - 1;
            cur.State = BusinessEntity.States.Modified;
            cLogic.Save(cur);
        }


        //Al desuscribirse un alumno de un curso, se debe aumentar el cupo
        public static void AumentaCupo(string numCurso)
        {
            CursoLogic cLogic = new CursoLogic();
            Curso cur = cLogic.GetOne(int.Parse(numCurso));
            cur.Cupo = cur.Cupo + 1;
            cur.State = BusinessEntity.States.Modified;
            cLogic.Save(cur);
        }



    }
}
