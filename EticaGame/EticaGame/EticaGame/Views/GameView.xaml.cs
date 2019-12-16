using EticaGame.Models;
using EticaGame.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EticaGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentPage
    {
        int T;
        public GameView(int equipos)
        {
            InitializeComponent();
            T = equipos;
            BindingContext = new GameViewModel(T, Navigation);
        }

        async void OnInfoClicked(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new InfoGame());
        }

        async void OnReglasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RulesGame());
        }

        [Obsolete]
        async void OnNewGameClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Vas a ir al menú de selección de equipos", "Confirma", "Yes", "No");
            if(answer)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    Application.Current.MainPage = new GameSetup();
                }
                else if (Device.OS == TargetPlatform.iOS)
                {
                    await Navigation.PushModalAsync(new GameSetup());
                }
            }
        }

        async void OnResetGameClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("¿Reestablecer valores de partida?", "Confirma", "Yes", "No");
            if(answer)
            {
                BindingContext = new GameViewModel(T, Navigation);
            }
        }
    }
}