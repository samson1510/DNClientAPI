using DataNova.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DNClientAPI.Models {
  public class DNSalesOrder : BaseModel {
    private string _ordernumber;
    private long _customernumber;
    public string _customername;
    private DateTime _orderdate;
    private DateTime _deliverdate;
    private double _totalamount;
    private double _totalorderedquantity;
    private double _totaldeliveredquantity;
    private long _shopNumber;
    private string _status;
    private string _shopName;
    private int _totalOrderLine;
    private int _totalOrderdeliveredLine;
    private long _orderdatelong;
    [JsonProperty("order_number")]
    public string OrderNumber {
      get { return _ordernumber; }
      set {
        if(_ordernumber != value) {
          _ordernumber = value;
          OnPropertyChanged("OrderNumber");
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
    [JsonProperty("shop_name")]
    public string ShopName {
      get { return _shopName; }
      set {
        if(_shopName != value) {
          _shopName = value;
          OnPropertyChanged("ShopName");
        }
      }
    }
    [JsonProperty("customer_number")]
    public long CustomerNumber {
      get { return _customernumber; }
      set {
        if(_customernumber != value) {
          _customernumber = value;
          OnPropertyChanged("CustomerNumber");
        }
      }
    }
    [JsonProperty("customer_name")]
    public string CustomerName {
      get { return _customername; }
      set {
        if(_customername != value) {
          _customername = value;
          OnPropertyChanged("CustomerName");
        }
      }
    }
    [JsonProperty("date")]
    public long OrderDateLong {
      get { return _orderdatelong;}
      set {
        if (_orderdatelong != value) {
          _orderdatelong = value;
          OrderDate = _orderdatelong.ToLocalDateTime();
        }
      }
    }

    [JsonProperty("order_date")]
    public DateTime OrderDate {
      get { return _orderdate; }
      set {
        if(_orderdate != value) {
          _orderdate = value;
          OnPropertyChanged("OrderDate");
        }
      }
    }


    public DateTime DeliverDate {
      get { return _deliverdate; }
      set {
        if(_deliverdate != value) {
          _deliverdate = value;
          OnPropertyChanged();
        }
      }
    }

    public double TotalOrderedQuantity {
      get { return _totalorderedquantity; }
      set {
        if(_totalorderedquantity != value) {
          _totalorderedquantity = value;
          OnPropertyChanged("TotalOrderedQuantity");
        }
      }
    }
    public double TotalAmount {
      get { return _totalamount; }
      set {
        if(_totalamount != value) {
          _totalamount = value;
          OnPropertyChanged("TotalAmount");
        }
      }
    }
    public double TotalDeliveredQuantity {
      get { return _totaldeliveredquantity; }
      set {
        if(_totaldeliveredquantity != value) {
          _totaldeliveredquantity = value;
          OnPropertyChanged("TotalDeliveredQuantity");
        }
      }
    }

    [JsonProperty("status_text")]
    public string Status {
      get { return _status; }
      set {
        if(_status != value) {
          _status = value;
          OnPropertyChanged("Status");
        }
      }
    }
    public int TotalOrderedLines {
      get { return _totalOrderLine; }
      set {
        if(_totalOrderLine != value) {
          _totalOrderLine = value;
          OnPropertyChanged("TotalOrderedLines");
        }
      }
    }
    public int TotalOrderedeliveredLines {
      get { return _totalOrderdeliveredLine; }
      set {
        if(_totalOrderdeliveredLine != value) {
          _totalOrderdeliveredLine = value;
          OnPropertyChanged("TotalOrderedeliveredLines");
        }
      }
    }
    public string QRString { get; set; }
    public object Parent { get; set; }
    [JsonProperty("order_lines")]
    public ObservableCollection<DNSalesOrderLine> Lines { get; set; }
    public DNSalesOrder() {
      Lines = new ObservableCollection<DNSalesOrderLine>();
      Lines.CollectionChanged += Lines_CollectionChanged;
    }

    private void Lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
      if(e.NewItems != null) {
        foreach(DNSalesOrderLine line in e.NewItems) {
          line.Parent = this;
        }
      }
    }



    #region New Properties
    [JsonProperty("billing_address")]
    public BillingAddress BillingAddress { get; set; }
    [JsonProperty("courier_type")]
    public object CourierType { get; set; }
    [JsonProperty("delivery_date")]
    public long DeliveryDate { get; set; }
    [JsonProperty("gross_profit_amount")]
    public float GrossProfitAmount { get; set; }
    [JsonProperty("notes")]
    public string Notes { get; set; }
    [JsonIgnore]
    public List<DNSalesOrderLine> OrderLines { get; set; }

    
    [JsonProperty("order_statuscode", NullValueHandling = NullValueHandling.Ignore)]
    public bool OrderStatuscode { get; set; }
    [JsonProperty("order_type")]
    public string OrderType { get; set; }
    [JsonProperty("payment_type")]
    public string PaymentType { get; set; }
    [JsonProperty("sending_number")]
    public object SendingNumber { get; set; }
    [JsonProperty("serial_number")]
    public string SerialNumber { get; set; }
    [JsonProperty("shipping_address")]
    public ShippingAddress ShippingAddress { get; set; }
    public bool Sold { get; set; }
    [JsonProperty("terminal_number")]
    public long TerminalNumber { get; set; }
    [JsonProperty("total_Order_amount")]
    public float TotalOrderAmount { get; set; }
    [JsonProperty("total_delivered_lines")]
    public int TotalDeliveredLines { get; set; }
    [JsonProperty("total_delivered_qty")]
    public int TotalDeliveryQty { get; set; }
    [JsonProperty("total_discount")]
    public float TotalDiscount { get; set; }
    [JsonProperty("total_lines")]
    public int TotalLines { get; set; }
    [JsonProperty("total_order_qty")]
    public int TotalOrderQty { get; set; }
    [JsonProperty("total_quantity_delivered")]
    public float TotalQuantityDelivered { get; set; }
    [JsonProperty("total_quantity_ordered")]
    public float TotalQuantityOrdered { get; set; }
    [JsonProperty("total_sales_price")]
    public float TotalSalesPrice { get; set; }
    [JsonProperty("total_vat")]
    public float TotalVat { get; set; }
    [JsonProperty("tracking_number")]
    public object TrackingNumber { get; set; }
    [JsonProperty("transaction_ref")]
    public string TransactionRef { get; set; }
    [JsonProperty("transport_type")]
    public string TransportType { get; set; }
    [JsonProperty("created_by")]
    public int? CreatedBy { get; set; }
    [JsonProperty("user_number")]
    public int UserNumber { get; set; }
    [JsonProperty("user_name")]
    public string UserName { get; set; }
    [JsonProperty("your_comments")]
    public string YourComments { get; set; }


    [JsonProperty("partly_paid")]
    public float PartlyPaid { get; set; }
    [JsonProperty("contact_person")]
    public string ContactPerson { get; set; }
    [JsonProperty("project_number")]
    public string ProjectNumber { get; set; }
    [JsonProperty("offer_order_flag")]
    public bool OfferOrderFlag { get; set; }
    #endregion


    private string _transactionId;
    [JsonProperty("transaction_Id")]
    public string TransactionId {
      get { return _transactionId; }
      set {
        if(_transactionId != value) {
          _transactionId = value;
          OnPropertyChanged("TransactionId");
        }
      }
    }
    private string _transactionStatus;
    [JsonProperty("transaction_status")]
    public string TransactionStatus {
      get { return _transactionStatus; }
      set {
        if(_transactionStatus != value) {
          _transactionStatus = value;
          OnPropertyChanged("TransactionStatus");
        }
      }
    }

    private string _responseText;
    [JsonProperty("response_text")]
    public string ResponseText {
      get { return _responseText; }
      set {
        if(_responseText != value) {
          _responseText = value;
          OnPropertyChanged("ResponseText");
        }
      }
    }

    private bool _isGuest;
    [JsonProperty("is_guest")]
    public bool IsGuest {
      get { return _isGuest; }
      set {
        if(_isGuest != value) {
          _isGuest = value;
          OnPropertyChanged("IsGuest");
        }
      }
    }

    private string _paymentMethod;
    [JsonProperty("payment_method")]
    public string PaymentMethod {
      get { return _paymentMethod; }
      set {
        if(_paymentMethod != value) {
          _paymentMethod = value;
          OnPropertyChanged("PaymentMethod");
        }
      }
    }

    private string _customerEMail;
    [JsonProperty("customer_email")]
    public string CustomerEMail {
      get { return _customerEMail; }
      set {
        if(_customerEMail != value) {
          _customerEMail = value;
          OnPropertyChanged("CustomerEMail");
        }
      }
    }

    private string _customerMobileNo;
    [JsonProperty("customer_mobileno")]
    public string CustomerMobileNo {
      get { return _customerMobileNo; }
      set {
        if(_customerMobileNo != value) {
          _customerMobileNo = value;
          OnPropertyChanged("CustomerMobileNo");
        }
      }
    }

  }
  public class BillingAddress {
    [JsonProperty("address1")]
    public string address1 { get; set; }
    [JsonProperty("address2")]
    public string address2 { get; }
    [JsonProperty("address3")]
    public string address3 { get; set; }
    [JsonProperty("pincode")]
    public PincodeDN pincodedn { get; set; }
  }
  public class PincodeDN {
    [JsonProperty("city")]
    public string city { get; set; }
    [JsonProperty("country")]
    public string country { get; set; }
    [JsonProperty("number")]
    public string number { get; set; }
    [JsonProperty("state")]
    public string state { get; set; }
  }
  public class ShippingAddress {
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string address3 { get; set; }
    public PincodeShipping pincodeShippning { get; set; }
  }

  public class PincodeShipping {
    public string city { get; set; }
    public string country { get; set; }
    public string number { get; set; }
    public string state { get; set; }
  }
  public class DNSalesOrderLine : INotifyPropertyChanged {
    [JsonIgnore]
    public DNSalesOrder Parent { get; set; }
    private long _itemnumber;
    private string _itemname;
    private double _orderedquantity;
    private double _delivedquantity;
    private double _amount;
    private string _itemlocation;
    private string _picklocation;
    private string _supplieritemno;
    private double _stockquantity;
    private Nullable<double> _difference;
    private double _availablestockquantity;
    private double _kolli;
    private string _sortmentcode;
    private string _suppliername;
    private double _quantitytodeliver;
    private OrderLineStatus? _status;
    private string _lineordernumber;
    private bool _qtyreduced = false;
    [JsonProperty("item_number")]
    public long ItemNumber {
      get { return _itemnumber; }
      set {
        if(_itemnumber != value) {
          _itemnumber = value;
          OnPropertyChanged("ItemNumber");
        }
      }
    }
    [JsonProperty("item_name")]
    public string ItemName {
      get { return _itemname; }
      set {
        if(_itemname != value) {
          _itemname = value;
          OnPropertyChanged("ItemName");
        }
      }
    }
    [JsonProperty("ordered_qty")]
    public double OrderedQuantity {
      get { return _orderedquantity; }
      set {
        if(_orderedquantity != value) {
          _orderedquantity = value;
          OnPropertyChanged("OrderedQuantity");
          CalculateDifference();
        }
      }
    }
    [JsonProperty("delivered_qty")]
    public double DeliveredQuantity {
      get { return _delivedquantity; }
      set {
        if(_delivedquantity != value) {
          _delivedquantity = value;
          OnPropertyChanged("DeliveredQuantity");
          CalculateDifference();
        }
      }
    }
    public double Amount {
      get { return _amount; }
      set {
        if(_amount != value) {
          _amount = value;
          OnPropertyChanged("Amount");
        }
      }
    }
    [JsonProperty("item_location")]
    public string ItemLocation {
      get { return _itemlocation; }
      set {
        if(_itemlocation != value) {
          _itemlocation = value;
          OnPropertyChanged("ItemLocation");
        }
      }
    }
    [JsonProperty("item_picklocation")]
    public string PickLocation {
      get { return _picklocation; }
      set {
        if(_picklocation != value) {
          _picklocation = value;
          OnPropertyChanged("PickLocation");
        }
      }
    }
    [JsonProperty("supplier_item_number")]
    public string SupplierItemNo {
      get { return _supplieritemno; }
      set {
        if(_supplieritemno != value) {
          _supplieritemno = value;
          OnPropertyChanged("SupplierItemNo");
        }
      }
    }
    public double StockQuantity {
      get { return _stockquantity; }
      set {
        if(_stockquantity != value) {
          _stockquantity = value;
          OnPropertyChanged("StockQuantity");
        }
      }
    }
    public double AvailableStockQuantity {
      get { return _availablestockquantity; }
      set {
        if(_availablestockquantity != value) {
          _availablestockquantity = value;
          OnPropertyChanged("AvailableStockQuantity");
        }
      }
    }
    public Nullable<double> Difference {
      get { return _difference; }
      set {
        if(_difference != value) {
          _difference = value;
          OnPropertyChanged("Difference");
          if(Parent != null && _difference != null) {
            Parent.Status = "INPROGRESS";
          }
        }
      }
    }
    [JsonProperty("kolli")]
    public double Kolli {
      get { return _kolli; }
      set {
        if(_kolli != value) {
          _kolli = value;
          OnPropertyChanged("Kolli");
        }
      }
    }
    [JsonProperty("sortmentcode")]
    public string SortmentCode {
      get { return _sortmentcode; }
      set {
        if(_sortmentcode != value) {
          _sortmentcode = value;
          OnPropertyChanged("SortmentCode");
        }
      }
    }
    [JsonProperty("suppliername")]
    public string SupplierName {
      get { return _suppliername; }
      set {
        if(_suppliername != value) {
          _suppliername = value;
          OnPropertyChanged("SupplierName");
        }
      }
    }
    public double QuantityToDeliver {
      get { return _quantitytodeliver; }
      set {
        //if (_quantitytodeliver != value) {
        _quantitytodeliver = value;
        OnPropertyChanged("QuantityToDeliver");
      }
      //}
    }
    public bool Isqtyreduced {
      get { return _qtyreduced; }
      set {
        if(_qtyreduced != value) {
          _qtyreduced = value;
        }
      }
    }
    public void CalculateDifference() {
      if(OrderedQuantity > 0 && DeliveredQuantity > 0) {
        Difference = (OrderedQuantity - DeliveredQuantity);
      } else {
        if(DeliveredQuantity == 0 && Status == OrderLineStatus.INPROGRESS)
          Difference = (OrderedQuantity - DeliveredQuantity);
        else
          Difference = null;
      }
      QuantityToDeliver = OrderedQuantity - DeliveredQuantity;
    }
    [JsonProperty("line_status")]
    public OrderLineStatus? Status {
      get { return _status; }
      set {
        if(_status != value) {
          _status = value;
          OnPropertyChanged("Status");
        }
      }
    }
    public string Lineordernumber {
      get { return _lineordernumber; }
      set {
        if(_lineordernumber != value) {
          _lineordernumber = value;
          OnPropertyChanged("Lineordernumber");
        }
      }
    }

    private string _customername;
    public string Customername {
      get { return _customername; }
      set {
        if(_customername != value) {
          _customername = value;
          OnPropertyChanged("Customername");
        }
      }
    }

    private string _colorStatus;
    public string colorStatus {
      get { return _colorStatus; }
      set {
        if(_colorStatus != value) {
          _colorStatus = value;
          OnPropertyChanged("colorStatus");
        }
      }
    }
    [JsonProperty("event_id")]
    public int EventId { get; set; }
    [JsonProperty("line_eventdetails")]
    public DNOrderEventDetails EventDetails { get; set; }
    [JsonProperty("reservation_no")]
    public long? ReservationNo { get; set; }
    [JsonProperty("seat_no")]
    public int? SeatNo { get; set; }
    [JsonProperty("room_time_slot")]
    public long? RoomTimeSlot { get; set; }

    #region New Properties 
    [JsonProperty("campaign_number")]
    public string CampaignNumber { get; set; }
    public string Comment { get; set; }
    [JsonProperty("delivered_date")]
    public long? DeliveredDate { get; set; }
    public float DeliveredQty { get; set; }
    [JsonProperty("discount_amount")]
    public float DiscountAmount { get; set; }
    public float DiscountPercent { get; set; }
    public int ExpectedDeliveryDate { get; set; }
    public int ItemGroupNumber { get; set; }
    public int ItemLagerStock { get; set; }
    public object ItemPickLocation { get; set; }
    public int LineNumber { get; set; }
    public string LineOrderNumber { get; set; }
    public object LineStatus { get; set; }
    public float LineTotal { get; set; }
    public float OrderedQty { get; set; }
    public float PurchasePrice { get; set; }
    public string ReceiptText { get; set; }
    [JsonProperty("sales_price")]
    public float SalesPrice { get; set; }
    public float SalesWithoutVat { get; set; }
    public float SalespriceWithoutDiscount { get; set; }
    public object Sortmentcode { get; set; }
    public string SupplierItemNumber { get; set; }
    public int SupplierNumber { get; set; }
    public string Text1 { get; set; }
    public string Text2 { get; set; }
    public float UnitPrice { get; set; }
    public string UnitType { get; set; }
    public float VatAmount { get; set; }
    public float VatPercent { get; set; }
    [JsonProperty("entity_type")]
    public string EntityType { get; set; }
    [JsonProperty("coupon_id")]
    public string CodeDiscountId { get; set; }
    [JsonProperty("discount_id")]
    public long DiscountID { get; set; }
    [JsonProperty("discount_type")]
    public ReceiptDiscountType ReceiptDiscountType { get; set; }
    #endregion

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName = "") {
      var changed = PropertyChanged;
      if(changed == null)
        return;

      changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion


  }
  public class DNOrderEventDetails {
    private int? _eventid;
    private long _eventstartdate;
    private long _eventenddate;
    [JsonProperty("event_id")]
    public int? EventId {
      get { return _eventid; }
      set {
        if (_eventid != value) {
          _eventid = value;
          if (_eventid != null) SmallImagePath = "bookingimages/" + _eventid + "_1.jpg";
        }
      }
    }
    [JsonProperty("event_name")]
    public string eventName { get; set; }
    [JsonProperty("event_startdate")]
    public long eventstartdate {
      get { return _eventstartdate; }
      set {
        if (_eventstartdate != value) {
          _eventstartdate = value;
          StartDate = _eventstartdate.ToLocalDateTime();
        }
      }
    }
    [JsonProperty("event_enddate")]
    public long eventenddate {
      get { return _eventenddate; }
      set {
        if (_eventenddate != value) {
          _eventenddate = value;
          EndDate = _eventenddate.ToLocalDateTime();
        }
      }
    }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [JsonProperty("is_ticketitem")]
    public bool Isticketitem { get; set; }
    [JsonProperty("event_venu")]
    public string EventVenu { get; set; }
    public string ErrorSmallImagePath {
      get {
        string path = "";
        int eventtype = 1;
        switch (eventtype) {
          case 1:
            path = "webshop/event_small.jpg";
            break;
          case 2:
            path = "webshop/ticket_small.jpg";
            break;
          case 3:
            path = "webshop/seasoncard_small.jpg";
            break;
        }
        return path;
      }
    }
    public string SmallImagePath {get; set;}
    [JsonProperty("period_id")]
    public long? PeriodId {
      get; set;
    }
  }
}
