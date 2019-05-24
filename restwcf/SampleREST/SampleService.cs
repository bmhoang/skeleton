using System.IO;
using System.Net;
using System.ServiceModel.Web;
using System.Text;

namespace SampleREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SampleService" in both code and config file together.
    public class SampleService : ISampleService
    {
        public void DoWork()
        {
        }

        public string index()
        {
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return "Hello World!";

        }

        public Stream media(string id)
        {
            // See http://blogs.msdn.com/b/justinjsmith/archive/2007/08/22/setting-http-headers-in-wcf-net-3-5.aspx
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            return new MemoryStream(Encoding.UTF8.GetBytes(id));

        }

        public Stream resource(string location)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(location));
        }
    }
}
