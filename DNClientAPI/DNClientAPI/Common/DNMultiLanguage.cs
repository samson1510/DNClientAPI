using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;
using DNClientAPI.Globalization;
using System.ComponentModel;

namespace DataNova.Common {
  public static class DNMultiLanguage {
    public static List<string> _languages = new List<string>();
    public enum DNLanguageFileType { None, Lime, Compass, Flise, Bunnpris, Biltema, Iss };
    public static Dictionary<string, Dictionary<DNLanguageType, string>> Messages = new Dictionary<string, Dictionary<DNLanguageType, string>>();
    public static Dictionary<long, Dictionary<DNLanguageType, string>> FKMessages = new Dictionary<long, Dictionary<DNLanguageType, string>>();
    public static Dictionary<string, Dictionary<DNLanguageType, string>> Titles = new Dictionary<string, Dictionary<DNLanguageType, string>>();
    public static Dictionary<string, Dictionary<DNLanguageType, string>> Descriptions = new Dictionary<string, Dictionary<DNLanguageType, string>>();
    public static Dictionary<string, Dictionary<DNLanguageType, string>> ItemTypeMessage = new Dictionary<string, Dictionary<DNLanguageType, string>>();
    public static Dictionary<string, string> PropertyAlias = new Dictionary<string, string>();
    public static Dictionary<string, Dictionary<DNLanguageType, string>> PropertyDescriptions = new Dictionary<string, Dictionary<DNLanguageType, string>>();
    public static Dictionary<string, string> DatabaseColumns = new Dictionary<string, string>();
    private static bool _isRead = false;
    private static DNLanguageType _type {
      get { return LanguageTypeHandler.Current.Type; }
      set { LanguageTypeHandler.Current.Type = value; }
    }
    private static DNLanguageFileType _languagefiletype = DNLanguageFileType.None;
    public static Dictionary<string, string> HardcodedMessages = new Dictionary<string, string>();
    static DNMultiLanguage() {
      switch(CultureInfo.InstalledUICulture.ThreeLetterISOLanguageName) {
        case "nob":
          _type = DNLanguageType.Norwegian_Bokmal;
          break;
        case "eng":
          _type = DNLanguageType.English;
          break;
        case "swe":
          _type = DNLanguageType.Swedish;
          break;
        case "ger":
          _type = DNLanguageType.German;
          break;
        case "dan":
          _type = DNLanguageType.Danish;
          break;
        case "fin":
          _type = DNLanguageType.Finnish;
          break;
        default:
          _type = DNLanguageType.Norwegian_Bokmal;
          break;
      }
      //Init(ResourceLoader.GetEmbeddedResourceString(typeof(DNMultiLanguage).Assembly, "language.xml"));
    }
    private static void Init(string file) {
      try {
        XDocument languagedocument = XDocument.Parse(file);
        var elements = languagedocument.Elements();
        string languageid = string.Empty;
        foreach(XElement el in elements)
          foreach(XElement el2 in el.Elements()) {
            foreach(XElement element in el2.Elements()) {
              var _defaultentry = new Dictionary<DNLanguageType, string>();
              var _xElement = element.Element("id");
              if(_xElement == null) continue;
              languageid = _xElement.Value.ToLower();
              var _norElement = element.Element("Nor") ?? element.Element("nor");
              var _engElement = element.Element("Eng") ?? element.Element("eng");
              var _sweElement = element.Element("Swe") ?? element.Element("swe");
              var _gerElement = element.Element("Ger") ?? element.Element("ger");
              var _danElement = element.Element("Dan") ?? element.Element("dan");
              var _finElement = element.Element("Fin") ?? element.Element("fin");
              _defaultentry.Add(DNLanguageType.Norwegian_Bokmal, (_norElement != null ? ProcessMessageValue(_norElement.Value) : ""));
              _defaultentry.Add(DNLanguageType.English, (_engElement != null ? ProcessMessageValue(_engElement.Value) : ""));
              _defaultentry.Add(DNLanguageType.Swedish, (_sweElement != null ? ProcessMessageValue(_sweElement.Value) : ""));
              _defaultentry.Add(DNLanguageType.German, (_gerElement != null ? ProcessMessageValue(_gerElement.Value) : ""));
              _defaultentry.Add(DNLanguageType.Danish, (_danElement != null ? ProcessMessageValue(_danElement.Value) : ""));
              _defaultentry.Add(DNLanguageType.Finnish, (_finElement != null ? ProcessMessageValue(_finElement.Value) : ""));
              if(!Messages.ContainsKey(languageid)) {
                Messages.Add(languageid, _defaultentry);
              }
            }
          }
      } catch(Exception) {
      }
    }
    /// <summary>
    /// Used to set  default language at login 
    /// </summary>
    public static DNLanguageType Language {
      set {
        _type = value;
      }
      get {
        return _type;
      }
    }
    public static CultureInfo CurrentCultureInfo {
      get {
        CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
        cultureInfo.NumberFormat.CurrencyGroupSeparator = "";
        cultureInfo.NumberFormat.NumberGroupSeparator = "";
        cultureInfo.NumberFormat.PercentGroupSeparator = "";
        cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
        cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
        cultureInfo.NumberFormat.PercentDecimalSeparator = ".";
        // Creating the DateTime Information specific to our application.
        DateTimeFormatInfo dateTimeInfo = new DateTimeFormatInfo();
        // Defining various date and time formats.
        dateTimeInfo.DateSeparator = ".";
        dateTimeInfo.LongDatePattern = "d. MMMM yyyy";
        dateTimeInfo.ShortDatePattern = "dd.MM.yyyy";
        dateTimeInfo.LongTimePattern = "HH:mm:ss";
        dateTimeInfo.ShortTimePattern = "HH:mm";
        dateTimeInfo.TimeSeparator = ":";
        // Setting application wide date time format.
        cultureInfo.DateTimeFormat = dateTimeInfo;
        return cultureInfo;
      }
    }
    public static CultureInfo CurrentUICultureInfo {
      get {
        CultureInfo cultureInfo = null;
        switch(_type) {
          case DNLanguageType.Norwegian_Bokmal:
            cultureInfo = new CultureInfo("nb-NO");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ",";
            cultureInfo.NumberFormat.PercentDecimalSeparator = ",";
            break;
          case DNLanguageType.English:
            cultureInfo = new CultureInfo("en-US");
            break;
          case DNLanguageType.Swedish:
            cultureInfo = new CultureInfo("sv-SE");
            break;
          case DNLanguageType.Danish:
            cultureInfo = new CultureInfo("da-DK");
            break;
          case DNLanguageType.Finnish:
            cultureInfo = new CultureInfo("fi-FI");
            break;
          case DNLanguageType.German:
            cultureInfo = new CultureInfo("de-DE");
            break;
          default:
            cultureInfo = new CultureInfo("en-US");
            break;
        }
        cultureInfo.NumberFormat.CurrencyGroupSeparator = "";
        cultureInfo.NumberFormat.NumberGroupSeparator = "";
        cultureInfo.NumberFormat.PercentGroupSeparator = "";
        // Creating the DateTime Information specific to our application.
        DateTimeFormatInfo dateTimeInfo = new DateTimeFormatInfo();
        // Defining various date and time formats.
        dateTimeInfo.DateSeparator = ".";
        dateTimeInfo.LongDatePattern = "d. MMMM yyyy";
        dateTimeInfo.ShortDatePattern = "dd.MM.yyyy";
        dateTimeInfo.LongTimePattern = "HH:mm:ss";
        dateTimeInfo.ShortTimePattern = "HH:mm";
        dateTimeInfo.TimeSeparator = ":";
        // Setting application wide date time format.
        cultureInfo.DateTimeFormat = dateTimeInfo;
        return cultureInfo;
      }
    }
    internal static void SetUILanguageCulture(CultureInfo appcultureinfo, CultureInfo appUIcultureinfo) {
      try {
        // Assigning our custom Culture to the application.                        
        Thread.CurrentThread.CurrentCulture = appcultureinfo;
        Thread.CurrentThread.CurrentUICulture = appUIcultureinfo;
      } catch(Exception ex) {
        string message = ex.Message;
      }
    }

    /// <summary>
    /// Finds the correct message, and returns it
    /// </summary>
    /// <param name="id">The id of the message to return</param>
    /// <param name="language">The language of the message to return</param>
    /// <returns>The message corresponding to the id and language given as parameters</returns>
    public static string GetMessage(string id, DNLanguageType language) {
      string _id = id.ToLower();
      if(Messages.ContainsKey(_id) && Messages[_id].ContainsKey(language)) {
        var message = Messages[_id][language];
        return !string.IsNullOrEmpty(message) ? message : Messages[_id][DNGlobalProperties.Current.DefaultLanguage];
      }
      return id;
    }
    public static string GetMessage(string id) {
      if(HardcodedMessages.ContainsKey(id)) {
        return HardcodedMessages[id].ToString();
      }
      return GetMessage(id, _type);
    }

    public static DNLanguageType GetLanguageType(string languagetype) {
      if(string.IsNullOrEmpty(languagetype)) languagetype = "Norwegian_Bokmal";
      switch(languagetype.ToLower()) {
        case "Norwegian_Bokmal":
          return DNLanguageType.Norwegian_Bokmal;
        case "norwegian bokmal":
          return DNLanguageType.Norwegian_Bokmal;
        case "english":
          return DNLanguageType.English;
        case "swedish":
          return DNLanguageType.Swedish;
        case "danish":
          return DNLanguageType.Danish;
        case "finland":
          return DNLanguageType.Finnish;
        case "german":
          return DNLanguageType.German;
        case "nb-no":
          return DNLanguageType.Norwegian_Bokmal;
        case "en-us":
          return DNLanguageType.English;
        default:
          return DNLanguageType.Norwegian_Bokmal;
      }
    }
    /// <summary>
    /// Adjusts message contents for special characters etc.
    /// </summary>
    /// <param name="value">value to process</param>
    /// <returns>the adjusted value</returns>
    private static string ProcessMessageValue(string value) {
      return value.Replace("\\n", "\n"); ;
    }

  }
  public class LanguageTypeHandler : INotifyPropertyChanged {
    private DNLanguageType _type;

    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Raises the PropertyChanged event.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "") {
      var handler = this.PropertyChanged;
      if(handler != null) {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public DNLanguageType Type {
      get { return _type; }
      set {
        if(_type != value) {
          _type = value;
          OnPropertyChanged("Type");
        }
        DNMultiLanguage.SetUILanguageCulture(DNMultiLanguage.CurrentCultureInfo, DNMultiLanguage.CurrentUICultureInfo);
      }
    }
    public static LanguageTypeHandler Current { get; set; }
    static LanguageTypeHandler() {
      if(Current == null) Current = new LanguageTypeHandler();
    }
  }
}
