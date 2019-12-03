using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using EticaGame.Models;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using EticaGame.Views;
using EticaGame.Views.CardViews;

namespace EticaGame.ViewModels
{
    public class GameViewModel
    {
        public INavigation Navigation { get; set; }
        enum CType { Brecha, SLibre, ProdDatos, Privacidad, Facts }
        //enum Action { Turno, Tira, Debate, Pierde, Roba }

        List<QCard> CartasGenero = new List<QCard>();
        List<QCard> CartasSoftware = new List<QCard>();
        List<QCard> CartasProteccion = new List<QCard>();
        List<QCard> CartasPrivacidad = new List<QCard>();
        List<QCard> CartasFacts = new List<QCard>();
        //cards that have appeared already in the game
        List<QCard> CartasUsadas = new List<QCard>();
        //action cards
        List<ACard> CartasEspeciales = new List<ACard>();
        public ObservableCollection<Team> Equipos { get; private set; } = new ObservableCollection<Team>();
        //bool Start=false;
        int NTeams;
        int TurnoTeam;
        public string Turno { get; set; }

        public GameViewModel(int teams, INavigation navigation)
        {
            this.NTeams = teams;

            //initialize and fill all the lists
            CreaEquipos(teams);
            LlenarListaBrecha("Brecha");
            LlenarListaSoftware("Software");
            LlenarListaProteccion("Proteccion");
            LlenarListaPrivacidad("Privacidad");
            LlenarListaFact("Facts");
            LLenarListaEspeciales();
            TurnoTeam = 0;
            ActualizarTurno();
            this.Navigation = navigation;
        }

        void ActualizarTurno()
        {
            if(TurnoTeam <= NTeams)
            {
                TurnoTeam += 1;   
            }
            else { TurnoTeam = 1; }
            Turno = "Equipo" + TurnoTeam.ToString();
        }

        void CreaEquipos(int equipos)
        {
            for(int i = 0; i < equipos; i++)
            {
                Equipos.Add(new Team(i + 1));
            }
        }

        void LlenarListaBrecha(string tipo)
        {
            CartasGenero.Add(new QCard("¿Pregunta A1?", tipo, "Dis", "", ""));
            CartasGenero.Add(new QCard("¿Pregunta A2?", tipo, "True", "", ""));
            CartasGenero.Add(new QCard("¿Pregunta A3?", tipo, "A", "B", "C"));
       
        }

        void LlenarListaSoftware(string tipo)
        {
            CartasSoftware.Add(new QCard("¿Pregunta B1?", tipo, "Dis", "", ""));
            CartasSoftware.Add(new QCard("¿Pregunta B2?", tipo, "True", "", ""));
            CartasSoftware.Add(new QCard("¿Pregunta B3?", tipo, "A", "B", "C"));
        }
        
        void LlenarListaProteccion(string tipo)
        {
            CartasProteccion.Add(new QCard("¿Pregunta C1?", tipo, "Dis", "", ""));
            CartasProteccion.Add(new QCard("¿Pregunta C2?", tipo, "True", "", ""));
            CartasProteccion.Add(new QCard("¿Pregunta C3?", tipo, "A", "B", "C"));
        }

        void LlenarListaPrivacidad(string tipo)
        {
            CartasPrivacidad.Add(new QCard("¿Pregunta D1?", tipo, "Dis", "", ""));
            CartasPrivacidad.Add(new QCard("¿Pregunta D2?", tipo, "True", "", ""));
            CartasPrivacidad.Add(new QCard("¿Pregunta D3?", tipo, "A", "B", "C"));
        }

        void LlenarListaFact(string tipo)
        {
            CartasFacts.Add(new QCard("¿Pregunta E1?", tipo, "Dis", "", ""));
            CartasFacts.Add(new QCard("¿Pregunta E2?", tipo, "True", "", ""));
            CartasFacts.Add(new QCard("¿Pregunta E3?", tipo, "A", "B", "C"));
        }

        void LLenarListaEspeciales()
        {
            CartasEspeciales.Add(new ACard("¡Pierde turno!", "Cuando estéis listos pasad al turno del siguiente equipo."));
            CartasEspeciales.Add(new ACard("¡Tira otra vez!", "La suerte os sonríe, tenéis otra tirada."));
            CartasEspeciales.Add(new ACard("¡Pierde cable!", "Vuestro equipo elige el color del cable a descartar, si no tenéis ninguno pasad turno."));
            CartasEspeciales.Add(new ACard("¡A rotar!", "Cada equipo cambia su board con el de su derecha."));
        }

        //move the used card from original list to used list so that it won't repeat
        void TraspasarUsadas(QCard carta)
        {
            string k = carta.GetTema();
            switch (k)
            {
                case "Brecha":
                    CartasUsadas.Add(carta);
                    CartasGenero.Remove(carta);
                    break;
                case "Software":
                    CartasUsadas.Add(carta);
                    CartasSoftware.Remove(carta);
                    break;
                case "Proteccion":
                    CartasUsadas.Add(carta);
                    CartasProteccion.Remove(carta);
                    break;
                case "Privacidad":
                    CartasUsadas.Add(carta);
                    CartasPrivacidad.Remove(carta);
                    break;
                case "Facts":
                    CartasUsadas.Add(carta);
                    CartasFacts.Remove(carta);
                    break;
            }
        }


        // Generate a random number between two numbers  
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        QCard ElegirNuevaQCarta(string colorBton)
        {
            QCard krta = null;
            //pick random number
            int ran = RandomNumber(0, 1000);
            //pick a car randomly from the list corresponding to the color of the button clicked
            switch (colorBton)
            {
                case "Violet":
                    if(CartasGenero.Count == 0) { return null; }
                    if(ran == CartasGenero.Count) { ran -= 1; }
                    krta = CartasGenero[ran % CartasGenero.Count];
                    break;
                case "ForestGreen":
                    if (CartasSoftware.Count == 0) { return null; }
                    if (ran == CartasSoftware.Count) { ran -= 1; }
                    krta = CartasSoftware[ran % CartasSoftware.Count];
                    break;
                case "LightSkyBlue":
                    if (CartasProteccion.Count == 0) { return null; }
                    if (ran == CartasProteccion.Count) { ran -= 1; }
                    krta = CartasProteccion[ran % CartasProteccion.Count];
                    break;
                case "DeepPink":
                    if (CartasPrivacidad.Count == 0) { return null; }
                    if (ran == CartasPrivacidad.Count) { ran -= 1; }
                    krta = CartasPrivacidad[ran % CartasPrivacidad.Count];
                    break;
                case "Orange":
                    if (CartasFacts.Count == 0) { return null; }
                    if (ran == CartasFacts.Count) { ran -= 1; }
                    krta = CartasFacts[ran % CartasFacts.Count];
                    break;
            }
            //move the card to the used list
            TraspasarUsadas(krta);
            //assign it to return
            return krta;
        }

        ACard ElegirNuevaACarta()
        {
            //pick random number
            int ran = RandomNumber(0, 100);
            if (ran == CartasGenero.Count) { ran -= 1; }
            return CartasEspeciales[ran % CartasEspeciales.Count];
        }

        public ICommand GoNextCard
        {
            get
            {
                return new Command<string>((colorBton) => CallCardView(colorBton));
            }
        }
        async void CallCardView(string colorBton)
        {
            int ran = RandomNumber(0, 1000);
            if (ran <= 750)
            {
                ColorTypeConverter converter = new ColorTypeConverter();
                Color color = (Color)(converter.ConvertFromInvariantString(colorBton));
                QCard send = ElegirNuevaQCarta(colorBton);
                if (send != null)
                {
                    await Navigation.PushAsync(new QuestionCardView(color, ElegirNuevaQCarta(colorBton)) { BindingContext = this, });
                }
                else await Application.Current.MainPage.DisplayAlert("Lo sentimos", "No quedan más cartas de este tipo", "OK");
            }
            else 
            {
                await Navigation.PushAsync(new ActionCardView(ElegirNuevaACarta()) { BindingContext = this,});
            }
        }
    }
}
