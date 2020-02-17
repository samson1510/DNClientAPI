using Newtonsoft.Json;
namespace DNClientAPI.Models {
  public class DNShopSmallDTO : BaseModel {
    long _shopNumber;
    public DNShopSmallDTO() {      
    }        
    
    public bool Select { get; set; }

    [JsonProperty("shop_number")]
    public long ShopNumber {
      get {
        return _shopNumber;
      }
      set {
        if(_shopNumber != value) {
          _shopNumber = value;
          ShopNumberandName = _shopNumber.ToString() + "," + Shopname;
        }
         
      }
    }
    [JsonProperty("name")]
    public string Shopname { get; set; }
    [JsonProperty("vat_free")]
    public bool? VATFree { get; set; }
    [JsonProperty("isusershop")]
    public bool IsuserShop { get; set; }
    [JsonProperty("profile_number")]
    public string ShopProfileNumber { get; set; }
    public string ShopNumberandName { get; set; }
  }
}
