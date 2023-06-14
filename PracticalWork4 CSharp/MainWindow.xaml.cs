using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalWork4_CSharp
{

    public partial class MainWindow : Window
    {
        int idSelected;
        List<Note> notes;
        List<Note> selectedNotes = new List<Note>();
        List<string> types = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            notes = SaveLoad.Load();
            DatePicker.Text = DateTime.Now.ToString();
            
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(DatePicker.Text);
            List<string> noteNames = new List<string>();
            foreach (Note note in notes)
            {
                if (note.date == date)
                {
                    selectedNotes.Add(note);
                    noteNames.Add(note.name);
                }
            }
            Menu.ItemsSource = noteNames;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < notes.Count; i++)
            {

                if (Menu.SelectedItem == notes[i].name)
                {
                    NameBox.Text = notes[i].name;
                    comboBox.Text = notes[i].type;
                    SumBox.Text = notes[i].money.ToString();
                    idSelected = i;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            notes.RemoveAt(idSelected);
            UpDate();
            SaveLoad.Save(notes);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            notes.Add(new Note(NameBox.Text, comboBox.Text, Convert.ToDouble(SumBox.Text), Convert.ToDateTime(DatePicker.Text)));
            UpDate();
            SaveLoad.Save(notes);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            notes.RemoveAt(idSelected);
            notes.Add(new Note(NameBox.Text, comboBox.Text, Convert.ToDouble(SumBox.Text), Convert.ToDateTime(DatePicker.Text)));
            UpDate();
            SaveLoad.Save(notes);
        }

        private void UpDate()
        {
            DateTime date = Convert.ToDateTime(DatePicker.Text);
            List<string> noteNames = new List<string>();
            foreach (Note note in notes)
            {
                if (note.date == date)
                {
                    selectedNotes.Add(note);
                    noteNames.Add(note.name);
                }
            }
            Menu.ItemsSource = noteNames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow dialog = new DialogWindow();
            if (dialog.ShowDialog() == true)
            {
                int c = 0;
                foreach (string type in types)
                {
                    if (type == dialog.textReturn) { c++; }
                }
                if (c == 0)
                {
                    types.Add(dialog.textReturn);
                }
                comboBox.ItemsSource = types;
            }
            else
            {
                MessageBox.Show("Тема не была добавлена");
            }
        }
    }
}
