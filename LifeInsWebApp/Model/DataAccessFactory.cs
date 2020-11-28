using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataMangerClassLibrary.DataAccess;
using LifeInsWebApp.InsuredAgentOrg;
using LifeInsWebApp.Helper;

namespace LifeInsWebApp.Model
{
    public static class DataAccessFactory
    {
        //private static Dictionary<Type, object> _services = new Dictionary<Type, object>();
        //    _services.Add(DataAccessType, new ClaimData());
        //    return (IClaimData)_services[DataAccessType];
        public static IClaimData CreateClaimData()
        {
            return new ClaimData();
        }
        public static IDeathReasonData CreateDeathReasonData()
        {
            return new DeathReasonData();
        }
        public static IDisableTypesData CreateDisableTypeData()
        {
            return new DisableTypesData();
        }
        public static IInsuredِData CreateInsuredData()
        {
            return new InsuredِData();
        }
        public static IContractData CreateContractData()
        {
            return new ContractData();
        }
        public static IDepositData CreateDepositData()
        {
            return new DepositData();
        }
        public static Dastgah CreateDastgah()
        {
            return new Dastgah(CreateOrganInsuredData());
        }
        public static IOrganInsuredData CreateOrganInsuredData()
        {
            return new OrganInsuredData();
        }
        public static ILogger Log()
        {
            return new TextLogger();
        }
    }
}