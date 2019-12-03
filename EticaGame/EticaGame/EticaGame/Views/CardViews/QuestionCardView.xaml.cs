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
    public partial class QuestionCardView : ContentPage
    {
        public QuestionCardView(Color color, QCard carta)
        {
            InitializeComponent();
            BackgroundColor = color;
            Tema.Text = carta.GetTema();
            Pregunta.Text = carta.GetPregunta();
            Respuesta.Text = carta.GetRespuesta();
        }
    }
}