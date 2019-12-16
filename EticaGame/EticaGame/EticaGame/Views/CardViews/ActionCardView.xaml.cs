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
        public ActionCardView(ACard carta)
        {
            InitializeComponent();
            Accion.Text = carta.GetTitle();
            Explica.Text = carta.GetExplica();
            Ausr.Text = "noParam";
        }
    }
}