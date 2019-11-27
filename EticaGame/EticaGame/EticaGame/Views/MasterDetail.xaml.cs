using EticaGame.Models;
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
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            masterPage.Lista.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItems;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.Target));
                masterPage.Lista.SelectedItem = null;
                IsPresented = false;
            }

        }
    }
}