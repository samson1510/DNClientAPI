using Newtonsoft.Json;
using System.Collections.Generic;
using DataNova.Common;

namespace DNClientAPI.Models {
  public class DNOperator:BaseModel {

    public DNOperator() {
      Shops = new List<DNShopSmallDTO>();
      CorrespondenceAddress = new DNAddress();
      DeliveryAddress = new DNAddress();
      ContactDetails = new DNContactDetails();
      Forms = new List<DNForm>();
    }
    /// <summary>
    /// User number
    /// </summary>
    [JsonProperty("user_number")]
    public long Number { get; set; }
    [JsonProperty("allowed_shops")]
    public int[] AllowedShops { get; set; }


    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Contact Details
    /// </summary>
    [JsonProperty("contact_details")]
    public DNContactDetail ContactDetails { get; set; }

    /// <summary>
    /// Shops user belongs to
    /// </summary>
    [JsonProperty("shops")]
    public List<DNShopSmallDTO> Shops { get; set; }

    /// <summary>
    /// Language
    /// </summary>
    [JsonProperty("language")]
    public DNLanguageType Language { get; set; }

    /// <summary>
    /// Security level
    /// </summary>
    [JsonProperty("security_level")]
    public int SecurityLevel { get; set; }

    /// <summary>
    /// Employee number
    /// </summary>
    [JsonProperty("employee_number")]
    public string EmployeeNo { get; set; }

    /// <summary>
    /// Correspondance address
    /// </summary>
    [JsonProperty("correspondence_address")]
    public DNAddress CorrespondenceAddress { get; set; }

    /// <summary>
    /// Delivery address
    /// </summary>
    [JsonProperty("delivery_address")]
    public DNAddress DeliveryAddress { get; set; }

    /// <summary>
    /// Supplier number if user is a supplier
    /// </summary>
    [JsonProperty("supplier_no")]
    public string SupplierNo { get; set; }

    /// <summary>
    /// User profile
    /// </summary>
    [JsonProperty("profile")] 
    public bool IsBoss { get; set; }

    /// <summary>
    /// Forms
    /// </summary>
    [JsonProperty("forms")]
    public List<DNForm> Forms { get; set; }
    /// <summary>
    /// last Login date and time
    /// </summary>
    [JsonProperty("last_login_time")]
    public long? LastLoginTime {
      get; set;
    }
    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("theme")]
    public string ApplicationTheme {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("password")]
    public string Password {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("suspended")]
    public bool Suspended {
      get; set;
    }
    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("stopforcreditsales")]
    public bool StopCreditforsales {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("role")]
    public int Role {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("consenttoexport")]
    public bool ConsentToExport {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("bhandlernumber")]
    public int BehandlerNumber {
      get; set;
    }


    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("maxdiscountamount")]
    public decimal MaxDiscountAmount {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("note")]
    public string Note {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("shoplist")]
    public string Shoplist {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("rolename")]
    public string RoleName {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    [JsonProperty("creationdate")]
    public string Creationdate {
      get; set;
    }

    /// <summary>
    /// Application theme 
    /// </summary>
    //[JsonProperty("userprofile")]

    //public string UserPrfoiletype {
    //  get; set;
    //}

    [JsonProperty("userprofile")]
    public UserProfileType ? Prfoiletype { get; set; }

    [JsonProperty("userprofiletype")]
    
    public string UserPrfoiletype {
      get; set;
    }

    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }

    /// </summary>
    [JsonProperty("userlanguage")]
    public string UserLanguage { get; set; }


  }
  public class OperatorAccessRight:BaseModel {

    [JsonProperty("allow_edit")]
    public bool AllowEdit {
      get; set;
    }

    [JsonProperty("form_module_name")]
    public string FormModuleName {
      get; set;
    }

    [JsonProperty("form_number")]
    public int FormNumber {
      get; set;
    }

    [JsonProperty("module_no")]
    public int ModuleNo {
      get; set;
    }

    [JsonProperty("read_access")]
    public bool ReadAccess {
      get; set;
    }

    [JsonProperty("report_id")]
    public object ReportId {
      get; set;
    }

    [JsonProperty("security_level")]
    public object SecurityLevel {
      get; set;
    }

    [JsonProperty("stop_for_creadit_sale")]
    public object StopForCreaditSale {
      get; set;
    }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords {
      get; set;
    }

    [JsonProperty("total_records")]
    public int TotalRecords {
      get; set;
    }

    [JsonProperty("write_access")]
    public bool WriteAccess {
      get; set;
    }
  }
}

