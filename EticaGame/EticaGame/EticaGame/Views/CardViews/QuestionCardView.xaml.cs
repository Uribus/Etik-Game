using EticaGame.Models;
using EticaGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string Question;
        string A0;
        string A1;
        string A2;
        string A3;
        string Correcta;
        string AnswerUsr;
        public QuestionCardView(Color color, QCard carta)
        {
            InitializeComponent();
            BackgroundColor = color;
            Tema.Text = carta.GetTema();
            Question = carta.GetPregunta();
            Correcta = carta.GetRespuesta();
            A0 = carta.GetR0();
            A1 = carta.GetR1();
            A2 = carta.GetR2();
            A3 = carta.GetR3();
            Sig.CommandParameter = AnswerUsr;
            SetLabels();  
        }

        void SetLabels()
        {
            CorrectTit.IsVisible = false;
            Correct.IsVisible = false;
            Pregunta.Text = Question;
            if (Question == "Debate")
            {
                Resp.IsEnabled = false;
                AnswerUsr = "noParam";
                Ausr.Text = AnswerUsr;
                Ans.IsVisible = false;
                Expl.Text = A0;
                ABton.IsEnabled = false;
                ABton.IsVisible = false;

            }
            else
            {

                switch (A1)
                {
                    case "#":
                        Ans.IsVisible = false;
                        break;
                    case "Falso":
                        R0.Text = A0;
                        R1.Text = A1;
                        R2.IsVisible = false;
                        R3.IsVisible = false;
                        break;
                    default:
                        R0.Text = A0;
                        R1.Text = A1;
                        R2.Text = A2;
                        R3.Text = A3;
                        break;
                }

                Pregunta.Text = Question;
                Expl.IsVisible = false;
            }
        }

        void OnShowAnswerClicked(object sender, EventArgs e)
        {
            CorrectTit.IsVisible = true;
            Correct.IsVisible = true;
            Correct.Text = Correcta;
            ABton.IsEnabled = false;
        }

        async void OnAnswerClicked(object sender, EventArgs e)
        {
            AnswerUsr = await DisplayActionSheet("¿Has acertado?","Cancelar", null, "SI", "NO");
            if(AnswerUsr != null && AnswerUsr != "")
            {
                Ausr.Text = AnswerUsr;
            }
        }
    }
}