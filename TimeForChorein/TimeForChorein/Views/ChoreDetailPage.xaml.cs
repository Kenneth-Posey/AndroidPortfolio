using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TimeForChorein.Models;
using TimeForChorein.ViewModels;

namespace TimeForChorein.Views
{
    [DesignTimeVisible(true)]
    public partial class ChoreDetailPage : ContentPage
    {
        ChoreDetailViewModel viewModel;

        public ChoreDetailPage(ChoreDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            var editChorePage = new EditChorePage(viewModel.Chore.ChoreId);
            await Navigation.PushModalAsync(new NavigationPage(editChorePage));
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteChore", viewModel.Chore);
            await Navigation.PopToRootAsync();
        }
    }
}