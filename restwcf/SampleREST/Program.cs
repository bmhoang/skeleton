using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace SampleREST
{
    class Program
    {
        static void Main(string[] args)
        {
            //netsh http add urlacl url = http://+:8080/ user=Everyone
            var host = new WebServiceHost(typeof(SampleService), new Uri("http://localhost:8080/"));

            try
            {
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(ISampleService), new WebHttpBinding() { TransferMode = TransferMode.Streamed }, "");
                host.Open();
                Console.WriteLine("Server started!");
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
            }
            Console.ReadLine();
            host.Close();

        }
    }
}
