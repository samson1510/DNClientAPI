using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
      //// Get epoch in UTC
      //var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      //// Calculate the Unix Timestamp
      //var difference = (dateInUtc.Subtract(epoch));
      //var differenceSeconds = difference.TotalSeconds;
      //var unixTimestamp = (long)Math.Truncate(differenceSeconds);
      //return unixTimestamp;
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
    public static string FilterToJSON(this APIFilter filter,string orderby = "asc") {
      APIFilter_formatted formatted = new APIFilter_formatted();
      int count = 0;
      foreach(var col in filter.columns) {
        if(col.search.value != "") {
          count++;
        }
      }
      formatted.Columns = new APIColumnQuery_formatted[count];
      int iter = 0;
      for(int i = 0;i < filter.columns.Length;i++) {
        if(filter.columns[i].search.value != "") {
          formatted.Columns[iter] = ExtractOperation(filter.columns[i]);
          formatted.Columns[iter].Name = filter.columns[i].name;
          iter++;
        }
      }
      formatted.Order = new APIOrderQuery_formatted[filter.order.Length];
      for(int i = 0;i < filter.order.Length;i++) {
        formatted.Order[i] = new APIOrderQuery_formatted();
        formatted.Order[i].Name = filter.columns[filter.order[i].column.ToInt()].name;
        formatted.Order[i].IsAscending = filter.order[i].dir == orderby;
      }
      formatted.ColumnInfo = filter.ColumnInfo;
      formatted.Index = filter.start;
      formatted.Size = filter.length;
      return formatted.SerializeJSON();
    }

    public static string SerializeJSON(this object json) {
      return JsonConvert.SerializeObject(json,Newtonsoft.Json.Formatting.Indented);
    }
    private static APIColumnQuery_formatted ExtractOperation(APIColumnQuery column) {
      var col = new APIColumnQuery_formatted();
      col.Operator = WebDataGridOperator.CONTAINS.ToString();
      string value = column.search.value;
      if(!string.IsNullOrEmpty(value)) {
        string prefix = value[0].ToString();
        if(value.StartsWith("=") || value.StartsWith("<") || value.StartsWith(">") || value.StartsWith("*")) {
          int prefixLength = 1;
          switch(prefix) {
            case "=":
              col.Operator = WebDataGridOperator.EQUAL.ToString();
              break;
            case "<":
              if(value.Length > 1 && value[1].ToString() == "=") {
                col.Operator = WebDataGridOperator.LESSTHANOREQUAL.ToString();
                prefixLength = 2;
              } else if(value.Length > 1 && value[1].ToString() == ">") {
                col.Operator = WebDataGridOperator.NOTEQUAL.ToString();
                prefixLength = 2;
              } else {
                col.Operator = WebDataGridOperator.LESSTHAN.ToString();
              }
              break;
            case ">":
              if(value.Length > 1 && value[1].ToString() == "=") {
                col.Operator = WebDataGridOperator.GREATERTHANOREQUAL.ToString();
                prefixLength = 2;
              } else {
                col.Operator = WebDataGridOperator.GREATERTHAN.ToString();
              }
              break;
            case "*":
              col.Operator = WebDataGridOperator.ENDSWITH.ToString();
              break;
          }
          col.Value = value.Substring(prefixLength);
        } else if(value[value.Length - 1] == '*') {
          col.Operator = WebDataGridOperator.STARTSWITH.ToString();
          col.Value = value.Substring(0,value.Length - 1);
        } else if(value.Contains("-")) {
          string[] split = value.Split('-');
          bool isValid = false;
          if(split.Length > 1) {
            string dateBegin = split[0];
            string dateEnd = split[1];
            DateTime dt1 = DateTime.MinValue;
            DateTime dt2 = DateTime.MinValue;
            if(DateTime.TryParse(dateBegin,out dt1) && DateTime.TryParse(dateEnd,out dt2)) {
              col.Value = dateBegin;
              col.Value2 = dateEnd;
              col.Operator = WebDataGridOperator.BETWEEN.ToString();
              isValid = true;
            }
          }
          if(!isValid) {
            col.Value = value;
          }
        } else {
          col.Value = value;
        }
      }
      return col;
    }
    public static T ToData<T>(this JArray array,string tablename) {
      object value = null;
      bool gridfound = false;
      if(array != null) {
        foreach(var bannerObj in array) {
          if(gridfound) break;
          foreach(JProperty property in bannerObj.Value<JToken>()) {
            if(property.Name == "tname" && property.Value.ToString() == tablename) {
              gridfound = true;
            } else if(gridfound && property.Name == "tdata") {
              value = property.Value.ToObject<T>();
              break;
            }
          }
        }
      }
      return (T)value;
    }

    public static string SubStringBeforeChar(this string input,char c) {
      var index = input.IndexOf(c);
      if(index > 0) {
        return input.Substring(0,index);
      }
      return input;
    }
    public static DateTime StartOfWeek(this DateTime dt,DayOfWeek startOfWeek) {
      int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
      return dt.AddDays(-1 * diff).Date;
    }
    public static int WeekOfYearISO8601(this DateTime date) {
      var cultureInfo = new CultureInfo("nb-NO");
      var day = (int)cultureInfo.Calendar.GetDayOfWeek(date);
      return cultureInfo.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)),CalendarWeekRule.FirstFourDayWeek,DayOfWeek.Monday);
    }
    public static DateTime FirstDateOfWeek(int year,int weekOfYear) {
      var ci = new CultureInfo("nb-NO");
      DateTime jan1 = new DateTime(year,1,1);
      int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
      DateTime firstWeekDay = jan1.AddDays(daysOffset);
      int firstWeek = ci.Calendar.GetWeekOfYear(jan1,ci.DateTimeFormat.CalendarWeekRule,ci.DateTimeFormat.FirstDayOfWeek);
      if((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3) {
        weekOfYear -= 1;
      }
      return firstWeekDay.AddDays(weekOfYear * 7);
    }
  }
}
