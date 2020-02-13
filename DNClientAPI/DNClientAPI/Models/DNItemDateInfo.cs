using DataNova.Common;
using Newtonsoft.Json;
using System;

namespace DNClientAPI.Models {
  public class DNItemDateInfo {
    private long _enddatelong;
    private long _stardatelong;
    [JsonProperty("start_date")]
    public long StartDateLong {
      get { return _stardatelong; }
      set {
        if(_stardatelong != value) {
          _stardatelong = value;
          StartDateDateTime = _stardatelong.ToUtcDate();
          StartDateString = _stardatelong.ToUtcDate().ToSafeString();
        }
      }
    }
    
    [JsonProperty("end_date")]
    public long EndDateLong {
      get { return _enddatelong; }
      set {
        if(_enddatelong != value) {
          _enddatelong = value;
          EndDateDateTime = _enddatelong.ToUtcDate();
          EndDateString = _enddatelong.ToUtcDate().ToSafeString();
        }
      }
    }
    [JsonProperty("start_date_string")]
    public string StartDateString { get; set; }

    [JsonProperty("end_date_string")]
    public string EndDateString { get; set; }

    public DateTime StartDateDateTime { get; set; }
    public DateTime EndDateDateTime { get; set; }

    /// <summary>
    /// Monday
    /// </summary>
    [JsonProperty("ismonday")]
    public bool isMonday { get; set; }

    /// <summary>
    /// Tuesday
    /// </summary>
    [JsonProperty("istuesday")]
    public bool isTuesday { get; set; }

    /// <summary>
    /// Tuesday
    /// </summary>
    [JsonProperty("iswednesday")]
    public bool isWednesday { get; set; }

    /// <summary>
    /// Thrusaday
    /// </summary>
    [JsonProperty("isthursday")]
    public bool isThrusday { get; set; }

    /// <summary>
    /// Friday
    /// </summary>
    [JsonProperty("isfriday")]
    public bool isFriday { get; set; }

    /// <summary>
    /// Saturday
    /// </summary>
    [JsonProperty("issaturday")]
    public bool isSaturday { get; set; }

    /// <summary>
    /// Sunday
    /// </summary>
    [JsonProperty("issunday")]
    public bool isSunday { get; set; }
  }
}
