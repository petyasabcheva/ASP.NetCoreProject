using System;
using System.Collections.Generic;
using System.Text;
using MyWeddingPlanner.Web.ViewModels.Marketplace;

namespace MyWeddingPlanner.Web.ViewModels.Forum
{
    public class PostsListViewModel : PagingViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }

        public string CategoryName { get; set; }
    }
}
