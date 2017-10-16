namespace Demo01_ObjectOverrides
{
    /// <summary>
    /// Only equals overriden
    /// </summary>
    public class Productv2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is Productv2))
            {
                // Nothing to look here, obj isn't even of type "Product"!
                return false;
            }
            
            // If they have the same id, they are the same product.
            return this.Id == ((Productv2)obj).Id;
        }

      
    }
}