namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        private int _id;
        private string _name;
        private int _quantity;
        private int _mg;

        public Medicine ()
        {

        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int Mg { get => _mg; set => _mg = value; }
    }
}
