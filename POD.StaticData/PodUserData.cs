namespace POD.StaticData
{
    using System;
    using System.Collections.Generic;

    using POD.Models;

    public class PodUserData
    {
        private static List<PodUser> Users =  new List<PodUser>()
            {
                new PodUser()
        {
            Id = new Guid("baf019c6-8089-4dd1-8814-e61df0baf370"),
                    Token = "GodToken",
                    PhoneNumber = "1234567890",
                    Name = "Aditya",
                    DisplayPicture = null,
                },
                new PodUser()
        {
            Id = new Guid("fe950c1e-d35f-443a-847c-ae58826a5bdb"),
                    Token = "GodToken",
                    PhoneNumber = "9876543210",
                    Name = "Sahitha",
                    DisplayPicture = null,
                },
                new PodUser()
        {
            Id = new Guid("d04de133-1ff9-4d70-a69d-540ac635f6a0"),
                    Token = "GodToken",
                    PhoneNumber = "8309606658",
                    Name = "Anudeep",
                    DisplayPicture = null,
                }
    };

        public static List<PodUser> GetUsers()
        {
            return Users;
        }

        public static void AddUser(PodUser podUser)
        {
            Users.Add(podUser);
        }

        public static PodUser GetUserById(Guid id)
        {
            return Users.Find(x => x.Id == id);
        }
    }
}
