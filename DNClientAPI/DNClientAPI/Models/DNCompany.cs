using Newtonsoft.Json;
namespace DNClientAPI.Models {

  public class DNCompany : BaseModel {

    [JsonProperty("blob")]
    public string Blob { get; set; }

    [JsonProperty("bonus_card_number")]
    public string BonusCardNumber { get; set; }

    [JsonProperty("cor_address")]
    public DNAddress Address { get; set; }

    [JsonProperty("cst_registration_number")]
    public string CstRegistrationNumber { get; set; }

    [JsonProperty("contact_details")]
    public DNContactDetails ContactDetails { get; set; }
    public string OrganizationNumber { get; set; }

    [JsonProperty("del_address")]
    public DelAddress DelAddress { get; set; }

    [JsonProperty("euro_card_number")]
    public string EuroCardNumber { get; set; }

    [JsonProperty("gross_profit")]
    public double? GrossProfit { get; set; }

    [JsonProperty("location_number")]
    public string LocationNumber { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("number")]
    public int Number { get; set; }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }

    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
  }

  public class DelAddress {
  
    [JsonProperty("address1")]
    public string Address1 {get;set; }

    [JsonProperty("address2")]
    public string Address2 { get; set; }

    [JsonProperty("address3")]
    public string Address3 { get; set; }

    [JsonProperty("pincode")]
    public DNPincode Pincode { get; set; }

  }

}

