using GMLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GMLink.Models
{
    public class EFAppUserDetailRepository : IAppUserDetailRepository
    {
        private ApplicationDbContext context;
        public EFAppUserDetailRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<AppUserDetail> AppUserDetails => context.AppUserDetails;
        public void SaveAppUserDetail(AppUserDetail appUserDetail)
        {
            if (appUserDetail.AppUserDetailID == 0)
            {
                context.AppUserDetails.Add(appUserDetail);
            }
            else
            {
                AppUserDetail dbEntry = context.AppUserDetails.FirstOrDefault(p => p.AppUserDetailID == appUserDetail.AppUserDetailID);
                if (dbEntry != null)
                {
                    dbEntry.Username = appUserDetail.Username;
                    dbEntry.FirstName = appUserDetail.FirstName;
                    dbEntry.LastName = appUserDetail.LastName;
                    dbEntry.Email = appUserDetail.Email;
                    dbEntry.PhoneNumber = appUserDetail.PhoneNumber;
                    dbEntry.Address = appUserDetail.Address;
                }
            }
            context.SaveChanges();
        }
    }
}