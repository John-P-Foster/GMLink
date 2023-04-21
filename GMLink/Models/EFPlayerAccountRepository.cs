namespace GMLink.Models
{
    public class EFPlayerAccountRepository : IPlayerAccountRepository
    {
        private ApplicationDbContext context;
        public EFPlayerAccountRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<PlayerAccount> PlayerAccounts => context.PlayerAccounts;
        public void SavePlayerAccount(PlayerAccount playerAccount)
        {
            if (playerAccount.PlayerAccountID == 0)
            {
                context.PlayerAccounts.Add(playerAccount);
            }
            else
            {
                PlayerAccount dbEntry = context.PlayerAccounts.FirstOrDefault(p => p.PlayerAccountID == playerAccount.PlayerAccountID);
                if (dbEntry != null)
                {
                    dbEntry.Name = playerAccount.Name;
                    dbEntry.Username = playerAccount.Username;
                    dbEntry.Password = playerAccount.Password;
                    dbEntry.Address = playerAccount.Address;
                    dbEntry.PhoneNumber = playerAccount.PhoneNumber;
                    dbEntry.Email = playerAccount.Email;
                    dbEntry.CardNumber = playerAccount.CardNumber;
                    dbEntry.ExpirationDate = playerAccount.ExpirationDate;
                    dbEntry.CardholderName = playerAccount.CardholderName;
                    dbEntry.SecurityCode = playerAccount.SecurityCode;
                }
            }
            context.SaveChanges();
        }

    }
}
