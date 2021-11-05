using System;
using System.Collections.Generic;
using Business.Entities;
using Util;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        PlanAdapter PlanData;

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            try
            {
                List<Plan> planes = PlanData.GetAll();
                return planes;
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
        }
        public List<Plan> GetPlanesEspecialidad()
        {
            try
            {
                List<Plan> planes = PlanData.GetPlanesEspecialidad();
                return planes;
            }

            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar lista de planes con " +
                    "especialidades", Ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public Plan GetOne(int id)
        {
            try
            {
                Plan plan = PlanData.GetOne(id);
                return plan;
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de planes", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }

        }
        public void Delete(int id)
        {
            try
            {
                PlanData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el plan", ex);
                Logger.WriteLog(excepcionManejada.ToString());
                throw excepcionManejada;
            }
            
        }
        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }



    }
}