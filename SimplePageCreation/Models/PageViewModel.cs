using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplePageCreation.Models
{
    public class PageViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class PageListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }

}