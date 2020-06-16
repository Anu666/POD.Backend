using System;
using System.Collections.Generic;
using System.Text;

namespace POD.Models
{
    public class PodUser
    {
        public Guid Id { get; set; }

        public string Token { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public string DisplayPicture { get; set; }
    }
}
