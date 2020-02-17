using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace XRETAIL.Models {
  public class DNPurchaseTicket : ObservableCollection<DNPurchaseTicketItem>, INotifyPropertyChanged {
    #region Ticket Details
    public long _created_date;
    public string _description;
    public int _group_type;
    public int _id;
    public string _name;
    public object _profile_number;
    public object _sub_logical_groups;
    public long CreatedDate {
      get {
        return _created_date;
      }
      set {
        if(_created_date != value) {
          _created_date = value;
          OnPropertyChanged("CreatedDate");
        }
      }
    }
    public string Description {
      get {
        return _description;
      }
      set {
        if(_description != value) {
          _description = value;
          OnPropertyChanged("Description");
        }
      }
    }
    public int GroupType {
      get {
        return _group_type;
      }
      set {
        if(_group_type != value) {
          _group_type = value;
          OnPropertyChanged("GroupType");
        }
      }
    }
    public int Id {
      get {
        return _id;
      }
      set {
        if(_id != value) {
          _id = value;
          OnPropertyChanged("Id");
        }
      }
    }
    public string Name {
      get {
        return _name;
      }
      set {
        if(_name != value) {
          _name = value;
          OnPropertyChanged("Name");
        }
      }
    }
    public object ProfileNumber {
      get {
        return _profile_number;
      }
      set {
        if(_profile_number != value) {
          _profile_number = value;
          OnPropertyChanged("ProfileNumber");
        }
      }
    }
    public object SubLogicalGroups {
      get {
        return _sub_logical_groups;
      }
      set {
        if(_sub_logical_groups != value) {
          _sub_logical_groups = value;
          OnPropertyChanged("SubLogicalGroups");
        }
      }
    }
    #endregion
    public DNPurchaseTicketLogicalGroupCategory LogicalGroupCategory { get; set; }
    public DNPurchaseTicket() {
      this.CollectionChanged += Lines_CollectionChanged;
    }

    private void Lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
      if(e.NewItems != null) {
        foreach(DNPurchaseTicketItem line in e.NewItems) {
          line.Parent = this;
        }
      }
    }
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
  public class DNPurchaseTicketItem : INotifyPropertyChanged {
    public DNPurchaseTicket Parent { get; set; }

    #region Linked Item
    public int _LinkedItemId;
    public string _LinkedItemName;
    public double _salesprice;
    public double _quantity;
    public string _supplier_item_number;
    public string _totalPrice;
    public int LinkedItemId {
      get {
        return _LinkedItemId;
      }
      set {
        if(_LinkedItemId != value) {
          _LinkedItemId = value;
          OnPropertyChanged("LinkedItemId");
        }
      }
    }
    public string LinkedItemName {
      get {
        return _LinkedItemName;
      }
      set {
        if(_LinkedItemName != value) {
          _LinkedItemName = value;
          OnPropertyChanged("LinkedItemName");
        }
      }
    }
    public double SalesPrice {
      get {
        return _salesprice;
      }
      set {
        if(_salesprice != value) {
          _salesprice = value;
          OnPropertyChanged("SalesPrice");
          OnPropertyChanged("TotalPrice");
        }
      }
    }
    public string SupplierItemNumber {
      get {
        return _supplier_item_number;
      }
      set {
        if(_supplier_item_number != value) {
          _supplier_item_number = value;
          OnPropertyChanged("SupplierItemNumber");
        }
      }
    }
    public double Quantity {
      get {
        return _quantity;
      }
      set {
        if(_quantity != value) {
          _quantity = value;
          OnPropertyChanged("Quantity");
          OnPropertyChanged("TotalPrice");

        }
      }
    }

    public double TotalPrice {
      get {
        return SalesPrice * Quantity;
      }
    }

    #endregion

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName = "") {
      var changed = PropertyChanged;
      if(changed == null)
        return;

      changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
  public class DNPurchaseTicketLogicalGroupCategory : INotifyPropertyChanged {
    public DNPurchaseTicket Parent { get; set; }
    public int _LogicalGroupCategoryId { get; set; }
    public string _LogicalGroupCategoryName { get; set; }
    public int LogicalGroupCategoryId {
      get {
        return _LogicalGroupCategoryId;
      }
      set {
        if(_LogicalGroupCategoryId != value) {
          _LogicalGroupCategoryId = value;
          OnPropertyChanged("LogicalGroupCategoryId");
        }
      }
    }
    public string LogicalGroupCategoryName {
      get {
        return _LogicalGroupCategoryName;
      }
      set {
        if(_LogicalGroupCategoryName != value) {
          _LogicalGroupCategoryName = value;
          OnPropertyChanged("LogicalGroupCategoryName");
        }
      }
    }

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
  public class DNPurchaseTicketSliderImage : INotifyPropertyChanged {
    private string _sourcePath;
    public string SourcePath {
      get {
        return _sourcePath;
      }
      set {
        if(_sourcePath != value) {
          _sourcePath = value;
          OnPropertyChanged("SourcePath");
        }
      }
    }
    public DNPurchaseTicketSliderImage() {

    }
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

  public class DNEventGrouping<K, T> : ObservableCollection<T> {
    public K Key { get; private set; }

    public DNEventGrouping(K key, IEnumerable<T> items) {
      Key = key;
      foreach(var item in items) {
        this.Items.Add(item);
      }
    }
  }
  public class DNEventItem {
    #region Properties
    public int _customer_number;
    public int CustomerNumber {
      get {
        return _customer_number;
      }
      set {
        if(_customer_number != value) {
          _customer_number = value;
          OnPropertyChanged("CustomerNumber");
        }
      }
    }
    public string _item_name;
    public string ItemName {
      get {
        return _item_name;
      }
      set {
        if(_item_name != value) {
          _item_name = value;
          OnPropertyChanged("ItemName");
        }
      }
    }
    public int _item_number;
    public int ItemNumber {
      get {
        return _item_number;
      }
      set {
        if(_item_number != value) {
          _item_number = value;
          OnPropertyChanged("ItemNumber");
        }
      }
    }

    public double _quantity;
    public double Quantity {
      get {
        return _quantity;
      }
      set {
        if(_quantity != value) {
          _quantity = value;
          OnPropertyChanged("Quantity");
          OnPropertyChanged("TotalPriceEvent");
        }
      }
    }
    public double _sales_price;
    public double SalesPrice {
      get {
        return _sales_price;
      }
      set {
        if(_sales_price != value) {
          _sales_price = value;
          OnPropertyChanged("SalesPrice");
          OnPropertyChanged("TotalPriceEvent");
        }
      }
    }
    public double TotalPriceEvent {
      get {
        return SalesPrice * Quantity;
      }
    }

    public float _sales_price_with_discount;
    public float SalesPriceWithDiscount {
      get {
        return _sales_price_with_discount;
      }
      set {
        if(_sales_price_with_discount != value) {
          _sales_price_with_discount = value;
          OnPropertyChanged("SalesPriceWithDiscount");
        }
      }
    }

    public float _sales_price_without_vat;
    public float SalesPriceWithoutVat {
      get {
        return _sales_price_without_vat;
      }
      set {
        if(_sales_price_without_vat != value) {
          _sales_price_without_vat = value;
          OnPropertyChanged("SalesPriceWithoutVat");
        }
      }
    }

    public float _vat_amount;
    public float VatAmount {
      get {
        return _vat_amount;
      }
      set {
        if(_vat_amount != value) {
          _vat_amount = value;
          OnPropertyChanged("VatAmount");
        }
      }
    }
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
  public class DNEventPeriod {
    #region variables
    private int _auditorium_number;
    private bool _reserved;
    private int _event_id;
    private DateTime _from_date;
    private string _start_time;
    private string _end_time;
    private bool _is_active;
    private int _trip_booked;
    private int _trip_capacity;
    private int _trip_id;
    private int _event_period_id;
    #endregion

    #region Properties
    public int AuditoriumNumber {
      get {
        return _auditorium_number;
      }
      set {
        if(_auditorium_number != value) {
          _auditorium_number = value;
          OnPropertyChanged("AuditoriumNumber");
        }
      }
    }
    
    public bool Reserved {
      get {
        return _reserved;
      }
      set {
        if(_reserved != value) {
          _reserved = value;
          OnPropertyChanged("Reserved");
        }
      }
    }
    public int EventId {
      get {
        return _event_id;
      }
      set {
        if(_event_id != value) {
          _event_id = value;
          OnPropertyChanged("EventId");
        }
      }
    }
    public ObservableCollection<string> demo = new ObservableCollection<string>();
    public DateTime FromDate {
      get {
        return _from_date;
      }
      set {
        if(_from_date != value) {
          _from_date = value;
          OnPropertyChanged("FromDate");
        }
      }
    }
    
    public string StartTime {
      get {
        return _start_time;
      }
      set {
        if(_start_time != value) {
          _start_time = value;
          OnPropertyChanged("StartTime");
        }
      }
    }
    
    public string EndTime {
      get {
        return _end_time;
      }
      set {
        if(_end_time != value) {
          _end_time = value;
          OnPropertyChanged("EndTime");
        }
      }
    }

    public DateTime _to_date;
    public DateTime ToDate {
      get {
        return _to_date;
      }
      set {
        if(_to_date != value) {
          _to_date = value;
          OnPropertyChanged("ToDate");
        }
      }
    }

   
    public bool IsActive {
      get {
        return _is_active;
      }
      set {
        if(_is_active != value) {
          _is_active = value;
          OnPropertyChanged("IsActive");
        }
      }
    }

   
    public int TripCapacity {
      get {
        return _trip_capacity;
      }
      set {
        if(_trip_capacity != value) {
          _trip_capacity = value;
          OnPropertyChanged("TripCapacity");
        }
      }
    }
   
    public int TripBooked {
      get {
        return _trip_booked;
      }
      set {
        if(_trip_booked != value) {
          _trip_booked = value;
          OnPropertyChanged("TripBooked");
        }
      }
    }
   
   
    public int TripId {
      get {
        return _trip_id;
      }
      set {
        if(_trip_id != value) {
          _trip_id = value;
          OnPropertyChanged("TripId");
        }
      }
    }

    public int EventPeriodId {
      get {
        return _event_period_id;
      }
      set {
        if(_event_period_id != value) {
          _event_period_id = value;
          OnPropertyChanged("EventPeriodId");
        }
      }
    }
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


    //#region INotifyPropertyChanged
    //public event PropertyChangedEventHandler PropertyChanged;
    //protected void OnPropertyChanged(string propertyName = "") {
    //  var changed = PropertyChanged;
    //  if(changed == null)
    //    return;

    //  changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}
    //#endregion
  }

  public class DNEventTicketItem : INotifyPropertyChanged {

    #region Properties
    public int _customer_number;
    public int CustomerNumber {
      get {
        return _customer_number;
      }
      set {
        if(_customer_number != value) {
          _customer_number = value;
          OnPropertyChanged("CustomerNumber");
        }
      }
    }
    public string _item_name;
    public string ItemName {
      get {
        return _item_name;
      }
      set {
        if(_item_name != value) {
          _item_name = value;
          OnPropertyChanged("ItemName");
        }
      }
    }
    public int _item_number;
    public int ItemNumber {
      get {
        return _item_number;
      }
      set {
        if(_item_number != value) {
          _item_number = value;
          OnPropertyChanged("ItemNumber");
        }
      }
    }

    public int _quantity;
    public int Quantity {
      get {
        return _quantity;
      }
      set {
        if(_quantity != value) {
          _quantity = value;
          OnPropertyChanged("Quantity");
        }
      }
    }
    public float _sales_price;
    public float SalesPrice {
      get {
        return _sales_price;
      }
      set {
        if(_sales_price != value) {
          _sales_price = value;
          OnPropertyChanged("SalesPrice");
        }
      }
    }

    public float _sales_price_with_discount;
    public float SalesPriceWithDiscount {
      get {
        return _sales_price_with_discount;
      }
      set {
        if(_sales_price_with_discount != value) {
          _sales_price_with_discount = value;
          OnPropertyChanged("SalesPriceWithDiscount");
        }
      }
    }

    public float _sales_price_without_vat;
    public float SalesPriceWithoutVat {
      get {
        return _sales_price_without_vat;
      }
      set {
        if(_sales_price_without_vat != value) {
          _sales_price_without_vat = value;
          OnPropertyChanged("SalesPriceWithoutVat");
        }
      }
    }

    public float _vat_amount;
    public float VatAmount {
      get {
        return _vat_amount;
      }
      set {
        if(_vat_amount != value) {
          _vat_amount = value;
          OnPropertyChanged("VatAmount");
        }
      }
    }
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



  public class DNCustomerTicket : INotifyPropertyChanged {
    public string _ticketImagePath;
    private DateTime _expieryDate;
    private string _itemName;
    private string _customerName;
    private DateTime _purchaseDate;
    private long _orderNumber;
    private long _serialNo;
    public string CustomerName {
      get {
        return _customerName;
      }
      set {
        if(_customerName != value) {
          _customerName = value;
          OnPropertyChanged("CustomerName");
        }
      }
    }
    public long CustomerNumber { get; set; }

    public string Flag { get; set; }
    public bool IsRenewal { get; set; }
    public bool IsSend { get; set; }
    public string ItemName {
      get {
        return _itemName;
      }
      set {
        if(_itemName != value) {
          _itemName = value;
          OnPropertyChanged("ItemName");
        }
      }
    }


    public long ItemNumber { get; set; }
    public int? MaxUseQuantity { get; set; }
    

    public long OrderNumber {
      get {
        return _orderNumber;
      }
      set {
        if(_orderNumber != value) {
          _orderNumber = value;
          OnPropertyChanged("OrderNumber");
        }
      }
    }

    public string PriceCategory { get; set; }
    public DateTime PurchaseDate {
      get {
        return _purchaseDate;
      }
      set {
        if(_purchaseDate != value) {
        _purchaseDate = value;
          OnPropertyChanged("PurchaseDate");
        }
      }
    }
    public long SerialNumber {
      get {
        return _serialNo;
      }
      set {
        if(_serialNo != value) {
          _serialNo = value;
          OnPropertyChanged("SerialNumber");
        }
      }
    }
    public long ShopNumber { get; set; }
    public double TotalAmount { get; set; }
    public long UserQuantity { get; set; }
    public bool Valid { get; set; }
    public string Status { get; set; }
    public DateTime ValidFrom { get; set; }

    public string TicketImagePath {
      get {
        return "l";
      }
    }
    public DateTime ExpieryDate {
      get {
        return _expieryDate;
      }
      set {
        if(_expieryDate != value) {
          _expieryDate = value;
          OnPropertyChanged("ExpieryDate");
        }
      }
    }

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

