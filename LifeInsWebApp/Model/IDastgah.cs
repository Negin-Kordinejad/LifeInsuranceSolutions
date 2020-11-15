using System.Web.UI;

namespace LifeInsWebApp.Model
{
    public interface IDastgah
    {
        string AccountNumber { get; }
        string BankName { get; }
        int Branch_Code { get; }
        string Branch_Name { get; }
        int DastgahCode { get; }
        string DastgahName { get; }
        bool IsValid { get; }
        long MaliNo { get; }
        long Mobile { get; }
        byte Sepehr { get; }
        string TelNo { get; }

        string GetString();
        bool Redirect(Page page);
        void Refresh(int dastgahCode);
    }
}