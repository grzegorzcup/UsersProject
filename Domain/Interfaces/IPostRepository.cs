﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();

        Post GetById(int id);

        Post Add(Post post);
        Post Update(Post post);
        void Delete(Post post);
    }
}