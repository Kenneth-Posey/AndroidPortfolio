using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TimeForChorein.Models;
using TimeForChorein.Views;

namespace TimeForChorein.ViewModels
{
    public class ChoreListViewModel : BaseViewModel
    {
        public ObservableCollection<Chore> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ChoreListViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Chore>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewChorePage, Chore>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Chore;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}