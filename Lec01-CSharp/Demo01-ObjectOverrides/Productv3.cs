namespace Demo01_ObjectOverrides
{
    
    /// <summary>
    /// Proper implementation: Equals and GetHashCode overriden
    /// </summary>
    public class Productv3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override bool Equals(object obj)
        {
            // Shorter way to basically write the same thing from v2 implementation.
            // We use as operator to safely cast and then our good old elvis :)
            return Id == (obj as Productv3)?.Id;
        }

        public override int GetHashCode()
        {
            // If two products are equal, they will have the same hash code.
            // Two products are equal if their ID matches, so the easiest way to do this is 
            // just to return the Id.GetHashCode(). 
            return Id.GetHashCode();
        }
    }
    
    
    
}