﻿using System;
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
        public EditChoreViewModel viewModel;

        public EditChorePage()
        {
            InitializeComponent();

            Title = "Add Chore";
            BindingContext = viewModel = new EditChoreViewModel();
        }

        public EditChorePage(Chore chore)
        {
            InitializeComponent();

            Title = "Edit Chore";
            BindingContext = viewModel = new EditChoreViewModel(chore);
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SaveChore", viewModel.Chore);
            await Navigation.PushAsync(new NavigationPage(new ChoreListPage()));
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }        
    }
}