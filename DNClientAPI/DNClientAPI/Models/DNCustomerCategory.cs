using Newtonsoft.Json;
using DataNova.Common;

namespace DNClientAPI.Models {
  public class DNCustomerCategory :BaseModel {


    #region Properties    
 
    [JsonProperty("category_number")]
    public long Number {
      get; set;
    }
    public bool Select { get; set; }

    [JsonProperty("name")]
    public string Name {
      get; set;
    }

    [JsonProperty("discount_percent")]
    public decimal? DiscountPercent {
      get; set;
    }
    public DNCustomerType CustomerType {
      get; set;
    }

    [JsonProperty("total_records")]
    public int TotalRecords {
      get; set;
    }

    [JsonProperty("last_modified_date")]
    public string LastModifiedDate { get; set; }

    [JsonProperty("last_modified_user")]
    public int? LastModifiedUser { get; set; }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords {
      get; set;
    }
    #endregion Properties
  }

  public class DNCustomer_Category : BaseModel {

    #region Properties    

    [JsonProperty("category_number")]
    public long Number {
      get; set;
    }
    [JsonProperty("name")]
    public string Name {
      get; set;
    }
    [JsonProperty("discount_percent")]
    public decimal? DiscountPercent {
      get; set;
    }
  
    [JsonProperty("total_records")]
    public int TotalRecords {
      get; set;
    }
    [JsonProperty("last_modified_date")]
    public string LastModifiedDate { get; set; }

    [JsonProperty("last_modified_user")]
    public int? LastModifiedUser { get; set; }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords {
      get; set;
    }
    #endregion Properties
  }

}
