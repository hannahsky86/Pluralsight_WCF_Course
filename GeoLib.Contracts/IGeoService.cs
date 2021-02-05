using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Contracts
{
/* 
 * The incomming data can be a Data Contract or individual arguments. 
 * In this case we are sending in a zip code and receiving zip code information in the form of the ZipCodeData contract
 * It is not a service contract until it is decorated with ServiceContract attribute. 
 * Then each of the operations need to be decorated with the OperationContract attribute.
 */

    [ServiceContract]
    public interface IGeoService
    {
        [OperationContract]
        ZipCodeData GetZipInfo(string zip);

        //This operation will retrieve a list of states 
        //Add an argument 
        //Add a flag to this operation to allow it to retrieve just the primary states or all of the states
        //Return is a list of strings
        //We dont need Data Contract because we are not wrapping multiple types together
        //By default, all single, simple, types are considered data contracts by default
        [OperationContract]
        IEnumerable<string> GetStates(bool primaryOnly);


        //The next two operations will retrieve a list of ZipCodeData data contracts
        //One by state the other within range of a given zip code
        //In .NET it is ok to overload a method. In WCF it is not as acceptable. 
        //WCF is meant to be interoperable with systems that are designed to read just SOAP standards and not know anything about .NET
        //So, WCF requires each method to have its own name.
        //If you are not going to change the method name, make sure that they are remapped to a unique name in the property.
        [OperationContract(Name = "GetZipCodeByState")]
        IEnumerable<ZipCodeData> GetZips(string state);

        [OperationContract(Name = "GetZipCodeForRange")]
        IEnumerable<ZipCodeData> GetZips(string state, int range);


        //We've now defined the API in the contracts project and we are ready to implement it by service. 
        //Later we will use this API to access the service from a client.
    }
}
