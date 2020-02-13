using DataNova.Common;
using Newtonsoft.Json;
using System;

namespace DNClientAPI.Models {
  public class DNTicketInfo {

    #region properties
    private long _validtilldatelong;
    private DateTime _validdate;
    /// <summary>
    /// Number of days
    /// </summary>
    [JsonProperty("number_of_days")]
    public short? Numberofdays { get; set; }
    /// <summary>
    /// Number of uses
    /// </summary>
    [JsonProperty("number_of_uses")]
    public int? NumberofUses { get; set; }

    [JsonProperty("expiry_date")]
    public long? ValidTillLongNullable {
      get { return _validtilldatelong; }
      set {
        if(_validtilldatelong != value && value != null) {
          _validtilldatelong = value.Value;
          if(value != null) {
            ValidTillLong = value.Value;
          }
          ValidTill = _validtilldatelong.ToLocalDateTime();
        }
      }
    }
    public DateTime? ValidTill { get; set; }
    public long ValidTillLong {
      get; set;
    }

    /// <summary>
    /// Number of uses per day
    /// </summary>
    [JsonProperty("number_of_uses_per_day")]
    public short? NumberofUsesPerDay { get; set; }
    /// <summary>
    /// Is Customer Required
    /// </summary>
    [JsonProperty("is_customer_required")]
    public bool IsCustomerRequired { get; set; }

    #endregion
  }
}
