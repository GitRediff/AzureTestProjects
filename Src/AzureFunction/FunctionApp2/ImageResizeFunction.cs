using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace FunctionApp2
{
    [StorageAccount("BlobConnectionString")]
    public class ImageResizeFunction
    {
        [FunctionName("ImageResizeFunction")]
        public void Run(
            [BlobTrigger("prabhohighsize/{name}")] Stream inputBlob,
            [Blob("prabholowsize/{name}", FileAccess.Write)] Stream outputBlob,
            string name, 
            ILogger log)
        {
            using (Image image = Image.Load(inputBlob))
            {
                image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
                image.Save(outputBlob, new JpegEncoder());
            }

            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");
        }
    }
}
