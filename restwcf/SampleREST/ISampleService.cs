using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SampleREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISampleService" in both code and config file together.
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// Index page
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet]
        string index();

        /// <summary>
        /// Pattern with param
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "media/{id}")]
        Stream media(string id);

        /// <summary>
        /// With exception
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet]
        [FaultContract(typeof(Exception))]
        Stream resource(string location);

    }
}
