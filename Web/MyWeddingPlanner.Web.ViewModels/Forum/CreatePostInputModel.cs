using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeddingPlanner.Web.ViewModels.Forum
{
    public class CreatePostInputModel
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
