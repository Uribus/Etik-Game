using EticaGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EticaGame.Views.CardViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionCardView : ContentPage
    {
        string Tema;
        public ActionCardView(ACard carta)
        {
            InitializeComponent();
            Tema = carta.GetTitle();
            Accion.Text = Tema;
            Explica.Text = carta.GetExplica();
            if(Tema == "¡Tira otra vez!")
            {
                Ausr.Text = "pasaTurno";
                SigBton.Text = "Tira otra vez";
            }
            else
            {
                Ausr.Text = "noParam";
                SigBton.Text = "Siguiente Turno";
            }
        }
    }
}