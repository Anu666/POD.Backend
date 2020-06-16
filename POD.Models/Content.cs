using System;
using System.Collections.Generic;
using System.Text;

namespace POD.Models
{
    public class Content
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public string RequestedItem { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid FromUserId { get; set; }

        public Guid GroupId { get; set; }
    }
}
