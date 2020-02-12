using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using TimeForChorein.Models;
using TimeForChorein.Utility;
using TimeForChorein.Services;
using System.Threading.Tasks;
using TimeForChorein.ViewModels;

namespace TimeForChorein.Views
{
    [DesignTimeVisible(true)]
    public partial class EditChorePage : ContentPage
    {
        public Chore Chore { get; set; }
        public EditChoreViewModel viewModel;

        public EditChorePage()
        {
            InitializeComponent();

            Chore = new Chore
            {
                DateCreated = DateTime.Now,
                DateLastModifed = DateTime.Now
            };
            Title = "Add Chore";
            BindingContext = this;
        }

        public EditChorePage(int? choreId)
        {
            InitializeComponent();

            viewModel = new EditChoreViewModel(choreId);
            viewModel.LoadItemCommand.Execute(choreId);
            Title = "Edit Chore";
            BindingContext = viewModel;
        }


        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SaveChore", Chore);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        
    }
}