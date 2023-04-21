namespace GMLink.Models
{
    public interface IPlayerAccountRepository
    {
        IEnumerable<PlayerAccount> PlayerAccounts { get; }
        void SavePlayerAccount(PlayerAccount playerAccount);
    }
}
