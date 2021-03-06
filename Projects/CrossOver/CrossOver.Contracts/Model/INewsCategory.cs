﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.Contracts.Model
{
    public interface INewsCategory
    {
        int CategoryId { get; set; }
        string CategoryName { get; set; }

        ICollection<INewsArticle> NewsArticles { get; set; }
    }
}
