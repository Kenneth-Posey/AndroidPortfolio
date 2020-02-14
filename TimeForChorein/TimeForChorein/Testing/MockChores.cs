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
            var choreList = new List<Chore>();

            choreList.Add(new Chore()
            {
                Name = "Chore 0",
                ChorePriority = ChorePriority.Critical,
                Minutes = 15
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 1",
                ChorePriority = ChorePriority.Critical,
                Minutes = 20
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 2",
                ChorePriority = ChorePriority.High,
                Minutes = 14
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 3",
                ChorePriority = ChorePriority.High,
                Minutes = 25
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 4",
                ChorePriority = ChorePriority.High,
                Minutes = 45
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 5",
                ChorePriority = ChorePriority.Highest,
                Minutes = 60
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 6",
                ChorePriority = ChorePriority.Medium,
                Minutes = 20
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 7",
                ChorePriority = ChorePriority.Medium,
                Minutes = 30
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 8",
                ChorePriority = ChorePriority.Low,
                Minutes = 35
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 9",
                ChorePriority = ChorePriority.Low,
                Minutes = 40
            });

            choreList.Add(new Chore()
            {
                Name = "Chore 10",
                ChorePriority = ChorePriority.Lowest,
                Minutes = 10
            });

            return choreList;
        }
    }
}
