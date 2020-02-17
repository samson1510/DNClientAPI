using Newtonsoft.Json;
using System.Collections.Generic;
using DNClientAPI.Globalization;
using DataNova.Common;

namespace DNClientAPI.Models {
  public class DNItem:BaseModel {
    private DNSortimentCode _sortment;
    public DNItem() {
      VatRate = new DNVatRate();
      _sortment = new DNSortimentCode();
      _iteminpackage = 1;
      isforpurchase = true;
      isforsale = true;
    }
    protected string _imagePath;
    private double _iteminpackage;
    [JsonProperty("name")]
    public string ItemName { get; set; }
    [JsonProperty("item_number")]
    public long Itemnumber { get; set; }
    [JsonProperty("supplier_item_number")]
    public string SupplierItemnumber { get; set; }
    [JsonProperty("sales_price")]
    public double SalesPrice { get; set; }
    [JsonProperty("item_group_number")]
    public string ItemGroup { get; set; }
    [JsonProperty("supplier_number")]
    public long SupplierNumber { get; set; }
    [JsonProperty("supplier_name")]
    public string SupplierName { get; set; }
    [JsonIgnore]
    public string Id { get; set; }
    [JsonIgnore]
    public string Text { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("purchase_price")]
    public double Purchaseprice { get; set; }
    [JsonProperty("theostock_price")]
    public double theostock { get; set; }
    [JsonProperty("quantitycounted_price")]
    public double quantitycounted { get; set; }
    [JsonProperty("endtime_price")]
    public double endtime { get; set; }
    [JsonProperty("difference")]
    public double difference { get; set; }
    [JsonProperty("insubset")]
    public double insubset { get; set; }
    [JsonProperty("TotPrice")]
    public double TotPrice { get; set; }
    [JsonProperty("net_purchase_price")]
    public double NetPurchaseprice { get; set; }
    [JsonProperty("campaign_price")]
    public double? Campaignprice { get; set; }
    [JsonProperty("item_group_name")]
    public string ItemGroupName { get; set; }
    [JsonProperty("weight_flag")]
    public bool IsWeightItem { get; set; }
    public bool Select { get; set; }

    [JsonProperty("TypeData")]
    public string TypeData {
      get { return "Vare"; }
    }

    [JsonProperty("package_qty")]
    public double ItemInPackage {
      get {
        return _iteminpackage;
      }
      set {
        if(_iteminpackage != value) {
          _iteminpackage = value;
        }
      }
    }
    [JsonIgnore]
    public string Sortmentcode { get; set; }
    [JsonProperty("variety")]
    public DNSortimentCode Sortment {
      get { return _sortment; }
      set {
        if(_sortment != value) {
          _sortment = value;
        }
      }
    }
    [JsonProperty("vat_rate")]
    public DNVatRate VatRate { get; set; }

    [JsonIgnore]
    public double vatpercentage { get; set; }
    [JsonIgnore]
    public string VatCode { get; set; }
    [JsonProperty("qty")]
    public string Quantity { get; set; }
    [JsonIgnore]
    public string VatName { get; set; }
    [JsonProperty("unit_type")]
    public string UnitType { get; set; }
    [JsonProperty("profile_number")]
    public string ProfileNumber { get; set; }
    [JsonProperty("profile_name")]
    public string ProfileName { get; set; }
    [JsonProperty("conversionunit")]
    public double Enhetsfaktor { get; set; }
    [JsonProperty("kitchenprintername")]
    public string Kitchenprinter { get; set; }

    [JsonProperty("type")]
    public DNItemType ItemType { get; set; }
    [JsonProperty("commission_type")]
    public DNCommissionType CommissionType { get; set; }
    [JsonIgnore]
    public string data { get; set; }
    private bool _isImageLoaded;
    [JsonIgnore]
    public bool IsImageLoaded {
      get {
        return _isImageLoaded;
      }
      set {
        _isImageLoaded = value;
        OnPropertyChanged("IsImageLoaded");
      }
    }
    [JsonProperty("allow_for_purchase")]
    public bool isforpurchase { get; set; }
    public bool StopForPurchase {
      get {
        return !isforpurchase;
      }
      set {
        isforpurchase = !value;
      }
    }
    [JsonProperty("allow_for_sale")]
    public bool isforsale { get; set; }
    public bool StopForSale {
      get {
        return !isforsale;
      }
      set {
        isforsale = !value;
      }
    }
    [JsonProperty("is_label")]
    public bool islabel { get; set; }
    [JsonProperty("inactive")]
    public bool inactive { get; set; }
    [JsonProperty("is_ecommerce")]
    public bool isecommerce { get; set; }
    [JsonProperty("open_price_flag")]
    public bool isOpenPrice { get; set; }
    [JsonProperty("is_localpriceitem")]
    public bool islocalPrice { get; set; }
    [JsonProperty("item_location")]
    public string ItemLocation { get; set; }
    [JsonIgnore]
    public string textcode { get; set; }
    [JsonIgnore]
    public string colorcode { get; set; }
    private string _campaginprice = "";
    [JsonIgnore]
    public string campaignprice {
      get {
        return _campaginprice;
      }
      set {
        _campaginprice = value;
        textcode = textcode + _campaginprice + " ";
      }
    }
    [JsonIgnore]
    public string ImagePath {
      get {
        if(_imagePath == null) {
          _imagePath = DNGlobalProperties.Current.ImagePath + @"/ItemImages/" + Itemnumber + ".png";
        }
        return _imagePath;
      }
      set {
        if(_imagePath != value) {
          _imagePath = value;
        }
      }
    }
    [JsonIgnore]
    public object Parent { get; set; }
    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }
    [JsonProperty("bottle_return_code")]
    public int? BottleReturnCode { get; set; }
    [JsonProperty("bottle_return_amount")]
    public decimal? BottleReturnAmount { get; set; }
    [JsonProperty("item_ingredients")]
    public List<DNIngredient> Ingredients { get; set; }

    [JsonProperty("related_item_details")]
    public List<DNRelatedItemDetails> RelatedItems { get; set; }

    [JsonProperty("discount_percent")]
    public double Discountpercent { get; set; }

    [JsonProperty("ticket_details")]
    public DNTicketInfo TicketInformation { get; set; }

    /// <summary>
    /// Time info
    /// </summary>
    [JsonProperty("time_details")]
    public List<DNItemDateInfo> TimeInfo {
      get; set;
    }

    /// <summary>
    /// Gate info
    /// </summary>
    [JsonProperty("gate_details")]
    public List<DNPortInfo> GateInfo {
      get; set;
    }

    /// <summary>
    /// Gate info
    /// </summary>
    [JsonProperty("item_time_details")]
    public List<DNItemTimeDetails> ItemTimeDetails {
      get; set;
    }
    [JsonProperty("out_going_flag")]
    public bool? OutGoingFlag { get; set; }

    public string ItemDateInFoStartDate {
      get; set;
    }

    public string ItemDateInFoEndDate {
      get; set;
    }

    [JsonProperty("comments")]
    public string Comments { get; set; }
    public double SalesWithoutVat { get; set; }

    [JsonIgnore]
    public string LoginShopNumber { get; set; }
    [JsonIgnore]
    public string LogInUserId { get; set; }

    [JsonProperty("calcfactor_type")]
    public bool CalculationfactorbasedNPP { get; set; }
  }
  public class DNItems:List<DNItem> {

  }
}