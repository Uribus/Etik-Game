using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EticaGame.Models
{
    public class Team : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Aciertos { get; set; }
        int Naciertos;
        int NFallos;
        public string Fallos { get; set; }

        public Team(int id) 
        {
            string v = id.ToString();
            this.Name = "Equipo " + v;
            Naciertos = 0;
            NFallos = 0;
            this.Aciertos = "Aciertos: " + Naciertos.ToString();
            this.Fallos = "Fallos: " + NFallos.ToString();
        }

        public void AddAcierto() 
        {
            Naciertos += 1;
            this.Aciertos = "Aciertos: " + Naciertos.ToString();
        }
        public void AddFallo()
        {
            NFallos += 1;
            this.Fallos = "Fallos: " + NFallos.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
