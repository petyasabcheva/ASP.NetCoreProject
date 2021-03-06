﻿namespace MyWeddingPlanner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;
    using MyWeddingPlanner.Data.Common.Repositories;
    using MyWeddingPlanner.Data.Models.Forum;
    using MyWeddingPlanner.Services.Mapping;
    using MyWeddingPlanner.Web.ViewModels.Forum;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<ForumPost> postsRepository;
        private readonly IDeletableEntityRepository<ForumCategory> categoryRepository;

        public PostsService(IDeletableEntityRepository<ForumPost> postsRepository, IDeletableEntityRepository<ForumCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            this.postsRepository = postsRepository;
        }

        public async Task CreateAsync(CreatePostInputModel input, string userId)
        {
            var item = new ForumPost()
            {
                Title = input.Title,
                Content = input.Content,
                AuthorId = userId,
            };

            var category = this.categoryRepository.All().FirstOrDefault(x => x.Id == input.CategoryId);
            item.Category = category;

            await this.postsRepository.AddAsync(item);
            await this.postsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var items = this.postsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>().ToList();
            return items;
        }

        public int GetCount()
        {
            return this.postsRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            var vendor = this.postsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return vendor;
        }

        public IEnumerable<T> GetByCategory<T>(int page, int itemsPerPage, int categoryId)
        {
            var items = this.postsRepository
                .All().Where(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>().ToList();
            return items;
        }
    }
}
