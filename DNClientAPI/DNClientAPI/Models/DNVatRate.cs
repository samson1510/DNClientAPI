using Newtonsoft.Json;
using System.ComponentModel;

namespace DNClientAPI.Models {

  /// <summary>
  /// VAT Rate
  /// </summary>
  public class DNVatRate : BaseModel {

    #region Properties

    /// <summary>
    /// ID
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("lastupdateeduserno")]
    public string lastupdateeduserno { get; set; }


    /// <summary>
    /// Rate
    /// </summary>
    [JsonProperty("rate")]
    public decimal Rate { get; set; }
    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }

    #endregion Properties
  }
}