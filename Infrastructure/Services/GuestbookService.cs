using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Infrastructure.Models;
using Infrastructure.Models.Requests;

namespace Infrastructure.Services
{
    public interface IGuestbookService
    {
        Task<bool> PostAsync(GuestbookEntryPostRequest request);
        Task<IEnumerable<GuestbookEntry>> GetAsync();
    }
    public class GuestbookService : IGuestbookService
    {
        private readonly IGuestbookRepository _guestbookRepository;

        public GuestbookService(IGuestbookRepository guestbookRepository)
        {
            _guestbookRepository = guestbookRepository;
        }

        public async Task<IEnumerable<GuestbookEntry>> GetAsync()
        {
            return await _guestbookRepository.GetGuestbookEntries();
        }

        public async Task<bool> PostAsync(GuestbookEntryPostRequest request)
        {
            var model = GetModelFromPostRequest(request);
            var success = await _guestbookRepository.InsertGuestbookEntry(model);

            return success;
        }

        private GuestbookEntry GetModelFromPostRequest(GuestbookEntryPostRequest request)
        {
            return new GuestbookEntry
            {
                Name = request.Name,
                Message = request.Message,
                Date = DateTime.UtcNow
            };
        }
    }
}
