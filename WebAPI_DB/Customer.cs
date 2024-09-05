namespace WebAPI_DB
{
    public class Customer
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerLocation { get; set; } = string.Empty;

        public virtual bool Equals(Customer? other)
        {
            if (other == null) return false;

            if(CustomerName == other.CustomerName && 
                CustomerLocation == other.CustomerLocation)
                return true;
            return false;
        }
    }
}
