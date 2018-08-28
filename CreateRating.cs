
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;


namespace Company.Function
{
    public static class CreateRating
    {
        [FunctionName("CreateRating")]
        public async static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req,
            ILogger log,
             [DocumentDB(databaseName: "ToDoList", collectionName: "Migration", ConnectionStringSetting = "organics-db_DOCUMENTDB", CreateIfNotExists = true)] IAsyncCollector<Document> documentsToStore)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            
            // var documents = new IReadOnlyList<Document>; 
            // foreach (var doc in documents)
            // {
            //     log.LogInformation($"Processing document with Id {doc.Id}");
            //     // work with the document, process or create a new one
            //     await documentsToStore.AddAsync(doc);
            // }

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
