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

        List<QCard> CartasGenero;
        List<QCard> CartasSoftware;
        List<QCard> CartasProteccion;
        List<QCard> CartasPrivacidad;
        List<QCard> CartasFacts;
        //cards that have appeared already in the game
        List<QCard> CartasUsadas;
        //action cards
        List<ACard> CartasEspeciales;
        public ObservableCollection<Team> Equipos { get; private set; } = new ObservableCollection<Team>();
        bool Start=false;

        public GameViewModel(INavigation navigation)
        {
            //initialize and fill all the lists
            CreaEquipos(4);
            //LlenarListaBrecha("Brecha");
            //LlenarListaSoftware("Software");
            //LlenarListaProteccion("Proteccion");
            //LlenarListaPrivacidad("Privacidad");
            //LlenarListaFact("Facts");
            //LLenarListaEspeciales();

            this.Navigation = navigation;
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
            CartasGenero.Add(new SingleAnswerCard("", "", tipo));
            CartasGenero.Add(new TFAnserCard("", true, tipo));
            CartasGenero.Add(new MultiAnswerCard("", "", "", "", tipo));
       
        }

        void LlenarListaSoftware(string tipo)
        {
            CartasSoftware.Add(new SingleAnswerCard("", "", tipo));
            CartasSoftware.Add(new TFAnserCard("", true, tipo));
            CartasSoftware.Add(new MultiAnswerCard("", "", "", "", tipo));
        }
        
        void LlenarListaProteccion(string tipo)
        {
            CartasProteccion.Add(new SingleAnswerCard("", "", tipo));
            CartasProteccion.Add(new TFAnserCard("", true, tipo));
            CartasProteccion.Add(new MultiAnswerCard("", "", "", "", tipo));
        }

        void LlenarListaPrivacidad(string tipo)
        {
            CartasPrivacidad.Add(new SingleAnswerCard("", "", tipo));
            CartasPrivacidad.Add(new TFAnserCard("", true, tipo));
            CartasPrivacidad.Add(new MultiAnswerCard("", "", "", "", tipo));
        }

        void LlenarListaFact(string tipo)
        {
            CartasFacts.Add(new SingleAnswerCard("", "", tipo));
            CartasFacts.Add(new TFAnserCard("", true, tipo));
            CartasFacts.Add(new MultiAnswerCard("", "", "", "", tipo));
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

        public ICommand GoNextCard
        {
            get
            {
                return new Command<string>((x) => CallCardView(x));
            }
        }
        async void CallCardView(string x)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            QCard carta = new QCard("",x);
            Color color = (Color)(converter.ConvertFromInvariantString(x));
            await Navigation.PushAsync(new SingleACard(color));
        }
    }
}
