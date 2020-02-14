using TimeForChorein.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeForChorein.Enums;

namespace TimeForChorein.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemEntry.HomePage, Title="Home" },
                new HomeMenuItem {Id = MenuItemEntry.ChoreList, Title="Chores" },
                new HomeMenuItem {Id = MenuItemEntry.AddNewChore, Title="Add Chore" },
                new HomeMenuItem {Id = MenuItemEntry.Settings, Title="Settings" },
                // new HomeMenuItem {Id = MenuItemEntry.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}