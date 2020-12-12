namespace MyWeddingPlanner.Web.ViewModels.MyWedding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateGuestInputModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public int Table { get; set; }

        public int Side { get; set; }
    }
}
