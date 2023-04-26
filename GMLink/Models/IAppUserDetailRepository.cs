using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GMLink.Models
{
    public interface IAppUserDetailRepository
    {
        IEnumerable<AppUserDetail> AppUserDetails { get; }
        void SaveAppUserDetail(AppUserDetail appUserDetail);
    }
}