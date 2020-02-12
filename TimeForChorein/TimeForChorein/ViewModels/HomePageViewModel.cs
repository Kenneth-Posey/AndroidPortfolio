using System;
using System.Collections.Generic;
using System.Text;

namespace TimeForChorein.ViewModels
{
    public class HomePageViewModel
    {
        public string AddChoreText { get; set; } = "Add New Chore";
        public string ChoreListText { get; set; } = "View Chore List";
        public string StartChoreText { get; set; } = "Time for Chorin'";

        public string Title { get; set; } = "Home";

        public HomePageViewModel()
        {

        }
    }
}
