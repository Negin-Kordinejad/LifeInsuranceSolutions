using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public interface IDepositData
    {
        DataSet CheckDepositValues(DataTable dt);
    }
}