using System.ComponentModel;

namespace Zork.Common
{
    public class Item : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
