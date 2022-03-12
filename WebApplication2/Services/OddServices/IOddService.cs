using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services.OddServices
{
    public interface IOddService
    {
        int CreateOdd(CreateOddDto dto);
        Odd? GetByMatchId(int match_id);
    }
}