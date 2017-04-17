using Microsoft.AspNet.Identity;
using PointRest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PointRest.Controllers
{
    public class UserController : ApiController
    {
        ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //api/User
        public IEnumerable<ApplicationUser> getUsers()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUsers = _context.Users.Include(u=>u.Points).ToList();
            return currentUsers;
        }

    }
}