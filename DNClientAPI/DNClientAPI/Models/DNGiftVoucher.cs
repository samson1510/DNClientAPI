using Newtonsoft.Json;
using System;
using DataNova.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DNClientAPI.Models {
  public class DNGiftVoucher : BaseModel {
    private string _giftVoucherNumber;
    private DateTime _purchaseDate;
    private DateTime _expiryDate;
    private double _amount;
    private double _balanceAmount;
    private double _amountUsed;
    private long _numberofPurchase;
    private string _name;
    private string _memberNumber;
    private DateTime _lastUserDate;
    private long _shopNumber;
    private long _customerNumber;
    private GiftVocherType? _type;


    //[JsonProperty("GiftVoucherNumber")]
    [JsonProperty("voucher_number")]
    public string GiftVoucherNumber {
      get { return _giftVoucherNumber; }
      set {
        if(_giftVoucherNumber != value) {
          _giftVoucherNumber = value;
          OnPropertyChanged("GiftVoucherNumber");
        }
      }
    }

    //[JsonProperty("PurchaseDate")]
   [JsonProperty("creation_date")]
    public DateTime PurchaseDate {
      get { return _purchaseDate; }
      set {
        if(_purchaseDate != value) {
          _purchaseDate = value;
          OnPropertyChanged("PurchaseDate");
        }
      }
    }

    //[JsonProperty("ExpiryDate")]
    [JsonProperty("expiry_date")]
    public DateTime ExpiryDate {
      get { return _expiryDate; }
      set {
        if(_expiryDate != value) {
          _expiryDate = value;
          OnPropertyChanged("ExpiryDate");
        }
      }
    }

    //[JsonProperty("Amount")]
    [JsonProperty("original_value")]
    public double Amount {
      get { return _amount; }
      set {
        if(_amount != value) {
          _amount = value;
          OnPropertyChanged("Amount");
        }
      }
    }

    //[JsonProperty("BalanceAmount")]
    [JsonProperty("current_balance")]
    public double BalanceAmount {
      get { return _balanceAmount; }
      set {
        if(_balanceAmount != value) {
          _balanceAmount = value;
          OnPropertyChanged("BalanceAmount");
        }
      }
    }

    #region  giftvoucher payment 
    [JsonProperty("amount_used")]
    public double AmountUsed {
      get { return _amountUsed; }
      set {
        if(_amountUsed != value) {
          _amountUsed = value;
          OnPropertyChanged("AmountUsed");
        }
      }
    }
    [JsonProperty("customer_number")]
    public long CustomerNumber {
      get { return _customerNumber; }
      set {
        if(_customerNumber != value) {
          _customerNumber = value;
          OnPropertyChanged("CustomerNumber");
        }
      }
    }

    [JsonProperty("last_used_date")]
    public DateTime LastUsedDate {
      get { return _lastUserDate; }
      set {
        if(_lastUserDate != value) {
          _lastUserDate = value;
          OnPropertyChanged("LastUsedDate");
        }
      }
    }

    [JsonProperty("member_number")]
    public string MemberNumber {
      get { return _memberNumber; }
      set {
        if(_memberNumber != value) {
          _memberNumber = value;
          OnPropertyChanged("MemberNumber");
        }
      }
    }

    [JsonProperty("name")]
    public string Name {
      get { return _name; }
      set {
        if(_name != value) {
          _name = value;
          OnPropertyChanged("Name");
        }
      }
    }
    [JsonProperty("number_of_purchase")]
    public long NumberOfPurchase {
      get { return _numberofPurchase; }
      set {
        if(_numberofPurchase != value) {
          _numberofPurchase = value;
          OnPropertyChanged("NumberOfPurchase");
        }
      }
    }

    [JsonProperty("shop_number")]
    public long ShopNumber {
      get { return _shopNumber; }
      set {
        if(_shopNumber != value) {
          _shopNumber = value;
          OnPropertyChanged("ShopNumber");
        }
      }
    }

    [JsonProperty("type")]
    public GiftVocherType? Type {
      get { return _type; }
      set {
        if(_type != value) {
          _type = value;
          OnPropertyChanged("Type");
        }
      }
    }

    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }

    #endregion
  }
}
