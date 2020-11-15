using Cspf.Model.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMangerClassLibrary.Models
{
    public class ClaimModel
    {
        /// <summary>
        /// 
        /// </summary>
        private long _nationalCode;
        /// <summary>
        /// 
        /// </summary>
        private int _unitCode;
        /// <summary>
        /// 
        /// </summary>
        private string _accsidentDate;
        /// <summary>
        /// 
        /// </summary>
        private int _death_Reason_Id;
        /// <summary>
        /// 
        /// </summary>
        private string _elatefot;
        /// <summary>
        /// 
        /// </summary>
        private string _elatenaqseozv;
        /// <summary>
        /// 
        /// </summary>
        private int _disable_Reason_Id;
        /// <summary>
        /// 
        /// </summary>
        private int _naqsozvitems;
        /// <summary>
        /// 
        /// </summary>
        private int _gharamatValue;
        private int _originalGharamatValue;
        private string _accountNo;
        private string _bankName;
        private int _bankCode;
        private string _regDate;
        private int _regUserId;
        private int _formId;
        private Byte[] _kartemeliImage;
        /// <summary>
        /// 
        /// </summary>
        private Byte[] _gavahifotImage;
        /// <summary>
        /// 
        /// </summary>
        private Int16 _gharamatType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 
        private string _mobile;

        public long NationalCode
        {

            get
            {
                return _nationalCode;
            }
            set
            {
                // 1. Validate that the current & new value aren't the same.  
                if (_nationalCode == value)
                {
                    return;
                }
                // 2. Validate that value isn't null  
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException(nameof(NationalCode),
                               "Value for NationalCode cannot be null or empty.");
                }
                // 3. Validate that the value is within range  
                if (value.ToString().Length != 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(NationalCode),
                               "NationalCode must be between 10 characters.");
                }
                _nationalCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UnitCode
        {
            get
            {
                return this._unitCode;
            }

            set
            {
                if (this._unitCode == value)
                {
                    return;
                }

                if (value == 0)
                {
                    throw new ArgumentNullException(nameof(UnitCode), "Value for Id cannot be null or empty.");
                }

                this._unitCode = value.ToString().Length > 8 ? throw new ArgumentOutOfRangeException(nameof(this.UnitCode),
                             "Organ code length should to 8 digits.") : value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccsidentDate
        {
            get
            {
                return this._accsidentDate;
            }

            set
            {
                if (this._accsidentDate == value)
                {
                    return;
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(AccsidentDate), "Value for date of accssident cannot be null.");
                }

                this._accsidentDate = value.Length > 10 ? throw new ArgumentOutOfRangeException(nameof(AccsidentDate),
                                    "The date of accssident is limited to 8 characters.") : value;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public int Death_Reason_Id
        {
            get { return _death_Reason_Id; }
            set
            {
                this._death_Reason_Id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Elatefot
        {
            get
            {
                return this._elatefot;
            }

            set
            {
                if (this._elatefot == value)
                {
                    return;
                }

                this._elatefot = value.Length > 10 ? throw new ArgumentOutOfRangeException(nameof(Elatefot),
                                    "The reason of death is limited to 8 characters.") : value;
            }
        }
        /// <summary>
        /// 
        /// </summary>


        public string Elatenaqseozv
        {
            get
            {
                return this._elatenaqseozv;
            }

            set
            {
                if (this._elatenaqseozv == value)
                {
                    return;
                }

                this._elatenaqseozv = value.Length > 50 ? throw new ArgumentOutOfRangeException(nameof(Elatenaqseozv),
                                    "The reason of disability is limited to 8 characters.") : value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Disable_Reason_Id
        {
            get { return _disable_Reason_Id; }
            set
            {
                this._disable_Reason_Id = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NaqsozvItems
        {
            get { return _naqsozvitems; }
            set
            {
                this._naqsozvitems = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GharamatValue
        {
            get { return _gharamatValue; }
            set
            {
                this._gharamatValue = value;
            }
        }
    /// <summary>
    /// 
    /// </summary>
    public int OriginalGharamatValue
        {
            get { return _originalGharamatValue; }
            set
            {
                this._originalGharamatValue = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccountNo
        {

            get
            {
                return _accountNo;
            }
            set
            {
                // 1. Validate that the current & new value aren't the same.  
                if (_accountNo == value)
                {
                    return;
                }
                // 2. Validate that value isn't null  
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(AccountNo),
                               "Value for Accountnumber cannot be null or empty.");
                }
                // 3. Validate that the value is within range  
                if (value.Length > 30)
                {
                    throw new ArgumentOutOfRangeException(nameof(AccountNo),
                               "Accountnumber should be to 30 characters.");
                }
                _accountNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            get
            {
                return this._bankName;
            }

            set
            {
                if (this._bankName == value)
                {
                    return;
                }

                this._bankName = value.Length > 50 ? throw new ArgumentOutOfRangeException(nameof(BankName),
                                    "Thename of Bank is limited to 8 characters.") : value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BankCode
        {
            get { return _bankCode; }
            set
            {
                this._bankCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegDate { get; private set; } = CspfConvert.ToPersianText(DateTime.Now).Replace("/", "").Trim();
        /// <summary>
        /// 
        /// </summary>
        public int RegUserId
        {
            get { return _regUserId; }
            set
            {
                this.RegUserId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FormId
        {
            get { return _formId; }
            set
            {
                this._formId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Byte[] KartemeliImage
        {
            get { return _kartemeliImage; }
            set
            {
                this._kartemeliImage = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Byte[] GavahifotImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int16 GharamatType
        {
            get { return _gharamatType; }
            set
            {
                this._gharamatType = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataTable DisableTable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Mobiles
        {
            get
            {
                return this._mobile;
            }

            set
            {
                if (this._mobile == value)
                {
                    return;
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Mobiles), "Value for phone number cannot be null.");
                }

                this._mobile = value.Length > 50 ? throw new ArgumentOutOfRangeException(nameof(Mobiles),
                                    "Phone number is limited to 50 characters.") : value;
            }
        }


    }
}
