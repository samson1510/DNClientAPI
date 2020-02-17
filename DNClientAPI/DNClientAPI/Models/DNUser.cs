using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataNova.Common;

namespace DNClientAPI.Models {
  public class DNUser {


    [JsonProperty("shops")]
    public List<DNShop> ShopList { get; set; }

    [DisplayName("Brukernumber")]
    [JsonProperty("user_number")]
    public long UserId { get; set; }

    [DisplayName("username")]
    [JsonProperty("name")]
    public string UserName { get; set; }

    [DisplayName("lastlogin")]
    [JsonConverter(typeof(MicrosecondEpochConverter))]
    [JsonProperty("last_login_time")]
    public DateTime LastLoggedIn { get; set; }

    [DisplayName("security")]
    [JsonProperty("security_level")]
    public int SecurityLevel { get; set; }

    [DisplayName("phone")]
    [JsonProperty("1")]
    public string PhoneNumber { get; set; }

    [DisplayName("mobile")]
    [JsonProperty("2")]
    public string MobilePhoneNumber { get; set; }

    [DisplayName("email")]
    [JsonProperty("3")]
    public string EmailAddress { get; set; }

    [DisplayName("address1")]
    [JsonProperty("4")]
    public string Address_1 { get; set; }

    [DisplayName("address2")]
    [JsonProperty("5")]
    public string Address_2 { get; set; }

    [DisplayName("postalcode")]
    [JsonProperty("6")]
    public string Postal_Code { get; set; }

    [DisplayName("postalcist")]
    [JsonProperty("7")]
    public string Postal_City { get; set; }


  }
}
