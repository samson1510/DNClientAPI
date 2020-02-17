using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DNClientAPI.Models {

  /// <summary>
  /// Address
  /// </summary>

  public class DNShopProfile:BaseModel {
    private string _profilenumber, _profilename;
    public DNShopProfile() {
      // Pincode = new DNPincode();
    }
    #region Properties

    /// <summary>
    /// Profile Number
    /// </summary>        
    [JsonProperty("profile_number")]
    public string ProfileNumber {
      get { return _profilenumber; }
      set {
        if(_profilenumber != value) {
          _profilenumber = value;
          OnPropertyChanged("ProfileNumber");
        }
      }
    }

    /// <summary>
    /// Profile Name
    /// </summary>    
    [JsonProperty("name")]
    public string ProfileName {
      get { return _profilename; }
      set {
        if(_profilename != value) {
          _profilename = value;
          OnPropertyChanged("ProfileName");
        }
      }
    }
    #endregion
  }
}