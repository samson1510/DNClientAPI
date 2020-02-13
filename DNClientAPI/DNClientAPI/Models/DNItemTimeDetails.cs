using DataNova.Common;
using Newtonsoft.Json;
using System;

namespace DNClientAPI.Models {
  public class DNItemTimeDetails {
    private long _endtimelong;
    private long _startimelong;
    private int _weekday=-1;
    enum WeekDays {
      Monday = 0,
      Tuesday = 1,
      Wednesday = 2,
      Thursday = 3,
      Friday = 4,
      Saturday = 5,
      Sunday = 6
    }
    /// <summary>
    /// Item Week Days
    /// </summary>
    [JsonProperty("item_week_days")]
    public int CoWeekDay {
      get {return _weekday; }
      set {
        if(_weekday != value) {
          _weekday = value;
          WeekDayString = ((WeekDays)_weekday).ToSafeString();
        }
      }
    }

    public string WeekDayString { get; set; }

    /// <summary>
    /// Item Start Time
    /// </summary>
    [JsonProperty("item_start_time")]
    public long StartTimeLong {
      get { return _startimelong; }
      set {
        if(_startimelong != value) {
          _startimelong = value;
          StartTimeString = _startimelong.ToUtcDate().TimeOfDay.ToSafeString();
          StartDateDateTime = _startimelong.ToUtcDate();
        }
      }
    }
    public string StartTimeString { get; set; }

    /// <summary>
    /// Item End Time
    /// </summary>
    [JsonProperty("item_end_time")]
    public long EndTimeLong {
      get { return _endtimelong; }
      set {
        if(_endtimelong != value) {
          _endtimelong = value;
          EndTimeString = _endtimelong.ToUtcDate().TimeOfDay.ToSafeString();
          EndDateDateTime = _endtimelong.ToUtcDate();
        }
      }
    }
    public string EndTimeString { get; set; }

    public DateTime StartDateDateTime { get; set; }
    public DateTime EndDateDateTime { get; set; }


  }
}
