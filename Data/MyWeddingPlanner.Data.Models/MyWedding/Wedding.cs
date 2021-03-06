﻿namespace MyWeddingPlanner.Data.Models.MyWedding
{
    using System;
    using System.Collections.Generic;

    using MyWeddingPlanner.Data.Common.Models;

    public class Wedding : BaseModel<int>
    {
        public Wedding()
        {
            this.Guests = new HashSet<Guest>();
            this.Expenditures = new HashSet<Expenditure>();
            this.ToDos = new HashSet<ToDo>();
        }

        public ApplicationUser Owner { get; set; }

        public string OwnerId { get; set; }

        public string BrideName { get; set; }

        public string GroomName { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int Budget { get; set; }

        public virtual ICollection<Expenditure> Expenditures { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
