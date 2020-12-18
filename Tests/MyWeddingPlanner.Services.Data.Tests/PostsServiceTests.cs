namespace MyWeddingPlanner.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Moq;
    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Forum;
    using MyWeddingPlanner.Services.Mapping;
    using MyWeddingPlanner.Web.ViewModels.Forum;
    using Xunit;

    public class PostsServiceTests
    {
        private CreatePostInputModel testPost;
        private List<ForumPost> postsList;

        public void Setup()
        {
            this.testPost = new CreatePostInputModel()
            {
                Title = "test",
                CategoryId = 1,
                Content =
                    "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest",
            };

            this.postsList = new List<ForumPost>();
            AutoMapperConfig.RegisterMappings(typeof(PostViewModel).Assembly, typeof(ForumPost).Assembly);
        }

        [Fact]
        public async Task PostsShouldBeAddedSuccessfully()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<ForumPost>>();
            repo.Setup(x => x.AddAsync(It.IsAny<ForumPost>())).Callback(
                (ForumPost post) => this.postsList.Add(post));
            var categoryRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var postsService = new PostsService(repo.Object, categoryRepo.Object);

            await postsService.CreateAsync(this.testPost, "testUser");
            Assert.Single(this.postsList);
            Assert.Equal(this.testPost.Title, this.postsList.First().Title);

            await postsService.CreateAsync(this.testPost, "testUser");

            Assert.Equal(2, this.postsList.Count);
        }

        [Fact]
        public async Task GetAllShouldReturnCorrectArticles()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<ForumPost>>();
            repo.Setup(x => x.All()).Returns(this.postsList.AsQueryable());
            repo.Setup(x => x.AddAsync(It.IsAny<ForumPost>())).Callback(
                (ForumPost post) => this.postsList.Add(post));
            var categoryRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var postsService = new PostsService(repo.Object, categoryRepo.Object);
            await postsService.CreateAsync(this.testPost, "testUser");
            var articles = postsService.GetAll<PostViewModel>(1, 10);

            Assert.Single(articles);
        }

        [Fact]
        public async Task GetCountShouldReturnTheCorrectCount()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<ForumPost>>();
            repo.Setup(x => x.All()).Returns(this.postsList.AsQueryable());
            repo.Setup(x => x.AddAsync(It.IsAny<ForumPost>())).Callback(
                (ForumPost post) => this.postsList.Add(post));
            var categoryRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var postsService = new PostsService(repo.Object, categoryRepo.Object);
            await postsService.CreateAsync(this.testPost, "testUser");
            var count = postsService.GetCount();

            Assert.Equal(1, count);
            await postsService.CreateAsync(this.testPost, "testUser");
            count = postsService.GetCount();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetByIdShouldReturnCorrectPost()
        {
            this.Setup();
            var repo = new Mock<IDeletableEntityRepository<ForumPost>>();
            repo.Setup(x => x.AllAsNoTracking()).Returns(this.postsList.AsQueryable());
            repo.Setup(x => x.AddAsync(It.IsAny<ForumPost>())).Callback(
                (ForumPost post) => this.postsList.Add(post));
            var categoryRepo = new Mock<IDeletableEntityRepository<ForumCategory>>();
            var postsService = new PostsService(repo.Object, categoryRepo.Object);
            await postsService.CreateAsync(this.testPost, "testUser");
            var postReturned = postsService.GetById<PostViewModel>(1);

            Assert.Equal("test", postReturned.Title);
        }
    }
}
