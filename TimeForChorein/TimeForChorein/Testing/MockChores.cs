using System;
using System.Collections.Generic;
using System.Text;
using TimeForChorein.Enums;
using TimeForChorein.Models;

namespace TimeForChorein.Testing
{
    public class MockChores
    {
        public static List<Chore> GetMockChoreList()
        {
            var choreList = new List<Chore>
            {
                new Chore()
                {
                    Name = "Clean the catbox",
                    ChorePriority = ChorePriority.Critical,
                    Minutes = 15,
                    ChoreStatus = ChoreStatus.New,
                    Description = "The kitties are definitely happier with this task being done than you are doing it",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = true
                },

                new Chore()
                {
                    Name = "Load the dishwasher",
                    ChorePriority = ChorePriority.Critical,
                    Minutes = 20,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Glasses go on the top rack, plates on the bottom rack, flatware in the flatware rack",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Empty the Dishwasher",
                    ChorePriority = ChorePriority.High,
                    Minutes = 14,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Be careful with the glasses and plates because they can be fragile",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Vaccuum the Living Room",
                    ChorePriority = ChorePriority.High,
                    Minutes = 25,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Fight the cat hair!",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Dust the books",
                    ChorePriority = ChorePriority.High,
                    Minutes = 45,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Books are more fun when not hidden behind a plume of dust",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Pay the bills",
                    ChorePriority = ChorePriority.Highest,
                    Minutes = 60,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Autopay doesn't apply to everything and it's worthwhile to monitor it anyway",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Clean the bathroom mirror",
                    ChorePriority = ChorePriority.Medium,
                    Minutes = 20,
                    Description = "It's good to be able to see yourself",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Brush the kitties",
                    ChorePriority = ChorePriority.Medium,
                    Minutes = 30,
                    ChoreStatus = ChoreStatus.New,
                    Description = "The vaccuum cleaner will not thank you later but your sinuses will",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Sweep and mop",
                    ChorePriority = ChorePriority.Low,
                    Minutes = 35,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Everything can't be vaccuumed and that's why we have old-school techniques",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Load the washing machine",
                    ChorePriority = ChorePriority.Low,
                    Minutes = 10,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Clean clothes are lots of fun",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                },

                new Chore()
                {
                    Name = "Load the dryer",
                    ChorePriority = ChorePriority.Lowest,
                    Minutes = 10,
                    ChoreStatus = ChoreStatus.New,
                    Description = "Dry clean clothes are even more fun than clothes fresh out of the wash",
                    DateCreated = DateTime.Now,
                    DateLastModifed = DateTime.Now,
                    Repeatable = false
                }
            };

            return choreList;
        }
    }
}
