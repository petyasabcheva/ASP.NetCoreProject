using System.Linq;
using System.Threading.Tasks;
using MyWeddingPlanner.Data.Common.Repositories;
using MyWeddingPlanner.Data.Models.Forum;
using MyWeddingPlanner.Services.Data;

namespace MyWeddingPlanner.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<ForumComment> commentsRepository;

        public CommentsService(
            IDeletableEntityRepository<ForumComment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new ForumComment()
            {
                Content = content,
                ParentId = parentId,
                PostId = postId,
                AuthorId = userId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(x => x.PostId).FirstOrDefault();
            return commentPostId == postId;
        }
    }
}
