using Newtonsoft.Json;
using System.Collections.Generic;
using DataNova.Common;
namespace DNClientAPI.Models {
  public class DNEventBookingItem : BaseModel {
    private double _salesprice;
    private double _discountPrice;
    private DNItem _item;
    private DNDuncode _duncode;
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("entity_number")]
    public long Number { get; set; }
    [JsonProperty("sales_price")]
    public double SalesPrice {
      get {
        switch (Type) {
          case DNBookingItemType.Item:
            _salesprice = _item != null ? _item.SalesPrice : _salesprice;
            break;
          case DNBookingItemType.Duncode:
            _salesprice = _duncode != null ? _duncode.TotalSalesPrice : _salesprice;
            break;
        }
        return _salesprice;
      }
      set {
        _salesprice = value;
      }
    }
    [JsonProperty("entity_type")]
    public DNBookingItemType Type { get; set; }

    [JsonProperty("typeString")]
    public string TypeString {
      get { return Type == DNBookingItemType.Duncode ? "Samlevare" : "Vare"; }
    }

  

    [JsonProperty("item")]
    public DNItem Item {
      get { return _item; }
      set {
        _item = value;
        if (_item != null) {
          Name = _item != null ? _item.ItemName : "";
        }
      }
    }
    [JsonProperty("duncode")]
    public DNDuncode Duncode {
      get { return _duncode; }
      set {
        _duncode = value;
        if (_duncode != null) {
          Name = _duncode != null ? _duncode.Name : "";
        }
      }
    }

    [JsonProperty("code_discount_price")]
    public double LineDiscountAmount {
      get {
        switch(Type) {
          case DNBookingItemType.Item:
            _discountPrice = _item != null ? _item.Discountpercent : _discountPrice;
            break;
          case DNBookingItemType.Duncode:
            _discountPrice = _duncode != null ? _duncode.DiscountAmount : _discountPrice;
            break;
        }
        return _discountPrice;
      }
      set {
        _discountPrice = value;
      }
    }
    [JsonProperty("code_discount_type")]
    public ReceiptDiscountType DiscountType { get; set; }
    [JsonProperty("code_discount_id")]
    public long DiscountID {
      get; set;
    }
    [JsonProperty("discount_detials")]
    public List<DNTicketDiscountDetails> DiscountDetails {
      get; set;
    }
  }
  public class DNTicketDiscountDetails:BaseModel {
    [JsonProperty("campaign_price")]
    public double CampaignPrice { get; set; }
    [JsonProperty("discount_amount")]
    public double DiscountAmount { get; set; }
    [JsonProperty("discount_name")]
    public string DiscountName { get; set; }
    [JsonProperty("discount_number")]
    public long DiscountNumber { get; set; }
    [JsonProperty("discount_percent")]
    public double DiscountPercent { get; set; }
    [JsonProperty("discount_type")]
    public ReceiptDiscountType TicketDiscountType { get; set; }
  }
}
