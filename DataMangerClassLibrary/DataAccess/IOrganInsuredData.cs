using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public interface IOrganInsuredData
    {
        DataSet GetOrganInsuredData(int organinsuredcode);
        string GetOrganLoginData(int organinsuredcode);
        string GetOrganEmail(int organinsuredcode);
    }
}