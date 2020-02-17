using Newtonsoft.Json;
using System;
using DataNova.Common;
namespace DNClientAPI.Models {
  public class DNCustomer : BaseModel {
    #region variables
    private long _customerNumber;
    private long? _customerDebitorNumber;
    private long? _dateofBirthLong;
    private long? _customerRegistrationDate;
    private string _customerName, _customerAddress, _customerCity, _customerPincode,
      _customerEmail, _customerMobileNumber, _customerCategory;
    private string _accountNumber;
    private string _bankAccountNumber;
    private string _billingCategory;
    private object _card;
    private long? _categoryNumber;
    private bool _consentExportData;
    private DNContactDetail _contactDetails;
    private double? _creditLimit;
    private bool _creditLimitCode;
    private int? _creditLimitDays;
    private DNCustomerCreditType _creditType;
    private float? _creditUsed;
    private object _customerImage;
    private bool _isCredit;
    private DateTime _customerLastModifiedDate;
    private int _daysInMonth;
    private int? _discount;
    private bool _government;
    private int? _group;
    private string _iban;
    private DNCustomerIdentity _identity;
    private bool _itemAccumulator;
    private long? _lastChanged;
    private string _lcgNumber;
    private string _locationId;
    private string _loginId;
    private object _loyaltyCards;
    private bool _matrixDiscount;
    private bool _member;
    private string _organizationNumber;
    private string _originalShop;
    private bool _isOutState;
    private bool _isOverrideSurchage;
    private string _parentNumber;
    private string _password;
    private object _personalNumber;
    private bool _isPrivateCustomer;
    private object _projects;
    private bool _receivesDirectMail;
    private bool _isSalesAllowed;
    private string _securityNumber;
    private string _sex;
    private string _shortName;
    private bool _staffMember;
    private string _swift;
    private string _unit;
    private string _userId;
    private bool _vatFree;
    private string _vatId;
    private DateTime _birthDate;
    private DNCustomerCategory _category;
    private DNGiftVouchers _giftVouchers;
    private DNAddress _deliveryAddress;
    private DNAddress _correspondenceAddress;
    private string _note;
    private string _creditTypedisplay;
    #endregion

    public DNCustomer() {
      DeliveryAddress = new DNAddress();
      CorrespondenceAddress = new DNAddress();
      Category = new DNCustomerCategory();
      //GiftVouchers = new DNGiftVouchers();
      ContactDetails = new DNContactDetails();
			CustomerRegistrationDateDate = DateTime.Now.ToString("dd.MM.yyyy");
      IsSalesAllowed = true;
      MatrixDiscount = true;
		}


    [JsonProperty("customer_number")]
    public long CustomerNumber {
      get { return _customerNumber; }
      set {
        if (_customerNumber != value) {
          _customerNumber = value ;
          OnPropertyChanged();
        }
      }
    }

    [JsonProperty("debitor_number")]
    public long? CustomerDebitorNumber {
      get { return _customerDebitorNumber; }
      set {
        if (_customerDebitorNumber != value) {
          _customerDebitorNumber = value;
          OnPropertyChanged();
        }
      }
    }

    [JsonProperty("name")]
    public string CustomerName {
      get { return _customerName; }
      set {
        if (_customerName != value) {
          _customerName = value;
          OnPropertyChanged();
        }
      }
    }

    [JsonIgnore]
    public string CustomerAddress {
      get { return _customerAddress; }
      set {
        if (_customerAddress != value) {
          _customerAddress = value;
          OnPropertyChanged();
        }
      }
    }

    [JsonIgnore]
    public string CustomerCity {
      get { return _customerCity; }
      set {
        if (_customerCity != value) {
          _customerCity = value;
          OnPropertyChanged();
        }
      }
    }
    [JsonIgnore]
    public string CustomerPincode {
      get { return _customerPincode; }
      set {
        if (_customerPincode != value) {
          _customerPincode = value;
          OnPropertyChanged();
        }
      }
    }    
    [JsonProperty("dob")]
    public long? DateOfBirthLong {
      get { return _dateofBirthLong; }
      set {
        if (_dateofBirthLong != value) {
          _dateofBirthLong = value;
          if (_dateofBirthLong != null) {
            if(_dateofBirthLong >  0)
              DateOfBirth = _dateofBirthLong.Value.ToLocalDateTime();
          }
          OnPropertyChanged();
        }
      }
    }
    [JsonProperty("DateOfBirth")]
    public DateTime? DateOfBirth { get; set; }
    [JsonIgnore]
    public bool IsCredit {
      get { return _isCredit; }
      set {
        if (_isCredit != value) {
          _isCredit = value;
          OnPropertyChanged();
        }
      }
    }

    [JsonProperty("registration_date")]
    public long? CustomerRegistrationDate {

      get { return _customerRegistrationDate; }
     
      set {
        if (_customerRegistrationDate != value) {
          _customerRegistrationDate = value;
					CustomerRegistrationDateDate = ((long)_customerRegistrationDate).ToLocalDateTime().ToString("dd.MM.yyyy");

					OnPropertyChanged();
        }
      }
    }
		private string _customerRegistrationDateDate;
    [JsonIgnore]
    public string CustomerRegistrationDateDate {

			get { return _customerRegistrationDateDate; }

			set {
				if(_customerRegistrationDateDate != value) {
					_customerRegistrationDateDate = value;

					OnPropertyChanged();
				}
			}
		}

		[JsonIgnore]
    public DateTime CustomerLastModifiedDate {
      get { return _customerLastModifiedDate; }
      set {
        if (_customerLastModifiedDate != value) {
          _customerLastModifiedDate = value;
          OnPropertyChanged();
        }
      }
    }
    [JsonProperty("email")]
    public string CustomerEmail {
      get { return _customerEmail; }
      set {
        if (_customerEmail != value) {
          _customerEmail = value;
          OnPropertyChanged();
        }
      }
    }
    [JsonProperty("mobile_number")]
    public string CustomerMobileNumber {
      get { return _customerMobileNumber; }
      set {
        if (_customerMobileNumber != value) {
          _customerMobileNumber = value;
          OnPropertyChanged();
        }
      }
    }
    [JsonIgnore]
    public string CustomerCategory {
      get { return _customerCategory; }
      set {
        if (_customerCategory != value) {
          _customerCategory = value;
          OnPropertyChanged();
        }
      }
    }

    #region New Properties
    
    [JsonProperty("account_number")]
    public string AccountNumber {
      get { return _accountNumber; }
      set {
        if (_accountNumber != value) {
          _accountNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("bank_account_number")]
    public string BankAccountNumber {
      get { return _bankAccountNumber; }
      set {
        if (_bankAccountNumber != value) {
          _bankAccountNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("billing_category")]
    public string BillingCategory {
      get { return _billingCategory; }
      set {
        if (_billingCategory != value) {
          _billingCategory = value;
          OnPropertyChanged();          
        }
      }
    }
    
    [JsonProperty("card")]
    public object Card {
      get { return _card; }
      set {
        if (_card != value) {
          _card = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("category_number")]
    public long? CategoryNumber {
      get { return _categoryNumber; }
      set {
        if (_categoryNumber != value) {
          _categoryNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("consent_export_data")]
    public bool ConsentExportData {
      get { return _consentExportData; }
      set {
        if (_consentExportData != value) {
          _consentExportData = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("contact_details")]
    public DNContactDetail ContactDetails {
      get { return _contactDetails; }
      set {
        if (_contactDetails != value) {
          _contactDetails = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("credit_limit")]
    public double? CreditLimit {
      get { return _creditLimit; }
      set {
        if (_creditLimit != value) {
          _creditLimit = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("credit_limit_code")]
    public bool CreditLimitCode {
      get { return _creditLimitCode; }
      set {
        if (_creditLimitCode != value) {
          _creditLimitCode = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("credit_limit_days")]
    public int? CreditLimitDays {
      get { return _creditLimitDays; }
      set {
        if (_creditLimitDays != value) {
          _creditLimitDays = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("credit_type")]
    public DNCustomerCreditType CreditType {
      get { return _creditType; }
      set {
        if (_creditType != value) {
          _creditType = value;
          OnPropertyChanged();
        }
          _creditTypedisplay = GetCreditdisplayname(_creditType);
      }
    }

    [JsonProperty("credit_typedisplay")]
    public string CreditTypeDisplay {
      get { return _creditTypedisplay; }
      set {
        _creditTypedisplay = value;
      }
    }

    
    [JsonProperty("credit_used")]
    public float? CreditUsed {
      get { return _creditUsed; }
      set {
        if (_creditUsed != value) {
          _creditUsed = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("customer_image")]
    public object CustomerImage {
      get { return _customerImage; }
      set {
        if (_customerImage != value) {
          _customerImage = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("days_in_month")]
    public int DaysInMonth {
      get { return _daysInMonth; }
      set {
        if (_daysInMonth != value) {
          _daysInMonth = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("discount")]
    public int? Discount {
      get { return _discount; }
      set {
        if (_discount != value) {
          _discount = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("government")]
    public bool Government {
      get { return _government; }
      set {
        if (_government != value) {
          _government = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("group")]
    public int? Group {
      get { return _group; }
      set {
        if (_group != value) {
          _group = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("iban")]
    public string Iban {
      get { return _iban; }
      set {
        if (_iban != value) {
          _iban = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("identity")]
    public DNCustomerIdentity Identity {
      get { return _identity; }
      set {
        if (_identity != value) {
          _identity = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("item_accumulator")]
    public bool ItemAccumulator {
      get { return _itemAccumulator; }
      set {
        if (_itemAccumulator != value) {
          _itemAccumulator = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("LastChanged")]
    public long? LastChanged {
      get { return _lastChanged; }
      set {
        if (_lastChanged != value) {
          _lastChanged = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("lcg_number")]
    public string LcgNumber {
      get { return _lcgNumber; }
      set {
        if (_lcgNumber != value) {
          _lcgNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("location_id")]
    public string LocationId {
      get { return _locationId; }
      set {
        if (_locationId != value) {
          _locationId = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("login_id")]
    public string LoginId {
      get { return _loginId; }
      set {
        if (_loginId != value) {
          _loginId = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("loyalty_cards")]
    public object LoyaltyCards {
      get { return _loyaltyCards; }
      set {
        if (_loyaltyCards != value) {
          _loyaltyCards = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("matrix_discount")]
    public bool MatrixDiscount {
      get { return _matrixDiscount; }
      set {
        if (_matrixDiscount != value) {
          _matrixDiscount = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("member")]
    public bool Member {
      get { return _member; }
      set {
        if (_member != value) {
          _member = value;
          OnPropertyChanged();
        }
      }
    }

    [JsonProperty("note")]
    public string Note {
      get { return _note; }
      set {
        if (_note != value) {
          _note = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("organization_number")]
    public string OrganizationNumber {
      get { return _organizationNumber; }
      set {
        if (_organizationNumber != value) {
          _organizationNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("original_shop")]
    public string OriginalShop {
      get { return _originalShop; }
      set {
        if (_originalShop != value) {
          _originalShop = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("out_state")]
    public bool IsOutState {
      get { return _isOutState; }
      set {
        if (_isOutState != value) {
          _isOutState = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("override_surcharge")]
    public bool IsOverrideSurcharge {
      get { return _isOverrideSurchage; }
      set {
        if (_isOverrideSurchage != value) {
          _isOverrideSurchage = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("parent_number")]
    public string ParentNumber {
      get { return _parentNumber; }
      set {
        if (_parentNumber != value) {
          _parentNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("password")]
    public string Password {
      get { return _password; }
      set {
        if (_password != value) {
          _password = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("personal_number")]
    public object PersonalNumber {
      get { return _personalNumber; }
      set {
        if (_personalNumber != value) {
          _personalNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("private_customer")]
    public bool IsPrivateCustomer {
      get { return _isPrivateCustomer; }
      set {
        if (_isPrivateCustomer != value) {
          _isPrivateCustomer = value;
          OnPropertyChanged();
        }
        //CustomerType = value ? DNCustomerType.Private : DNCustomerType.organisation;
      }
    }
    
    [JsonProperty("projects")]
    public object Projects {
      get { return _projects; }
      set {
        if (_projects != value) {
          _projects = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("receives_direct_mail")]
    public bool ReceivesDirectMail {
      get { return _receivesDirectMail; }
      set {
        if (_receivesDirectMail != value) {
          _receivesDirectMail = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("sales_allowed")]
    public bool IsSalesAllowed {
      get { return _isSalesAllowed; }
      set {
        if (_isSalesAllowed != value) {
          _isSalesAllowed = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("security_number")]
    public string SecurityNumber {
      get { return _securityNumber; }
      set {
        if (_securityNumber != value) {
          _securityNumber = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("sex")]
    public string Sex {
      get { return _sex; }
      set {
        if (_sex != value) {
          _sex = value;
          OnPropertyChanged();
          SexType = value == "F" ? DNCustomerSexType.Female : DNCustomerSexType.Male;
        }
      }
    }
    public DNCustomerSexType SexType {
      get;set;
    }
    [JsonProperty("short_name")]
    public string ShortName {
      get { return _shortName; }
      set {
        if (_shortName != value) {
          _shortName = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("staff_member")]
    public bool StaffMember {
      get { return _staffMember; }
      set {
        if (_staffMember != value) {
          _staffMember = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("swift")]
    public string Swift {
      get { return _swift; }
      set {
        if (_swift != value) {
          _swift = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("unit")]
    public string Unit {
      get { return _unit; }
      set {
        if (_unit != value) {
          _unit = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("user_id")]
    public string UserId {
      get { return _userId; }
      set {
        if (_userId != value) {
          _userId = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("vat_free")]
    public bool VatFree {
      get { return _vatFree; }
      set {
        if (_vatFree != value) {
          _vatFree = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("vat_id")]
    public string VatId {
      get { return _vatId; }
      set {
        if (_vatId != value) {
          _vatId = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("BirthDate")]
    public DateTime BirthDate {
      get { return _birthDate; }
      set {
        if (_birthDate != value) {
          _birthDate = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("category")]
    public DNCustomerCategory Category {
      get { return _category; }
      set {
        if (_category != value) {
          _category = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("gift_vouchers")]
    public DNGiftVouchers GiftVouchers {
      get { return _giftVouchers; }
      set {
        if (_giftVouchers != value) {
          _giftVouchers = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("delivery_address")]
    public DNAddress DeliveryAddress {
      get { return _deliveryAddress; }
      set {
        if (_deliveryAddress != value) {
          _deliveryAddress = value;
          OnPropertyChanged();
        }
      }
    }
    
    [JsonProperty("correspondence_address")]
    public DNAddress CorrespondenceAddress {
      get { return _correspondenceAddress; }
      set {
        if (_correspondenceAddress != value) {
          _correspondenceAddress = value;
          OnPropertyChanged();
        }
      }
    }


    private int _totalRecords;
    [JsonProperty("total_records")]
    public int TotalRecords {
      get { return _totalRecords; }
      set {
        if (_totalRecords != value) {
          _totalRecords = value;
          OnPropertyChanged();
        }
      }
    }

    
    [JsonProperty("invoice_delivery_option")]
    public InvoiceDeliveryType InvoiceDeliverytype {
      get; set;
    }
    [JsonProperty("customer_type")]
    public DNCustomerType CustomerType {
      get;set;
    }
    private int _totalFilteredRecords;
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords {
      get { return _totalFilteredRecords; }
      set {        
        if (_totalFilteredRecords != value) {
          _totalFilteredRecords = value;
          OnPropertyChanged();
        }
      }
    }

    private bool _isorderreciveemail;
    [JsonProperty("is_orderreceiveemail")]
    public bool Isorderreciveemail {
      get { return _isorderreciveemail; }
      set {
        if(_isorderreciveemail != value) {
          _isorderreciveemail = value;
          OnPropertyChanged();
        }
      }
    }


    [JsonProperty("Bedrifts_number")]
    public long Bedriftsnumber { get; set; }

    [JsonProperty("Bedrifts_name")]
    public string Bedriftsname { get; set; }
    #endregion

    #region HelperFunction
    private string GetCreditdisplayname(DNCustomerCreditType creditType) {
      switch (creditType) {
        case DNCustomerCreditType.Normal:
          return "P (Ikke kreditt)";
        case DNCustomerCreditType.Credit:
          return "C (Kreditt)";
        case DNCustomerCreditType.Internal:
          return "I (Intern)";
        case DNCustomerCreditType.Utmeldt:
          return "U (Utmeldt)";
        default:
          return "P (Ikke kreditt)";
      }
    }
    #endregion
  }

  public class DNInvoiceDeliveryTypes : BaseModel {
    /// <summary>
    /// Delivery Type Id
    /// </summary>
    [JsonProperty("delivery_type_id")]
    public string DeliveryTypeId { get; set; }

    /// <summary>
    /// Delivery Type Name
    /// </summary>
    [JsonProperty("delivery_type_name")]
    public string DeliveryTypeName { get; set; }

    /// <summary>
    /// Delivery Type Visible for invoice delivery
    /// </summary>
    [JsonProperty("is_visible_for_invoice")]
    public bool IsVisible { get; set; }

    /// <summary>
    /// Customer Type for invoice delivery
    /// </summary>
    [JsonProperty("customer_type")]
    public string CustomerType { get; set; }

    public DNInvoiceDeliveryType Type { get; set; }

  }
}
