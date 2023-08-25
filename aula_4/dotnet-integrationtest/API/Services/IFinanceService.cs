namespace API.Services
{
    public interface IFinanceService { Task<IEnumerable<QuoteResult>> GetAllTrending(); }
}