using CodeForProject.Models;

namespace CodeForProject.Services.Interfaces
{
	public interface IDatabaseService
	{
		public Task UpsertSupportMessage(SupportMessage supportMessage);

		public Task<List<SupportMessage>> GetSupportMessagesAsync();
	}
}
