using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    [Table("Page")]
    public class Page
    {
        public Guid Id { get; set; }

        [MaxLength(199)]
        public string Title { get; set; }

        [MaxLength(499)]
        public string Description { get; set; }
        public string Content { get; set; }
        public string Password { get; set; }

        public Page(string title,string description,string content,string password)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Content = content;
            Password = password; 
        }

        public Page()
        {

        }
    }
}
