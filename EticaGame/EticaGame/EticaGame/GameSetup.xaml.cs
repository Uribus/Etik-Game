using EticaGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EticaGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameSetup : ContentPage
    {
        public GameSetup()
        {
            InitializeComponent();

        }

        [Obsolete]
        async void OnStartGameButtonClicked(object sender, EventArgs e)
        {
            if(Device.OS == TargetPlatform.Android)
            {
                Application.Current.MainPage = new MasterDetail();
            }
            else if(Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushModalAsync(new MasterDetail());
            }
        }
    }
}