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

        public ChoreDetailPage()
        {
            InitializeComponent();

            var item = new Chore
            {

            };

            viewModel = new ChoreDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}