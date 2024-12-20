﻿using CarBook.Application.Intefaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values= _context.Blog.Include(x=>x.Author).OrderByDescending(x=>x.BlogId).Take(3).ToList(); // blog sayfasında ilk 3 e  göre yazar sıralama yapar.
            return values;

            
        }
    }
}
