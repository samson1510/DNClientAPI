using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
namespace DNClientAPI.Models {
  public class DNDuncode:BaseModel {

    public DNDuncode() {
      lines = new ObservableCollection<DNDuncodeline>();
      lines.CollectionChanged += Lines_CollectionChanged; ;
    }
    private void Lines_CollectionChanged(object sender,System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
      if(e.NewItems != null) {
        foreach(DNDuncodeline item in e.NewItems) {
          item.Parent = this;
        }
      }
    }
    [JsonProperty("allowed_shops")]
    public long? AllowedShops { get; set; }
    [JsonProperty("discount_number")]
    public string DiscountNumber { get; set; }
    [JsonProperty("end_date")]
    public DateTime? EndDate { get; set; }
    [JsonProperty("is_headoffice_Discount")]
    public double? is_headoffice_Discount { get; set; }
    [JsonProperty("lines")]
    public ObservableCollection<DNDuncodeline> lines { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("start_date")]
    public DateTime? StartDate { get; set; }
    [JsonProperty("status")]
    public object status { get; set; }
    [JsonProperty("type")]
    public int type { get; set; }
    [JsonProperty("week_days")]
    public long? WeekDays { get; set; }
    [JsonProperty("actual_sales_price")]
    public double ActualSalesPrice { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("discount_amount")]
    public double DiscountAmount { get; set; }
    [JsonProperty("discount_percentage")]
    public double DiscountPercentage { get; set; }
    [JsonProperty("flag")]
    public object Flag { get; set; }
    [JsonProperty("gross_profit_percentage")]
    public double GrossProfitPercentage { get; set; }
    [JsonProperty("items_in_package")]
    public long ItemInPackage { get; set; }
    [JsonProperty("last_modified_user")]
    public object LastModifiedUser { get; set; }
    [JsonProperty("number_of_sales_allowed")]
    public int NumberOfSalesAllowed { get; set; } = 0;
    [JsonProperty("profile_number")]
    public string ProfileNumber { get; set; }
    [JsonProperty("sales_price_before_discount")]
    public double TotalSalesPrice { get; set; }
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }
    [JsonProperty("total_net_purchase_price")]
    public double TotalNetPurchasePrice { get; set; }
    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("total_vat_amount")]
    public double TotalVatAmount { get; set; }
    [JsonIgnore]
    public Language LanguageType { get; set; }

    [JsonProperty("TypeData")]
    public string TypeData {
      get { return "Samlevare"; }
    }
  }
  public class DNDuncodeline:BaseModel {
    private double _lineamount = 0;
    private double _quantity = 0;
    private double _salesprice = 0;

    [JsonProperty("__type")]
    public string __type { get; set; } = "duncode_discount_line:#DataNova.Discount";
    [JsonProperty("entity_type")]
    public string EntityType { get; set; }
    [JsonProperty("is_ehandle")]
    public bool IsEhandle { get; set; }
    [JsonProperty("is_inactive")]
    public bool IsInactive { get; set; }
    [JsonProperty("is_label_flag")]
    public bool IsLabelFlag { get; set; }
    [JsonProperty("item_name")]
    public string ItemName { get; set; }
    [JsonProperty("item_number")]
    public long ItemNumber { get; set; }
    [JsonProperty("line_amount")]
    public double LineAmount { get { return Math.Round(_lineamount,2); } set { _lineamount = Math.Round(value,2); } }
    [JsonProperty("line_number")]
    public int LineNumber { get; set; }
    [JsonProperty("net_purchase_price")]
    public double NetPurchasePrice { get; set; }
    [JsonProperty("qty")]
    public double Qty { get { return Math.Round(_quantity,2); } set { _quantity = Math.Round(value,2); } }
    [JsonProperty("sales_price")]
    public double SalesPrice { get { return Math.Round(_salesprice,2); } set { _salesprice = Math.Round(value,2); } }
    [JsonProperty("total_filtered_records")]
    public int total_filtered_records { get; set; }
    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("vat_percentage")]
    public double VatPercentage { get; set; }
    [JsonIgnore]
    public DNDuncode Parent { get; internal set; }
    [JsonProperty("TypeData")]
    public string TypeData {
      get { return "Vare"; }
    }
  }

}