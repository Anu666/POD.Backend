using System;
using System.Collections.Generic;
using System.Text;

namespace POD.Models
{
    public class PodGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AdminId { get; set; }

        public List<PodUser> Members { get; set; }

        public List<Content> Content { get; set; }
    }
}
