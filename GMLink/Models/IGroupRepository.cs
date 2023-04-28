using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GMLink.Models
{
    public interface IGroupRepository
    {
        IEnumerable<Group> Groups { get; }
        void SaveGroup(Group group);
    }
}