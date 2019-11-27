using System;
using System.Collections.Generic;
using System.Text;
using EticaGame.Models;

namespace EticaGame.ViewModels
{
    class GameViewModel
    {
        enum CType { Brecha, SLibre, ProdDatos, Privacidad, Facts }
        //enum Action { Turno, Tira, Debate, Pierde, Roba }

        List<QCard<CType>> CartasGenero;
        List<QCard<CType>> CartasSoftware;
        List<QCard<CType>> CartasProteccion;
        List<QCard<CType>> CartasPrivacidad;
        List<QCard<CType>> CartasFacts;
        //cards that have appeared already in the game
        List<QCard<CType>> CartasUsadas;
        //action cards
        List<ACard> CartasEspeciales;
        List<Team> Equipos;
        bool Start=false;

        public GameViewModel()
        {
            //initialize and fill all the lists
            LlenarListaBrecha(CType.Brecha);
            LlenarListaSoftware(CType.SLibre);
            LlenarListaProteccion(CType.ProdDatos);
            LlenarListaPrivacidad(CType.Privacidad);
            LlenarListaFact(CType.Facts);
            LLenarListaEspeciales();
        }

        void LlenarListaBrecha(CType tipo)
        {
            CartasGenero.Add(new SingleAnswerCard<CType>("", "", tipo));
            CartasGenero.Add(new TFAnserCard<CType>("", true, tipo));
            CartasGenero.Add(new MultiAnswerCard<CType>("", "", "", "", tipo));
       
        }

        void LlenarListaSoftware(CType tipo)
        {
            CartasSoftware.Add(new SingleAnswerCard<CType>("", "", tipo));
            CartasSoftware.Add(new TFAnserCard<CType>("", true, tipo));
            CartasSoftware.Add(new MultiAnswerCard<CType>("", "", "", "", tipo));
        }
        
        void LlenarListaProteccion(CType tipo)
        {
            CartasProteccion.Add(new SingleAnswerCard<CType>("", "", tipo));
            CartasProteccion.Add(new TFAnserCard<CType>("", true, tipo));
            CartasProteccion.Add(new MultiAnswerCard<CType>("", "", "", "", tipo));
        }

        void LlenarListaPrivacidad(CType tipo)
        {
            CartasPrivacidad.Add(new SingleAnswerCard<CType>("", "", tipo));
            CartasPrivacidad.Add(new TFAnserCard<CType>("", true, tipo));
            CartasPrivacidad.Add(new MultiAnswerCard<CType>("", "", "", "", tipo));
        }

        void LlenarListaFact(CType tipo)
        {
            CartasFacts.Add(new SingleAnswerCard<CType>("", "", tipo));
            CartasFacts.Add(new TFAnserCard<CType>("", true, tipo));
            CartasFacts.Add(new MultiAnswerCard<CType>("", "", "", "", tipo));
        }

        void LLenarListaEspeciales()
        {
            CartasEspeciales.Add(new ACard("¡Pierde turno!", "Cuando estéis listos pasad al turno del siguiente equipo."));
            CartasEspeciales.Add(new ACard("¡Tira otra vez!", "La suerte os sonríe, tenéis otra tirada."));
            CartasEspeciales.Add(new ACard("¡Pierde cable!", "Vuestro equipo elige el color del cable a descartar, si no tenéis ninguno pasad turno."));
            CartasEspeciales.Add(new ACard("¡A rotar!", "Cada equipo cambia su board con el de su derecha."));
        }

        //move the used card from original list to used list so that it won't repeat
        void TraspasarUsadas(QCard<CType> carta)
        {
            int k = (int)carta.GetTema();
            switch (k)
            {
                case 0:
                    CartasUsadas.Add(carta);
                    CartasGenero.Remove(carta);
                    break;
                case 1:
                    CartasUsadas.Add(carta);
                    CartasSoftware.Remove(carta);
                    break;
                case 2:
                    CartasUsadas.Add(carta);
                    CartasProteccion.Remove(carta);
                    break;
                case 3:
                    CartasUsadas.Add(carta);
                    CartasPrivacidad.Remove(carta);
                    break;
                case 4:
                    CartasUsadas.Add(carta);
                    CartasFacts.Remove(carta);
                    break;
            }
        }
    }
}
