using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeForChorein.Models;
using TimeForChorein.Views;
using TimeForChorein.ViewModels;

namespace TimeForChorein.Views
{
    [DesignTimeVisible(true)]
    public partial class ChoreListPage : ContentPage
    {
        ChoreListViewModel viewModel;

        public ChoreListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ChoreListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args?.SelectedItem == null)
                return;

            var item = args.SelectedItem as Chore;
            if (item == null)
                return;

            await Navigation.PushAsync(new ChoreDetailPage(new ChoreDetailViewModel(item)));

            // Manually deselect item.
            ChoreListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditChorePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}