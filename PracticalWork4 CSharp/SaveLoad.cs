using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork4_CSharp
{
    internal class SaveLoad
    {
        public static List<Note> Load()
        {
            List<Note> notes = new List<Note>();
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Note.json"))
            {
                string Text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Note.json");
                notes = JsonConvert.DeserializeObject<List<Note>>(Text);
                return notes;
            }
            else
            {
                string json;
                json = JsonConvert.SerializeObject(notes);
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Note.json", json);
                return notes;
            }
        }
        public static void Save(List<Note> users)
        {
            string json;
            json = JsonConvert.SerializeObject(users);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Note.json", json);
        }
    }
}
