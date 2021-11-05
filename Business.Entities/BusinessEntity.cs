namespace Business.Entities
{
    public class BusinessEntity
    {
        States state;
        public BusinessEntity()
        {
            this.state = States.New;
        }


        public int ID { get; set; }


        public States State
        {
            get { return state; }
            set { state = value; }
        }


        public enum States
        {
            Deleted, 
            New, 
            Modified,
            Unmodified
        }

    }
}
