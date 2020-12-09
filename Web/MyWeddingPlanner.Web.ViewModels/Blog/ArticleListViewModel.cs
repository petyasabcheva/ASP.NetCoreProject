namespace MyWeddingPlanner.Web.ViewModels.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArticleListViewModel : PagingViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }

        public string CategoryName { get; set; }
    }
}
