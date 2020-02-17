using DataNova.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XRETAIL.ViewModels;

namespace DNClientAPI.Models {
  public enum TicketStatusType {
    VALID,
    USED,
    EXPIRED,
    APPLICABLE,
    ABANDONED,
    INVALID
  }
  public class DNTicketDetail : BaseViewModel {
    #region variables
    private bool _valid;
    private string _error;
    private string _customerName;
    private string _itemName;
    private long _itemNumber;
    private bool _isScanning;
    private bool _isAnalyzing;
    private string _scanningStatus;
    private bool _isTourchOn;
    private int _maxUseQty;
    private DateTime _purchaseDate;
    private DateTime _expiryDate;
    private double _useQty;
    private String _scantext;
    private int _usedcount;
    private int _approvecount;
    private long _serialno;
    private float _totalamount;
    private bool _isTicketValidated;
    private string _pagetitle;
    private long _orderNumber;
    private long? _validFromLong;
    private long? _expireDateLong;
    #endregion
    public string CustomerName {
      get { return _customerName; }
      set {
        if (_customerName != value) {
          _customerName = value;
          OnPropertyChanged("CustomerName");
        }
      }
    }
    [JsonProperty("customer_number")]
    public long CustomerNumber { get; set; }
    public DateTime ExpiryDate {
      get { return _expiryDate; }
      set {
        if (_expiryDate != value) {
          _expiryDate = value;
          OnPropertyChanged("ExpiryDate");
        }
      }
    }
    [JsonProperty("valid_from")]
    public long? ValidFromLong {
      get { return _validFromLong; }
      set {
        if (_validFromLong != value) {
          _validFromLong = value;
          if (_validFromLong != null) {
            ValidFrom = _validFromLong.Value.ToLocalDateTime();
          }
        }
      }
    }
    [JsonProperty("expiry_date")]
    public long? ExpireDateLong {
      get { return _expireDateLong; }
      set {
        if (_expireDateLong != value) {
          _expireDateLong = value;
          if (_expireDateLong != null) {
            ExpiryDate = _expireDateLong.Value.ToLocalDateTime();
          }
        }
      }
    }
    public string Flag { get; set; }
    [JsonProperty("is_renewal")]
    public bool IsRenewal { get; set; }
    public bool IsSend { get; set; }
    [JsonProperty("item_name")]
    public string ItemName {
      get { return _itemName; }
      set {
        if (_itemName != value) {
          _itemName = value;
          OnPropertyChanged("ItemName");
        }
      }
    }
    [JsonProperty("item_number")]
    public long ItemNumber {
      get { return _itemNumber; }
      set {
        if (_itemNumber != value) {
          _itemNumber = value;
          OnPropertyChanged("ItemNumber");
        }
      }
    }
    [JsonProperty("max_use_qty")]
    public int MaxUseQty {
      get { return _maxUseQty; }
      set {
        if (_maxUseQty != value) {
          _maxUseQty = value;
          OnPropertyChanged("MaxUseQty");
        }
      }
    }
    [JsonProperty("order_number")]
    public long OrderNumber {
      get { return _orderNumber; }
      set {
        if (_orderNumber != value) {
          _orderNumber = value;
          OnPropertyChanged("OrderNumber");
        }
      }
    }
    public string PriceCategory { get; set; }
    public DateTime PurchaseDate {
      get { return _purchaseDate; }
      set {
        if (_purchaseDate != value) {
          _purchaseDate = value;
          OnPropertyChanged("PurchaseDate");
        }
      }
    }
    public int ShopNumber { get; set; }
    [JsonProperty("shop_name")]
    public string ShopName { get; set; }
    public int TotalTickets { get; set; }
    public DateTime ValidFrom { get; set; }
    public TicketStatusType Status { get; set; }
    [JsonProperty("serial_number")]
    public long SerialNumber {
      get { return _serialno; }
      set {
        if (_serialno != value) {
          _serialno = value;
          OnPropertyChanged("SerialNumber");
        }
      }
    }
    [JsonProperty("total_amount")]
    public float TotalAmount {
      get { return _totalamount; }
      set {
        if (_totalamount != value) {
          _totalamount = value;
          OnPropertyChanged("TotalAmount");
        }
      }
    }
    [JsonProperty("use_qty")]
    public double UseQty {
      get { return _useQty; }
      set {
        if (_useQty != value) {
          _useQty = value;
          OnPropertyChanged("UseQty");
        }
      }
    }
    public int UsedCount {
      get { return _usedcount; }
      set {
        if (_usedcount != value) {
          _usedcount = value;
          OnPropertyChanged("UsedCount");

        }
      }
    }
    public int ApproveCount {
      get { return _approvecount; }
      set {
        if (_approvecount != value) {
          _approvecount = value;
          OnPropertyChanged("ApproveCount");

        }
      }
    }
    [JsonProperty("valid")]
    public bool Valid {
      get { return _valid; }
      set {
        if (_valid != value) {
          _valid = value;
          OnPropertyChanged("Valid");
        }
      }
    }
    public string QRString { get; set; }

    [JsonProperty("reservation_no")]
    public long? ReservationNo { get; set; }

    [JsonProperty("seat_no")]
    public int? SeatNo { get; set; }
  }
}
