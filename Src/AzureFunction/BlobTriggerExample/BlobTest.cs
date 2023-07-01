using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BlobTriggerExample
{
    public class BlobTest
    {
        [FunctionName("BlobTest")]
        public void Run([BlobTrigger("prabhocontainer/{name}", Connection = "blob-conn")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }

        // added this conn in "local.settings.json" - strorage account connection string
        //"blob-conn": "DefaultEndpointsProtocol=https;AccountName=prabhoblobstorage;AccountKey=3zdNj3joNyR9bZkxjsLwJWe97NNuGFqGGvrO2FixulTf0GHsEqRbrOL0IQ5z7KTBCCwYqAQJCaFx+AStNMIkiQ==;EndpointSuffix=core.windows.net"

    }
}
