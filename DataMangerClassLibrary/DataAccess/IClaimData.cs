using DataMangerClassLibrary.Models;
using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public interface IClaimData
    {
        DataSet GetBaseBenefit(CLaimBenefitModel model);
        DataSet GetClaimRecords(int organinsuredcode, int year);
        string SubmitClaim(ClaimModel model);
    }
}