using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeForChorein.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeForChorein.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomePageViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HomePageViewModel();
        }

        private void AddChoreButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new EditChorePage()));
        }

        private void ChoreListButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ChoreListPage()));
        }

        private void StartChoreButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ChoreProgressPage()));
        }
    }
}