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
        int Curr = -1;
        public GameSetup()
        {
            InitializeComponent();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e) 
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if(selectedIndex != -1)
            {
                Curr = Int32.Parse(picker.Items[selectedIndex]);
            }
        }

        [Obsolete]
        async void OnStartGameButtonClicked(object sender, EventArgs e)
        {
            if(Device.OS == TargetPlatform.Android)
            {
                Application.Current.MainPage = new NavigationPage(new GameView(Curr));
            }
            else if(Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushModalAsync(new NavigationPage(new GameView(Curr)));
            }
        }
    }
}