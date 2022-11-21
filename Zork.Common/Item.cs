namespace Zork.Common
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }

        public string HeldDescription { get; }

        public Item(string name, string description, string heldDescription)
        {
            Name = name;
            Description = description;
            HeldDescription = heldDescription;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
