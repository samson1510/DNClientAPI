using Newtonsoft.Json;
namespace DNClientAPI.Models {
  public class DNSortimentCode : BaseModel {
    private string _code;
    private string _name;
    [JsonProperty("variety_code")]
    public string Code {
      get { return _code; }
      set {
        if (_code != value) {
          _code = value;
          Title = _code + "-" + _name;
        }
      }
    }
    [JsonProperty("name")]
    public string Name {
      get { return _name; }
      set {
        if (_name != value) {
          _name = value;
          Title = _code + "-" + _name;
        }
      }
    }
    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }
  }
}
