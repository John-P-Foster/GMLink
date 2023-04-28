using GMLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace GMLink.Controllers
{
    public class GroupController : Controller
    {
        private IGroupRepository repository;

        public GroupController(IGroupRepository repo)
        {
            repository = repo;
        }
        public ViewResult ListGroups() => View(repository.Groups
            .OrderBy(p => p.GroupID));
    }
}
