
namespace UI.Web
{

    //Esta clase servirá para colocar los métodos que serán reutilizados en cada página web
    public partial class ApplicationWebForm : System.Web.UI.Page
    {
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }


        //Propiedad que contenga el ID seleccionado actualmente
        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }

                else
                {
                    return 0;
                }
            }

            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        
        //Propiedad que indica si hay un ID seleccionado
        protected bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected virtual void LoadForm(int id)
        {

        }

        protected virtual void CleanForm()
        {

        }


        protected virtual void EnableForm(bool enable)
        {

        }


        protected virtual void OcultaAcciones(string tipoPersona)
        {

        }

        protected virtual void OcultaBotones()
        {

        }


        protected virtual void OcultaValidaciones()
        {

        }

        protected virtual void HabilitaValidaciones()
        {

        }


    }
}