using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DNClientAPI.Models {

  /// <summary>
  /// Address
  /// </summary>

  public class DNAddress: BaseModel {
    private string _address1, _address2, _address3;
    private DNPincode _pinCode;

    public DNAddress() {
      Pincode = new DNPincode();
    }
    #region Properties

    /// <summary>
    /// Address Line 1
    /// </summary>        
    [JsonProperty("address1")]
    public string Address1 {
      get { return _address1; }
      set {
        if (_address1 != value) {
          _address1 = value;
          OnPropertyChanged("Address1");
        }
      }
    }

    /// <summary>
    /// Address Line 2
    /// </summary>    
    [JsonProperty("address2")]
    public string Address2 {
      get { return _address2; }
      set {
        if (_address2 != value) {
          _address2 = value;
          OnPropertyChanged("Address2");
        }
      }
    }

    /// <summary>
    ///  Address Line 3
    /// </summary>
    [JsonProperty("address3")]
    public string Address3 {
      get { return _address3; }
      set {
        if (_address3 != value) {
          _address3 = value;
          OnPropertyChanged("Address3");
        }
      }
    }

    /// <summary>
    /// Pincode
    /// </summary>
    [JsonProperty("pincode")]
    public DNPincode Pincode {
      get { return _pinCode; }
      set {
        if (_pinCode != value) {
          _pinCode = value;
          OnPropertyChanged("Pincode");
        }
      }
    }
    #endregion
  }
}