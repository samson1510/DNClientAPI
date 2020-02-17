﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataNova.Common {
  public class MicrosecondEpochConverter : DateTimeConverterBase {
    private static readonly DateTime _epoch = new DateTime(1970,1,1,0,0,0,0,DateTimeKind.Utc);

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      DateTime dateInUtc = (DateTime)value;
      TimeSpan difference = (dateInUtc.Subtract(_epoch));
      var unixTimestamp = (long)Math.Truncate(difference.TotalSeconds);
      writer.WriteRawValue(unixTimestamp.ToSafeString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      if(reader.Value == null) { return null; }
      return (_epoch.AddMilliseconds((long)reader.Value)).ToLocalTime();
    }
  }
}
