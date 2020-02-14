using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TimeForChorein.Models;
using TimeForChorein.Enums;

namespace TimeForChorein.Views
{
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch ((MenuItemEntry)id)
                {
                    case MenuItemEntry.HomePage:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case MenuItemEntry.ChoreList:
                        MenuPages.Add(id, new NavigationPage(new ChoreListPage()));
                        break;
                    case MenuItemEntry.AddNewChore:
                        MenuPages.Add(id, new NavigationPage(new EditChorePage()));
                        break;
                    case MenuItemEntry.Settings:
                        MenuPages.Add(id, new NavigationPage(new SettingsPage()));
                        break;
                    // removing about for now
                    // case MenuItemEntry.About:
                    //     MenuPages.Add(id, new NavigationPage(new AboutPage()));
                    //     break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}