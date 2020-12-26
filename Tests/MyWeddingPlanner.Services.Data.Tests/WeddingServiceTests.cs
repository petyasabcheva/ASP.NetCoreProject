namespace MyWeddingPlanner.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Moq;
    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Blog;
    using MyWeddingPlanner.Services.Mapping;
    using MyWeddingPlanner.Web.ViewModels.Blog;
    using Xunit;

    public class WeddingServiceTests
    {
        private CreateArticleInputModel testArticle;
        private List<BlogArticle> articleList;

        public void Setup()
        {
            this.testArticle = new CreateArticleInputModel
            {
                Title = "test",
                CategoryId = 1,
                Content = "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest",
            };

            this.articleList = new List<BlogArticle>();
            AutoMapperConfig.RegisterMappings(typeof(ArticleViewModel).Assembly, typeof(BlogArticle).Assembly);
        }

        [Fact]
        public async Task ArticlesShouldBeAddedSuccessfully()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<BlogArticle>>();
            repo.Setup(x => x.AddAsync(It.IsAny<BlogArticle>())).Callback(
                (BlogArticle article) => this.articleList.Add(article));
            var categoryRepo = new Mock<IDeletableEntityRepository<BlogCategory>>();
            var articlesService = new ArticlesService(repo.Object, categoryRepo.Object);

            await articlesService.CreateAsync(this.testArticle, "testUser");
            Assert.Single(this.articleList);
            Assert.Equal(this.testArticle.Title, this.articleList.First().Title);

            await articlesService.CreateAsync(this.testArticle, "testUser");

            Assert.Equal(2, this.articleList.Count);
        }

        [Fact]
        public async Task GetAllShouldReturnArticles()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<BlogArticle>>();
            repo.Setup(x => x.AllAsNoTracking()).Returns(this.articleList.AsQueryable());
            repo.Setup(x => x.AddAsync(It.IsAny<BlogArticle>())).Callback(
                (BlogArticle article) => this.articleList.Add(article));
            var categoryRepo = new Mock<IDeletableEntityRepository<BlogCategory>>();
            var articlesService = new ArticlesService(repo.Object, categoryRepo.Object);
            await articlesService.CreateAsync(this.testArticle, "testUser");
            var articles = articlesService.GetAll<ArticleViewModel>(1, 10);

            Assert.Single(articles);
        }

        [Fact]
        public async Task GetCountShouldReturnTheCorrectCount()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<BlogArticle>>();
            repo.Setup(x => x.All()).Returns(this.articleList.AsQueryable());
            repo.Setup(x => x.AddAsync(It.IsAny<BlogArticle>())).Callback(
                (BlogArticle article) => this.articleList.Add(article));
            var categoryRepo = new Mock<IDeletableEntityRepository<BlogCategory>>();
            var articlesService = new ArticlesService(repo.Object, categoryRepo.Object);
            await articlesService.CreateAsync(this.testArticle, "testUser");
            var count = articlesService.GetCount();

            Assert.Equal(1, count);
            await articlesService.CreateAsync(this.testArticle, "testUser");
            count = articlesService.GetCount();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetByIdShouldReturnTheCorrectArticle()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<BlogArticle>>();
            repo.Setup(x => x.AllAsNoTracking()).Returns(this.articleList.AsQueryable());
            repo.Setup(x => x.AddAsync(It.IsAny<BlogArticle>())).Callback(
                (BlogArticle article) => this.articleList.Add(article));
            var categoryRepo = new Mock<IDeletableEntityRepository<BlogCategory>>();
            var articlesService = new ArticlesService(repo.Object, categoryRepo.Object);
            await articlesService.CreateAsync(this.testArticle, "testUser");
            await articlesService.CreateAsync(this.testArticle, "testUser");
            var returnedArticle = articlesService.GetById<ArticleViewModel>(1);

            Assert.Equal("test", returnedArticle.Title);
        }

        [Fact]
        public async Task GetByCatgoryShouldReturnTheCorrectArticles()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<BlogArticle>>();
            repo.Setup(x => x.AllAsNoTracking()).Returns(this.articleList.AsQueryable());
            repo.Setup(x => x.AddAsync(It.IsAny<BlogArticle>())).Callback(
                (BlogArticle article) => this.articleList.Add(article));
            var categoryRepo = new Mock<IDeletableEntityRepository<BlogCategory>>();
            var articlesService = new ArticlesService(repo.Object, categoryRepo.Object);
            await articlesService.CreateAsync(this.testArticle, "testUser");
            await articlesService.CreateAsync(this.testArticle, "testUser");
            var returnedArticle = articlesService.GetByCategory<ArticleViewModel>(1, 10, 1).FirstOrDefault();

            Assert.Equal("test", returnedArticle.Title);
        }
    }
}
