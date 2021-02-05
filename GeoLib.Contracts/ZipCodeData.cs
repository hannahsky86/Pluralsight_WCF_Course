using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Contracts
{
    /* 
     * The naming is important
     * End data contracts with word Data
     * Add three properites: city, state, zip
     * User automatic property syntax to save space 
     * To make this a data contract, decorate the class with an attribute called 
     * Data Contract. This attribute comes from the System.Runtime.Serialization namespace, 
     * and assembly of the same type. 
     * Make sure to reference System.ServiceModel. Everything in the solution will reference this.
     * Once you use Data Contract, it will not serialize anything that is not decorated with DataMember
     * Add Data Member to each of the methods
     * Now you have a Data Contract that is ready for serialization
     * Google: What is serialization in WCF? With respect to WCF, Serialization is the process of converting an
     * object into an XML representation. 
     * If you are using an entity for more than one purpose, you can leave out the DataContract. It is serialized by default.
     * When it is used specifically for a WCF data contract, leave it in. 
     * 
   */

    [DataContract]
    public class ZipCodeData
    {
        [DataMember]
        public string City { get; set; }
        
        [DataMember]
        public string State { get; set; }
        
        [DataMember]
        public int Zip { get; set; }
    }
}
