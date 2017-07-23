using BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL
{
    public class HandleData
    {
        private DAL.ApplicationDbContext _dbContext = new DAL.ApplicationDbContext();

        public List<Page> GetPages()
        {
            return _dbContext.Pages.ToList();
        }

        public Page GetPage(Guid pagedId)
        {
            return _dbContext.Pages.Where(p => p.Id == pagedId).FirstOrDefault();
        }

        public bool IsCorrectPAssword(string password, Guid pagedId)
        {
            var page = _dbContext.Pages.Where(p => p.Id == pagedId).FirstOrDefault();
            if (page != null)
            {
                return password == page.Password;
            }

            return false;
        }

        public Page AddPage(Page page)
        {
            return _dbContext.Pages.Add(page);
        }

        public void UpdatePage(Page page)
        {
            _dbContext.Entry(page).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}