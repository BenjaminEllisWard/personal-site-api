using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using Infrastructure.Models;
using System.Linq;

namespace Infrastructure.Persistence
{
    public interface IGuestbookRepository
    {
        Task<IEnumerable<GuestbookEntry>> GetGuestbookEntries();
        Task<bool> InsertGuestbookEntry(GuestbookEntry entry);
    }

    public class GuestbookRepository : IGuestbookRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GuestbookRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<GuestbookEntry>> GetGuestbookEntries()
        {
            using (var db = _sqlConnectionFactory.Open())
            {
                const string sql = @"SELECT Name, Message, CreatedAt as Date
                                    FROM GuestbookEntry;";

                return await db.QueryAsync<GuestbookEntry>(sql);
            }
        }

        public async Task<bool> InsertGuestbookEntry(GuestbookEntry entry)
        {
            const string sql = @"INSERT INTO GuestbookEntry VALUES (@Name, @Message, @Date)
                                SELECT SCOPE_IDENTITY();";

            using (var db = _sqlConnectionFactory.Open())
            {
                var result = await db.QueryAsync<int>(sql, entry);

                return result.Single() > 0;
            }
        }
    }
}
