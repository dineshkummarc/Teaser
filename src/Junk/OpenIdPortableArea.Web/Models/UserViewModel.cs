using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Services.Entities;

namespace MvcApplication1.Models
{
    public class UserViewModel
    {
    }

    public class UserListViewModel
    {
        // Constructor
        public UserListViewModel(List<User> list, int currentPage, int maximumPage)
        {
            this.List = list;
            CurrentPage = currentPage;
            MaximumPage = maximumPage;
        }
        public List<User> List { get; set; }
        public int CurrentPage { get; set; }
        public int MaximumPage { get; set; }
    }
}
