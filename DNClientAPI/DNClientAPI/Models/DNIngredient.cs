using DataNova.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace DNClientAPI.Models {
  public class DNIngredient {
    private long _validtilldatelong;
    private DateTime _validdate;
    [JsonProperty("item_ingredentquantity")]
    public decimal Quantity { get; set; }
    [JsonProperty("item_ingredentcomments")]
    public string Comments { get; set; }
    [JsonProperty("item_ingredentwastequantity")]
    public decimal WasteQuantity { get; set; }
    [JsonProperty("item_ingredenttype")]
    public string Type { get; set; }


    [JsonProperty("item_ingredenttype1")]
    
     public List<SelectListType> TypeData {get;set;}


    [JsonProperty("item_ingredentlogicalgroupno")]
    public string LogicalGroupNumber { get; set; }
    [JsonProperty("item_ingredentblockforsale")]
    public bool IsBlockedForSale { get; set; }
    [JsonProperty("item_ingredentitemnumber")]
    public long ItemNumber { get; set; }
    [JsonProperty("item_ingredentitemname")]
    public string ItemName { get; set; }
    [JsonProperty("item_ingredentnetpurchaseprice")]
    public decimal NetPurchasePrice { get; set; }
    [JsonProperty("item_ingredentunittype")]
    public string UnitType { get; set; }
    [JsonProperty("item_ingredentvatid")]
    public int VatCodeId { get; set; }
    [JsonProperty("item_ingredentitemgroupno")]
    public long ItemGroupNumber { get; set; }
    [JsonProperty("item_ingredentsupplierno")]
    public long SupplierNumber { get; set; }
    [JsonProperty("item_ingredentsalesprice")]
    public decimal SalesPrice { get; set; }

    [JsonProperty("Item_ValidTill")]
    public long? ValidTillLongNullable {
      get { return _validtilldatelong; }
      set {
        if(_validtilldatelong != value && value != null) {
          _validtilldatelong = value.Value;
          if(value != null) {
            ValidTillLong = value.Value;
          }
          ValidTill = _validtilldatelong.ToLocalDateTime();
        }
      }
    }
    public DateTime? ValidTill { get; set; }

    public long ValidTillLong {
      get; set;
    }
  }

  public class SelectListType {
    public string Text { get; set; }

    public string Value { get; set; }
  }

}
