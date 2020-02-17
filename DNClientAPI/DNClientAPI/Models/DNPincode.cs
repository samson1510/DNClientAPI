using Newtonsoft.Json;
namespace DNClientAPI.Models {


  public class DNPincode : BaseModel {

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("prev_country_value")]
    public string PrevCountryVal { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }

    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
  }
}
