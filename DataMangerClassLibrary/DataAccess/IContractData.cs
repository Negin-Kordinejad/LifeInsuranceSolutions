using DataMangerClassLibrary.Models;
using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public interface IContractData
    {
        DataSet GetContractInit(int organinsuredcode);
        string SubmitContract(ContractModel model);
    }
}