using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MathServiceLib
{
    /*
     * Defineing the C in ABC : Contract
     * To be a WCF contract and published to the client
     * 
     *      to qualify this interface as a WCF contract, you must annotate
     *      it with attributes
     *      [ServiceContract] for the interface
     *      [OperationContract] for methods
     *      These attributes are defined in the System.ServiceModel
     *      need a using System.ServiceModel
     */
     [ServiceContract]
    public interface IMath
    {
        [OperationContract]
        int Add(int x, int y);
    }
}
