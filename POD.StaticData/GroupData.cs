namespace POD.StaticData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using POD.Models;

    public class GroupData
    {
        private static List<PodGroup> Groups = new List<PodGroup>()
        {
            new PodGroup()
            {
                Id = new System.Guid("46da8f83-610e-47c9-a5f7-a666c6dea646"),
                Name = "Reboot",
                AdminId = new System.Guid("baf019c6-8089-4dd1-8814-e61df0baf370"),
                Members = PodUserData.GetUsers().Take(3).ToList(),
            }

        };


        public static List<PodGroup> GetAllGroups()
        {
            return Groups;
        }

        public static void AddGroup(PodGroup group)
        {
            Groups.Add(group);
        }

        public static PodGroup GetGroupById(Guid id)
        {
            return Groups.Find(x => x.Id == id);
        }

    }
}
