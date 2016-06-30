using System.Collections.Generic;
using System.ComponentModel;

namespace DataTemplates
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IEnumerable<Thing> _items;

        public MainPageViewModel()
        {
            Items = new Thing[]
            {
                new BlueThing { Text = "I'm blue, dabadee dabadi" },
                new RedThing { Text = "Red, red wine" }
            };
        }

        public IEnumerable<Thing> Items
        {
            get { return _items; }
            set
            {
                if (_items == value)
                {
                    return;
                }

                _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
