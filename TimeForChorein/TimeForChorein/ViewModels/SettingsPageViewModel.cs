using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeForChorein.Testing;
using Xamarin.Forms;

namespace TimeForChorein.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public string PopulateDataButtonText { get; set; } = "Click to load data";
        public ICommand PopulateDataButton_Clicked { private set; get; }

        private string _updateMessage = "";
        public string UpdateMessage
        {
            get { return _updateMessage; }
            set { SetProperty(ref _updateMessage, value); }
        }

        public SettingsPageViewModel()
        {
            PopulateDataButton_Clicked = new Command(
                execute: () =>
                {
                    PopulateData();
                    RefreshCanExecute();
                },
                canExecute: () =>
                {
                    return true;
                });
        }

        public async void PopulateData()
        {
            var mockChoreList = MockChores.GetMockChoreList();
            foreach(var chore in mockChoreList)
            {
                await _choreService.Save(chore);
            }

            UpdateMessage = "Done!";
        }

        private void RefreshCanExecute()
        {
            (PopulateDataButton_Clicked as Command).ChangeCanExecute();
        }
    }
}
