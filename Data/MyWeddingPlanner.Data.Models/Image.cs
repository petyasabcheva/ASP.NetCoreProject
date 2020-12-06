namespace MyWeddingPlanner.Data.Models
{
    using System;

    using MyWeddingPlanner.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }
    }
}
