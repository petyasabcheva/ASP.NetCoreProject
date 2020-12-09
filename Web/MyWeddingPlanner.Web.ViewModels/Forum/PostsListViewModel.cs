namespace MyWeddingPlanner.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    public class PostsListViewModel : PagingViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }

        public string CategoryName { get; set; }
    }
}
