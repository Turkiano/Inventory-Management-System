

namespace InventoryManagement.src
{


    /*
    
[X] Create class `Item`
[x] which has a variable name (readonly)
[X] quantity, and 
[X] created date, which are private.
[X] Amount of each item cannot be negative. 




    */
    public class Item
    {
        private readonly string _name;
        private int _quantity;
        public int Quantity

        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Quanitiy can not be negative");

                }
                else
                {
                    _quantity = value;
                }
            }
        }
        private readonly DateTime _createdAt;


        //Contructor to take parameters of name, quantity, and created date (optional, if not set, it will be current date).
        public Item(string name, int quantity, DateTime createDate)
        {
            _name = name;
            _quantity = quantity;
            _createdAt = createDate;

        }

        public DateTime SetCreatedAt() //this is the set method for _CreatedBy
        {   //validation
            return _createdAt;
        }

        public string GetName() //this is the get method for _name
        {
            return _name;
        }

        public DateTime GetCreatedAt() //this is the get method for _CreatedBy
        {
            return _createdAt;
        }

        public int GetQuantity() //this is the get method for _quantity
        {
            return _quantity;
        }
    }
}