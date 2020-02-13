using System;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace DataNova.Common {
  public static class DNExtensions {
    private static string[] formats = new[] { "M-d-yyyy","dd-MM-yyyy","MM-dd-yyyy","M.d.yyyy","dd.MM.yyyy","MM.dd.yyyy" }.Union(CultureInfo.InvariantCulture.DateTimeFormat.GetAllDateTimePatterns()).ToArray();
    public static double ToDouble(this string value) {
      double _value = 0;
      double.TryParse(value,out _value);
      return _value;
    }
    public static int ToInt(this string value) {
      int _value = 0;
      if(value == "True") {
        _value = 1;
      } else if(value == "False") {
        _value = 0;
      } else {
        int.TryParse(value,out _value);
      }
      return _value;
    }
    public static bool ToBool(this string value) {
      return ((!string.IsNullOrEmpty(value) && (value == "1" || value.ToLower() == "true")));
    }
    public static decimal ToDecimal(this string value) {
      decimal _value = 0;
      decimal.TryParse(value,out _value);
      return _value;
    }
    public static Int64 ToInt64(this string value) {
      Int64 _value = 0;
      Int64.TryParse(value,out _value);
      return _value;
    }
    public static long ToLong(this string value) {
      return ToInt64(value);
    }
    public static DateTime ToDateTime(this string value) {
      DateTime _date = DateTime.MinValue;
      DateTime.TryParse(value,out _date);
      return _date;
    }
    public static DateTime ToDateTimeExact(this string value) {
      DateTime _date = DateTime.MinValue;
      try {
        _date = DateTime.ParseExact(value,formats,CultureInfo.InvariantCulture,DateTimeStyles.AssumeLocal);
      } catch { }
      return _date;
    }
    public static float ToFloat(this string value) {
      float _value = 0;
      float.TryParse(value,out _value);
      return _value;
    }
    public static double ToDouble(this object value) {
      return ToDouble(Convert.ToString(value));
    }
    public static int ToInt(this object value) {
      return ToInt(Convert.ToString(value));
    }
    public static bool ToBool(this object value) {
      return ToBool(Convert.ToString(value));
    }
    public static decimal ToDecimal(this object value) {
      return ToDecimal(Convert.ToString(value));
    }
    public static Int64 ToInt64(this object value) {
      return ToInt64(Convert.ToString(value));
    }
    public static long ToLong(this object value) {
      return ToLong(Convert.ToString(value));
    }
    public static DateTime ToDateTime(this object value) {
      return ToDateTime(Convert.ToString(value));
    }
    public static float ToFloat(this object value) {
      return ToFloat(Convert.ToString(value));
    }

    public static string ToSafeString(this object value) {
      return Convert.ToString(value);
    }
    public static string GetAttributeValue(this XmlNode element,string name) {
      string value = string.Empty;
      try {
        var attribute = element.Attributes[name];
        if(attribute != null) {
          value = attribute.Value;
        }
      } catch(Exception) { }
      return value;
    }

    public static DateTime ToLocalDateTime(this long unixTimestamp) {
      // Get the epoch in UTC
      var epoch = new DateTime(1970,1,1,0,0,0,0,DateTimeKind.Utc);
      // Calculate the Date and Time
      var utcDateTime = epoch.AddMilliseconds(unixTimestamp);
      var dateLocal = utcDateTime.ToLocalTime();
      return dateLocal;
    }
    public static DateTime ToUtcDate(this long unixTimestamp) {
      // Get the epoch in UTC
      var epoch = new DateTime(1970,1,1,0,0,0,0,DateTimeKind.Utc);
      // Calculate the Date and Time
      var utcDateTime = epoch.AddMilliseconds(unixTimestamp);
      return utcDateTime;
    }
    public static long ToUnixDateTime(this DateTime dateInUtc) {
      return dateInUtc.ToUniversalTime().ToUnixMillis();
    }
    public static long ToUnixDateTime(this DateTime? dateInUtc) {
      if(dateInUtc.HasValue)
        return dateInUtc.Value.ToUnixDateTime();
      else
        return dateInUtc.ToUnixDateTime();
    }
    public static long ToUnixMillis(this DateTime dateInUtc) {
      var epoch = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
      return (long)(dateInUtc - epoch).TotalMilliseconds;
    }
    public static long ToUnixMillis(this DateTime? dateInUtc) {
      if(dateInUtc.HasValue)
        return dateInUtc.Value.ToUnixMillis();
      else
        return dateInUtc.ToUnixMillis();
    }
    public static bool HasSpecialChar(this string input) {
      string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>,";
      foreach(var item in specialChar) {
        if(input.Contains(item)) return true;
      }
      return false;
    }
  }
}
