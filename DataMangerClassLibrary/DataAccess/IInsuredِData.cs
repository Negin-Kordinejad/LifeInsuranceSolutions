using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public interface IInsuredِData
    {
        DataSet GetInsuredData(long nationalcode, int unitcode);
    }
}