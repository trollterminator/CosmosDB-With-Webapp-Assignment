using Azure.Identity;
using CodeForProject.Models;
using CodeForProject.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using static System.Net.WebRequestMethods;
namespace CodeForProject.Services
{
	public class DatabaseService : IDatabaseService
	{
		private readonly CosmosClient _client;

		public DatabaseService(IConfiguration configuration)
		{
			_client = new CosmosClient("AccountEndpoint=https://ibas-db-account.documents.azure.com:443/;AccountKey=henz3FJY8Dn5msn78RNDtCWBVgh2snzj6uc6bCqwJ7qBcdRrGiTekKvIqPH1JXUJvhXGiruQr3FNACDbRaTJ4A==;");

			Database database = _client.GetDatabase("IBasSupportDB");

			Container container = database.GetContainer("ibassupport");
		}

		public async Task UpsertSupportMessage(SupportMessage supportMessage)
		{
			try
			{
			Database database = _client.GetDatabase("IBasSupportDB");
			
			Container container = database.GetContainer("ibassupport");
				Console.WriteLine(container.ToString());


				await container.UpsertItemAsync(item: supportMessage);
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}

		public async Task<List<SupportMessage>> GetSupportMessagesAsync()
		{
			Database database = _client.GetDatabase("IBasSupportDB");

			Container container = database.GetContainer("ibassupport");
			Console.WriteLine(container.ToString());
			List<SupportMessage> supportMessages = new ();

			using FeedIterator<SupportMessage> feed = container.GetItemQueryIterator<SupportMessage>("SELECT * FROM c");

			while (feed.HasMoreResults)
			{
				FeedResponse<SupportMessage> response = await feed.ReadNextAsync();

				foreach (var item in response)
				{
					supportMessages.Add(item);
				}
			}

			return supportMessages;

		}

	}
}
