using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TimeForChorein.Models;

namespace TimeForChorein.Views
{
    [DesignTimeVisible(true)]
    public partial class NewChorePage : ContentPage
    {
        public Chore Chore { get; set; }

        public NewChorePage()
        {
            InitializeComponent();

            Chore = new Chore
            {
                DateCreated = DateTime.Now,
                DateLastModifed = DateTime.Now
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddChore", Chore);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}