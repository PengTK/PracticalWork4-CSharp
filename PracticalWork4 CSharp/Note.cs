using System;
using System.Collections.ObjectModel;

namespace PracticalWork4_CSharp
{
    internal class Note
    {
        public string name { get; }
        public string type { get; }
        public double money { get; }
        public DateTime date;

        public static ObservableCollection<Note> notes;

        public Note(string name, string type, double money, DateTime date)
        {
            this.name = name;
            this.type = type;
            this.money = money;
            this.date = date;
        }
    }
}
