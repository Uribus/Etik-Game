using EticaGame.Models;
using EticaGame.ViewModels;
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
    public partial class GameMaster : ContentPage
    {
        public ListView Lista { get { return listDetails; } }
        public List<MenuItems> items;

        public GameMaster()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            //initialize the list with the elements within
            items = new List<MenuItems>();
            items.Add(new MenuItems("Game", "", Color.AntiqueWhite, typeof(GameView)));
            items.Add(new MenuItems("Info", "", Color.AntiqueWhite, typeof(InfoGame)));

            //tell the view where to look for the data
            Lista.ItemsSource = items;
        }
    }
}