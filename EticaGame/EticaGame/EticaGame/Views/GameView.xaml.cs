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

            if (Device.OS == TargetPlatform.Android)
            {
                Application.Current.MainPage = new GameSetup();
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushModalAsync(new GameSetup());
            }
        }

        void OnResetGameClicked(object sender, EventArgs e)
        {
            BindingContext = new GameViewModel(T, Navigation);
        }
    }
}