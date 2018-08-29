using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class CosmosDBTriggerCSharp
    {
        [FunctionName("CosmosDBTriggerCSharp")]
        public static void Run([CosmosDBTrigger(
            databaseName: "outDatabasePortal",
            collectionName: "MyCollectionPortal",
            ConnectionStringSetting = "organics-db_DOCUMENTDB",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}


// [FunctionName("CosmosDbSample")]
// public static async Task Run(
//     [CosmosDBTrigger("ToDoList","Items", ConnectionStringSetting = "CosmosDB")] IReadOnlyList<Document> documents,
//     TraceWriter log,
//     [DocumentDB("ToDoList", "Migration", ConnectionStringSetting = "CosmosDB", CreateIfNotExists = true)] IAsyncCollector<Document> documentsToStore)
// {
//     foreach (var doc in documents)
//     {
//         log.Info($"Processing document with Id {doc.Id}");
//         // work with the document, process or create a new one
//         await documentsToStore.AddAsync(doc);
//     }
// }