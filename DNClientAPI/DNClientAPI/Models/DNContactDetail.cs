using Newtonsoft.Json;
using System.ComponentModel;

namespace DNClientAPI.Models {

  /// <summary>
  /// Contact Detail
  /// </summary>
  public class DNContactDetail : INotifyPropertyChanged {
    private ContactDetailType _type;
    private long _uniqueNo;
    private string _value;
    /// <summary>
    /// Contact Detail Type
    /// </summary>
    public enum ContactDetailType {

      /// <summary>
      /// Telephone
      /// </summary>
      TEL,

      /// <summary>
      /// Mobile
      /// </summary>
      MOBILE,

      /// <summary>
      /// Fax
      /// </summary>
      FAX,

      /// <summary>
      /// E-mail Address
      /// </summary>
      EMAIL,

      /// <summary>
      /// Website
      /// </summary>
      WEBSITE,

      /// <summary>
      /// Customer ID
      /// </summary>
      CUSTID,

      /// <summary>
      /// Mifare
      /// </summary>
      MIFARE,

      /// <summary>
      /// Push
      /// </summary>
      PUSH,

      /// <summary>
      /// Facebook
      /// </summary>
      FACEBOOK,

      /// <summary>
      /// Invoice E-mail Address
      /// </summary>
      INVOICEEMAIL,

      /// <summary>
      /// Order E-mail Address
      /// </summary>
      ORDERMAIL,

      /// <summary>
      /// EMAILPURRING
      /// </summary>
      EMAILPURRING
    }

    #region Properties

    /// <summary>
    /// Contact Detail Type
    /// </summary>    
    [JsonProperty("Type")]
    public ContactDetailType Type {
      get { return _type; }
      set {
        if (_type != value) {
          _type = value;
          OnPropertyChanged("Type");
        }
      }
    }

    /// <summary>
    /// Number
    /// </summary>    
    [JsonProperty("UniqueNo")]
    public long UniqueNo {
      get { return _uniqueNo; }
      set {
        if (_uniqueNo != value) {
          _uniqueNo = value;
          OnPropertyChanged("UniqueNo");
        }
      }
    }

    /// <summary>
    /// Value
    /// </summary>    
    [JsonProperty("Value")]
    public string Value {
      get { return _value; }
      set {
        if (_value != value) {
          _value = value;
          OnPropertyChanged("Value");
        }
      }
    }
    [JsonProperty("telephone_number")]
    public string Telephone { get; set; }

    /// <summary>
    /// Returns the first mobile number found in the list of contact details
    /// </summary>
    [JsonProperty("mobile_number")]
    public string Mobile { get; set; }

    /// <summary>
    /// Returns the first e-mail address found in the list of contact details
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    
    [JsonProperty("fax")]
    public string Fax { get; set; }

    [JsonProperty("invoicemail")]
    public string Invoicemail { get; set; }

    [JsonProperty("ordermail")]
    public string Ordermail { get; set; }

    [JsonProperty("emailpurring")]
    public string Emailpurring { get; set; }

    [JsonProperty("website")]
    public string Website { get; set; }

    #endregion Properties

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName = "") {
      var changed = PropertyChanged;
      if (changed == null)
        return;
      changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
}
