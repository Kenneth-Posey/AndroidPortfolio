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
        public string PopulateDataButtonText { get; set; } = "Load test chores";
        public string DeleteDataButtonText { get; set; } = "Delete all chores";
        public ICommand PopulateDataButton_Clicked { private set; get; }
        public ICommand DeleteDataButton_Clicked { private set; get; }

        private string _updateMessage = "";
        public string UpdateMessage
        {
            get { return _updateMessage; }
            set { SetProperty(ref _updateMessage, value); }
        }

        public SettingsPageViewModel()
        {
            Title = "Testing and Settings";

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

            DeleteDataButton_Clicked = new Command(
                execute: () =>
                {
                    DeleteChoreData();
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

            UpdateMessage = "Test chores loaded";
        }

        public async void DeleteChoreData()
        {
            var chores = await _choreService.GetAllChores();
            foreach (var chore in chores)
            {
                await _choreService.Delete(chore);
            }

            UpdateMessage = "All chores deleted";
        }

        private void RefreshCanExecute()
        {
            (PopulateDataButton_Clicked as Command).ChangeCanExecute();
        }
    }
}
