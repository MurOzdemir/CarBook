﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public GetAboutByIdQuery(int id)    //yapıcı metod olarak kullanılır.
        {
            Id = id;
        }
        public int Id { get; set; }

       
    }
}
