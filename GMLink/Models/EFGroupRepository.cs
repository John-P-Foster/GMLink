using GMLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GMLink.Models
{
    public class EFGroupRepository : IGroupRepository
    {
        private ApplicationDbContext context;
        public EFGroupRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Group> Groups => context.Groups;
        public void SaveGroup(Group group)
        {
            if (group.GroupID == 0)
            {
                context.Groups.Add(group);
            }
            else
            {
                Group dbEntry = context.Groups.FirstOrDefault(p => p.GroupID == group.GroupID);
                if (dbEntry != null)
                {
                    dbEntry.GroupID = group.GroupID;
                    dbEntry.Member1 = group.Member1;
                    dbEntry.Member2 = group.Member2;
                    dbEntry.Member3 = group.Member3;    
                    dbEntry.Member4 = group.Member4;
                    dbEntry.Member5 = group.Member5;
                    dbEntry.Member6 = group.Member6;
                }
            }
            context.SaveChanges();
        }
    }
}