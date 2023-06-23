using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp2
{
    public class ImageResizeFunction
    {
        [FunctionName("ImageResizeFunction")]
        public void Run([BlobTrigger("prabhohighsize/{name}", Connection = "DefaultEndpointsProtocol=https;AccountName=prabhostorageaz;AccountKey=DlVu6Feeq6XLeoKJCdZ2Oxf3TsOVyEEbw90B4MG/6/BajnxNGVIPMf3x7p2vT8X2f/+avfJK/Ska+AStQCsKvw==;EndpointSuffix=core.windows.net")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
