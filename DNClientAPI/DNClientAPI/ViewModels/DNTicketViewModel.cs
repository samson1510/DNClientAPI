using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using DataNova.Common;
using DNClientAPI.Globalization;
using XRETAIL.Models;
using DNClientAPI.Models;

namespace XRETAIL.ViewModels {
  public class DNTicketViewModel:BaseViewModel {
    #region variables
    private string _sourcePath;
    private double _totalPrice;
    private double _totalQuantity;
    private int _rechargevalue1;
    private int _rechargevalue2;
    private int _rechargevalue3;
    private int _rechargevalue4;
    private int _rechargevalue5;
    private long _customerNumber;
    private int _rechargeid;
    private DNEvent _selectedevent;
    private DateTime _calenderselectedeventperiod;
    private DateTime _selectedeventperiod;
    private DateTime _selectedendeventperiod;
    private double _totalPriceEvent;
    private bool _eventperiodRequired;
    public bool isImageVisible { get; set; } = false;
    public bool isEventNameVisible { get; set; } = false;
    public bool isEventHeaderVisible { get; set; } = false;
    public bool isItemNameVisible { get; set; } = false;
    public bool isItemAmountVisible { get; set; } = false;
    public bool isQtyVisible { get; set; } = false;
    public bool isFromEventPeriod { get; set; } = false;
    public List<DNEventItem> selectedTicket = new List<DNEventItem>();
    #endregion
    public DNTicketViewModel() {
      this.isBusy = false;

      SliderImages = new ObservableCollection<DNTicketViewModel>();
      PurchaseTickets = new ObservableCollection<DNPurchaseTicket>();
      LinkedItems = new ObservableCollection<DNPurchaseTicketItem>();
      CustomerActiveEvents = new ObservableCollection<DNEvent>();
      CustomerPastEvents = new ObservableCollection<DNEvent>();
      CustomerActiveTickets = new ObservableCollection<DNCustomerTicket>();
      CustomerPastTickets = new ObservableCollection<DNCustomerTicket>();
      EventTickets = new ObservableCollection<DNCustomerTicket>();
      Events = new ObservableCollection<DNEvent>();
      EventGrouped = new ObservableCollection<DNEventGrouping<string,DNEvent>>();
      EventItems = new ObservableCollection<DNEventItem>();
      EventPeriods = new ObservableCollection<DNEventPeriod>();
      EventPeriodGrouped = new ObservableCollection<DNEventGrouping<DateTime,DNEventPeriod>>();
    }
    #region properties
    public ObservableCollection<DNTicketViewModel> SliderImages { get; set; }
    public ObservableCollection<DNPurchaseTicket> PurchaseTickets { get; set; }
    public ObservableCollection<DNPurchaseTicketItem> LinkedItems { get; set; }
    public ObservableCollection<DNEvent> CustomerActiveEvents { get; set; }
    public ObservableCollection<DNEvent> CustomerPastEvents { get; set; }
    public ObservableCollection<DNCustomerTicket> CustomerActiveTickets { get; set; }
    public ObservableCollection<DNCustomerTicket> CustomerPastTickets { get; set; }
    public ObservableCollection<DNCustomerTicket> EventTickets { get; set; }
    public ObservableCollection<DNEvent> Events { get; set; }
    public ObservableCollection<DNEventGrouping<string,DNEvent>> EventGrouped { get; set; }
    public ObservableCollection<DNEventItem> EventItems { get; set; }
    public ObservableCollection<DNEventPeriod> EventPeriods { get; set; }
    public ObservableCollection<DNEventGrouping<DateTime,DNEventPeriod>> EventPeriodGrouped { get; set; }
    public DNEvent SelectedEvent {
      get {
        return _selectedevent;
      }
      set {
        _selectedevent = value;
        OnPropertyChanged("SelectedEvent");
      }
    }
    public DateTime SelectedEventPeriod {
      get {
        return _selectedeventperiod;
      }
      set {
        _selectedeventperiod = value;
        OnPropertyChanged("SelectedEventPeriod");
      }
    }
    public DateTime SelectedEndEventPeriod {
      get {
        return _selectedendeventperiod;
      }
      set {
        _selectedendeventperiod = value;
        OnPropertyChanged("SelectedEndEventPeriod");
      }
    }
    public DateTime CalenderSelectedEventPeriod {
      get {
        return _calenderselectedeventperiod;
      }
      set {
        _calenderselectedeventperiod = value;
        OnPropertyChanged("CalenderSelectedEventPeriod");
      }
    }
    public bool EventPeriodRequired {
      get {
        return _eventperiodRequired;
      }
      set {
        _eventperiodRequired = value;
        OnPropertyChanged("EventPeriodRequired");
      }
    }
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
    public double TotalPrice {
      get {
        return LinkedItems.Sum(x => x.TotalPrice);
      }
      set {
        _totalPrice = value;
        OnPropertyChanged("TotalPrice");
      }
    }
    public double TotalQuantity {
      get {
        return LinkedItems.Sum(x => x.Quantity);
      }
      set {
        _totalQuantity = value;
        OnPropertyChanged("TotalQuantity");
      }
    }
    public double TotalPriceEvent {
      get {
        return EventItems.Sum(x => x.TotalPriceEvent);
      }
      set {
        _totalPriceEvent = value;
        OnPropertyChanged("TotalPriceEvent");
      }
    }
    public double TotalQuantityEvent {
      get {
        return EventItems.Sum(x => x.Quantity);
      }
      set {
        _totalQuantity = value;
        OnPropertyChanged("TotalQuantityEvent");
      }
    }
    public int RechargeId {
      get {
        return _rechargeid;
      }
      set {
        _rechargeid = value;
        OnPropertyChanged("RechargeId");
      }
    }
    public int RechargeValue1 {
      get {
        return _rechargevalue1;
      }
      set {
        _rechargevalue1 = value;
        OnPropertyChanged("RechargeValue1");
      }
    }
    public int RechargeValue2 {
      get {
        return _rechargevalue2;
      }
      set {
        _rechargevalue2 = value;
        OnPropertyChanged("RechargeValue2");
      }
    }
    public int RechargeValue3 {
      get {
        return _rechargevalue3;
      }
      set {
        _rechargevalue3 = value;
        OnPropertyChanged("RechargeValue3");
      }
    }
    public int RechargeValue4 {
      get {
        return _rechargevalue4;
      }
      set {
        _rechargevalue4 = value;
        OnPropertyChanged("RechargeValue4");
      }
    }
    public int RechargeValue5 {
      get {
        return _rechargevalue5;
      }
      set {
        _rechargevalue5 = value;
        OnPropertyChanged("RechargeValue5");
      }
    }
    public long CustomerNumber {
      get {
        return _customerNumber;
      }
      set {
        _customerNumber = value;
      }

    }  
    public List<DNTicketViewModel> TikcetDashboardDetails = new List<DNTicketViewModel>();
    #endregion
    public async Task LoadTicketDataAsync(int categoryid) {
      try {
        this.IsBusy = true;
        LinkedItems.Clear();
        TotalPrice = 0;
        TotalQuantity = 0;
        PurchaseTickets.Clear();
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/logicalgroups/?categoryId={0}&nclude_description = true",categoryid);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject PurchaseTicket in response) {
              var _purchaseTicket = new DNPurchaseTicket();
              foreach(JProperty purchaseTicketProperty in PurchaseTicket.Value<JToken>()) {
                switch(purchaseTicketProperty.Name) {
                  case "created_date":
                    _purchaseTicket.CreatedDate = purchaseTicketProperty.Value.ToLong();
                    break;
                  case "description":
                    _purchaseTicket.Description = purchaseTicketProperty.Value.ToSafeString();
                    break;
                  case "group_type":
                    _purchaseTicket.GroupType = Convert.ToInt32(purchaseTicketProperty.Value);
                    break;
                  case "id":
                    _purchaseTicket.Id = Convert.ToInt32(purchaseTicketProperty.Value);
                    break;
                  case "name":
                    _purchaseTicket.Name = purchaseTicketProperty.Value.ToSafeString();
                    break;
                  case "profile_number":
                    _purchaseTicket.ProfileNumber = purchaseTicketProperty.Value;
                    break;
                  case "sub_logical_groups":
                    _purchaseTicket.SubLogicalGroups = purchaseTicketProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "linked_items":
                    foreach(JObject linkedItem in purchaseTicketProperty.Value) {
                      var _linkedItem = new DNPurchaseTicketItem();
                      foreach(JProperty linkedItemListProperty in linkedItem.Value<JToken>()) {
                        switch(linkedItemListProperty.Name) {
                          case "id":
                            _linkedItem.LinkedItemId = linkedItemListProperty.Value.ToInt();
                            break;
                          case "name":
                            _linkedItem.LinkedItemName = linkedItemListProperty.Value.ToSafeString();
                            break;
                          case "salesprice":
                            _linkedItem.SalesPrice = linkedItemListProperty.Value.ToDouble();
                            break;
                          case "supplier_item_number":
                            _linkedItem.SupplierItemNumber = linkedItemListProperty.Value.ToSafeString();
                            break;
                        }
                      }
                      if(linkedItem.Count > 0) {
                        _purchaseTicket.Add(_linkedItem);
                      }
                    }
                    break;
                }
              }
              if(_purchaseTicket.Count > 0) {
                this.PurchaseTickets.Add(_purchaseTicket);
              }
            }
            foreach(var purchaseticket in this.PurchaseTickets) {
              foreach(var line in purchaseticket) {
                LinkedItems.Add(line);
              }
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
    }
    public async Task<bool> LoadActiveEventDetailsAsync() {
      if(this.Events.Count > 0) {
        return await Task.FromResult(false);
      }
      try {
        this.IsBusy = true;
        //this.Events.Clear();
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/bookings/?is_active={0}",1);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject eventResponse in response) {
              var _event = new DNEvent();
              foreach(JProperty eventProperty in eventResponse.Value<JToken>()) {
                switch(eventProperty.Name) {
                  case "advance_booking_days":
                    _event.AdvanceBookingDays = eventProperty.Value.ToInt();
                    break;
                  case "event_duration":
                    _event.Duration = eventProperty.Value.ToInt();
                    break;
                  case "_startDate":
                    _event.StartDate = eventProperty.Value.ToLong().ToDateTime();
                    break;
                  case "hall_number":
                    _event.HallNumber = eventProperty.Value.ToInt();
                    break;
                  case "reserved":
                    _event.Reserved = eventProperty.Value.ToBool();
                    break;
                  case "to_date":
                    _event.EndDate = eventProperty.Value.ToLong().ToDateTime();
                    break;
                  case "trip_type":
                    _event.TripType = eventProperty.Value.ToInt();
                    break;
                  case "event_id":
                    _event.EventId = eventProperty.Value.ToInt();
                    break;
                  case "event_period_id":
                    _event.PeriodId = eventProperty.Value.ToInt();
                    break;
                  case "event_name":
                    _event.EventName = eventProperty.Value.ToSafeString();
                    break;
                  case "event_description":
                    _event.Description = eventProperty.Value.ToSafeString();
                    break;
                  case "is_active":
                    _event.IsActive = eventProperty.Value.ToBool();
                    break;
                  case "location":
                    _event.Location = eventProperty.Value.ToSafeString();
                    break;
                  case "event_capacity":
                    _event.Capacity = eventProperty.Value.ToInt();
                    break;
                  case "event_type_id":
                    _event.EventTypeId = eventProperty.Value.ToInt();
                    break;
                  case "event_type_name":
                    _event.EventTypeName = eventProperty.Value.ToSafeString();
                    break;
                  case "language":
                    _event.Language = eventProperty.Value.ToSafeString();
                    break;
                  case "week_days":
                    _event.WeekDays = eventProperty.Value.ToSafeString();
                    break;
                  case "items":
                    foreach(JObject eventitem in eventProperty.Value) {
                      var _eventItem = new DNEventItem();
                      foreach(JProperty EventItemListProperty in eventitem.Value<JToken>()) {
                        switch(EventItemListProperty.Name) {
                          case "customer_number":
                            _eventItem.CustomerNumber = EventItemListProperty.Value.ToInt();
                            break;
                          case "item_name":
                            _eventItem.ItemName = EventItemListProperty.Value.ToSafeString();
                            break;
                          case "item_number":
                            _eventItem.ItemNumber = EventItemListProperty.Value.ToInt();
                            break;
                          case "quantity":
                            _eventItem.Quantity = EventItemListProperty.Value.ToInt();
                            break;
                          case "sales_price":
                            _eventItem.SalesPrice = EventItemListProperty.Value.ToFloat();
                            break;
                          case "sales_price_with_discount":
                            _eventItem.SalesPriceWithDiscount = EventItemListProperty.Value.ToFloat();
                            break;
                          case "sales_price_without_vat":
                            _eventItem.SalesPriceWithoutVat = EventItemListProperty.Value.ToFloat();
                            break;
                          case "vat_amount":
                            _eventItem.VatAmount = EventItemListProperty.Value.ToFloat();
                            break;

                        }
                      }
                    }
                    break;
                }
              }
              Events.Add(_event);
            }
            var groupbyHeader = Events.OrderBy(x => x.TypeId).GroupBy(s => s.EventTypeName).ToList();
            groupbyHeader.ForEach(item => { EventGrouped.Add(new DNEventGrouping<string,DNEvent>(item.Key.ToString(),Events.Where(x => x.EventTypeName == item.Key))); });
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public async Task<bool> LoadEventDetailAsync(DNEvent selectedEvent) {
      try {
        this.IsBusy = true;
        if(SelectedEventPeriod != DateTime.MinValue && selectedEvent.TypeId != 1 && !EventPeriodRequired) {
          EventPeriodRequired = true;
          return await Task.FromResult(true);
        }
        EventItems.Clear();
        EventPeriods.Clear();
        SelectedEventPeriod = DateTime.MinValue;
        EventPeriodRequired = false;
        TotalPriceEvent = 0;
        TotalQuantityEvent = 0;
        SelectedEvent = selectedEvent;
        string include = "";
        if(selectedEvent.TypeId == 1) include = "1";
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/bookings/{0}?include_periods={1}",selectedEvent.EventId,include);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(streamReader.ReadToEnd());
            foreach(JProperty eventProperty in response.Value<JToken>()) {
              switch(eventProperty.Name) {
                case "items":
                  foreach(JObject eventitem in eventProperty.Value) {
                    var _eventItem = new DNEventItem();
                    foreach(JProperty eventitemproperty in eventitem.Value<JToken>()) {
                      switch(eventitemproperty.Name) {
                        case "customer_number":
                          _eventItem.CustomerNumber = eventitemproperty.Value.ToInt();
                          break;
                        case "item_name":
                          _eventItem.ItemName = eventitemproperty.Value.ToSafeString();
                          break;
                        case "item_number":
                          _eventItem.ItemNumber = eventitemproperty.Value.ToInt();
                          break;
                        case "quantity":
                          //  _eventItem.Quantity = eventitemproperty.Value.ToInt();
                          break;
                        case "sales_price":
                          _eventItem.SalesPrice = eventitemproperty.Value.ToFloat();
                          break;
                        case "sales_price_with_discount":
                          _eventItem.SalesPriceWithDiscount = eventitemproperty.Value.ToFloat();
                          break;
                        case "sales_price_without_vat":
                          _eventItem.SalesPriceWithoutVat = eventitemproperty.Value.ToFloat();
                          break;
                        case "vat_amount":
                          _eventItem.VatAmount = eventitemproperty.Value.ToFloat();
                          break;
                      }
                    }
                    EventItems.Add(_eventItem);
                  }
                  break;
                case "periods":
                  foreach(JObject eventperiod in eventProperty.Value) {
                    var _eventPeriod = new DNEventPeriod();
                    foreach(JProperty eventperiodproperty in eventperiod.Value<JToken>()) {
                      switch(eventperiodproperty.Name) {
                        case "auditorium_number":
                          _eventPeriod.AuditoriumNumber = eventperiodproperty.Value.ToInt();
                          break;
                        case "reserved":
                          _eventPeriod.Reserved = eventperiodproperty.Value.ToBool();
                          break;
                        case "event_id":
                          _eventPeriod.EventId = eventperiodproperty.Value.ToInt();
                          break;
                        case "from_date":
                          _eventPeriod.FromDate = eventperiodproperty.Value.ToDateTime();
                          break;
                        case "to_date":
                          _eventPeriod.ToDate = eventperiodproperty.Value.ToDateTime();
                          break;
                        case "start_time":
                          _eventPeriod.StartTime = eventperiodproperty.Value.ToSafeString();
                          break;
                        case "end_time":
                          _eventPeriod.EndTime = eventperiodproperty.Value.ToSafeString();
                          break;
                        case "is_active":
                          _eventPeriod.IsActive = eventperiodproperty.Value.ToBool();
                          break;
                        case "trip_capacity":
                          _eventPeriod.TripCapacity = eventperiodproperty.Value.ToInt();
                          break;
                        case "trip_booked":
                          _eventPeriod.TripBooked = eventperiodproperty.Value.ToInt();
                          break;
                        case "trip_id":
                          _eventPeriod.TripId = eventperiodproperty.Value.ToInt();
                          break;
                        case "event_period_id":
                          _eventPeriod.EventPeriodId = eventperiodproperty.Value.ToInt();
                          break;

                      }
                    }
                    EventPeriods.Add(_eventPeriod);
                    if(EventPeriods.Count > 0) {
                      SelectedEventPeriod = EventPeriods[0].FromDate;
                      EventPeriodRequired = true;
                    }
                  }
                  break;
              }
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public async Task<bool> LoadEventDateDetailAsync(DNEvent selectedEvent) {
      try {
        this.IsBusy = true;
        SelectedEvent = selectedEvent;
        EventPeriods.Clear();
        EventPeriodGrouped.Clear();
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/bookings/period/{0}/?is_active={1}&page={2}&page_size={3}",selectedEvent.EventId,1,1,10);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject eventResponse in response) {
              var _eventPeriod = new DNEventPeriod();
              foreach(JProperty eventperiodproperty in eventResponse.Value<JToken>()) {
                switch(eventperiodproperty.Name) {
                  case "auditorium_number":
                    _eventPeriod.AuditoriumNumber = eventperiodproperty.Value.ToInt();
                    break;
                  case "reserved":
                    _eventPeriod.Reserved = eventperiodproperty.Value.ToBool();
                    break;
                  case "event_id":
                    _eventPeriod.EventId = eventperiodproperty.Value.ToInt();
                    break;
                  case "from_date":
                    _eventPeriod.FromDate = eventperiodproperty.Value.ToDateTime();
                    break;
                  case "to_date":
                    _eventPeriod.ToDate = eventperiodproperty.Value.ToDateTime();
                    break;
                  case "start_time":
                    _eventPeriod.StartTime = eventperiodproperty.Value.ToSafeString();
                    break;
                  case "end_time":
                    _eventPeriod.EndTime = eventperiodproperty.Value.ToSafeString();
                    break;
                  case "is_active":
                    _eventPeriod.IsActive = eventperiodproperty.Value.ToBool();
                    break;
                  case "trip_capacity":
                    _eventPeriod.TripCapacity = eventperiodproperty.Value.ToInt();
                    break;
                  case "trip_booked":
                    _eventPeriod.TripBooked = eventperiodproperty.Value.ToInt();
                    break;
                  case "trip_id":
                    _eventPeriod.TripId = eventperiodproperty.Value.ToInt();
                    break;
                  case "event_period_id":
                    _eventPeriod.EventPeriodId = eventperiodproperty.Value.ToInt();
                    break;
                }
              }
              EventPeriods.Add(_eventPeriod);
            }
            var groupbyHeader = EventPeriods.OrderBy(x => x.FromDate).GroupBy(s => s.FromDate).ToList();
            groupbyHeader.ForEach(item => { EventPeriodGrouped.Add(new DNEventGrouping<DateTime,DNEventPeriod>(item.Key,EventPeriods.Where(x => x.FromDate == item.Key))); });
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public async Task<bool> LoadRechargeBalanceAmountsAsync() {
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/recharge/");
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JArray;
            int rechrg_id = 0;
            foreach(var loggedinuserobj in response) {
              foreach(JProperty _jproperty in loggedinuserobj.Value<JToken>()) {
                switch(_jproperty.Name) {
                  case "recharge_id":
                    rechrg_id = _jproperty.Value.ToInt();
                    RechargeId = rechrg_id;
                    break;
                  case "recharge_value":
                    var date = _jproperty.Value;
                    switch(rechrg_id) {
                      case 1:
                        RechargeValue1 = Convert.ToInt32(date);
                        break;
                      case 2:
                        RechargeValue2 = Convert.ToInt32(date);
                        break;
                      case 3:
                        RechargeValue3 = Convert.ToInt32(date);
                        break;
                      case 4:
                        RechargeValue4 = Convert.ToInt32(date);
                        break;
                      case 5:
                        RechargeValue5 = Convert.ToInt32(date);
                        break;
                    }
                    break;
                }
              }
            }
          }
        }
      } catch(Exception ex) {
        Console.WriteLine(ex);
      } finally {
        this.IsBusy = false;
      }
      return await base.LoadAsync();
    }

    public async Task<bool> LoadCustomerActiveEventsAsync() {
      if(this.CustomerActiveEvents.Count > 0) {
        return await Task.FromResult(false);
      }
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/bookings/bookinghistory?customer_number={0}& search_filter=upcoming",CustomerNumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject eventResponse in response) {
              var _event = new DNEvent();
              foreach(JProperty eventProperty in eventResponse.Value<JToken>()) {
                switch(eventProperty.Name) {
                  case "advance_booking_days":
                    _event.AdvanceBookingDays = eventProperty.Value.ToInt();
                    break;
                  case "event_duration":
                    _event.Duration = eventProperty.Value.ToInt();
                    break;
                  case "_startDate":
                    _event.StartDate = eventProperty.Value.ToLong().ToDateTime();
                    break;
                  case "hall_number":
                    _event.HallNumber = eventProperty.Value.ToInt();
                    break;
                  case "reserved":
                    _event.Reserved = eventProperty.Value.ToBool();
                    break;
                  case "to_date":
                    _event.EndDate = eventProperty.Value.ToLong().ToDateTime();
                    break;
                  case "trip_type":
                    _event.TripType = eventProperty.Value.ToInt();
                    break;
                  case "event_id":
                    _event.EventId = eventProperty.Value.ToInt();
                    break;
                  case "event_period_id":
                    _event.PeriodId = eventProperty.Value.ToInt();
                    break;
                  case "event_name":
                    _event.EventName = eventProperty.Value.ToSafeString();
                    break;
                  case "event_description":
                    _event.Description = eventProperty.Value.ToSafeString();
                    break;
                  case "is_active":
                    _event.IsActive = eventProperty.Value.ToBool();
                    break;
                  case "location":
                    _event.Location = eventProperty.Value.ToSafeString();
                    break;
                  case "event_capacity":
                    _event.Capacity = eventProperty.Value.ToInt();
                    break;
                  case "language":
                    _event.Language = eventProperty.Value.ToSafeString();
                    break;
                  case "week_days":
                    _event.WeekDays = eventProperty.Value.ToSafeString();
                    break;
                  case "from_date":
                    _event.StartDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "items":
                    foreach(JObject eventitem in eventProperty.Value) {
                      var _eventItem = new DNEventItem();
                      foreach(JProperty EventItemListProperty in eventitem.Value<JToken>()) {
                        switch(EventItemListProperty.Name) {
                          case "customer_number":
                            _eventItem.CustomerNumber = EventItemListProperty.Value.ToInt();
                            break;
                          case "item_name":
                            _eventItem.ItemName = EventItemListProperty.Value.ToSafeString();
                            break;
                          case "item_number":
                            _eventItem.ItemNumber = EventItemListProperty.Value.ToInt();
                            break;
                          case "quantity":
                            _eventItem.Quantity = EventItemListProperty.Value.ToInt();
                            break;
                          case "sales_price":
                            _eventItem.SalesPrice = EventItemListProperty.Value.ToFloat();
                            break;
                          case "sales_price_with_discount":
                            _eventItem.SalesPriceWithDiscount = EventItemListProperty.Value.ToFloat();
                            break;
                          case "sales_price_without_vat":
                            _eventItem.SalesPriceWithoutVat = EventItemListProperty.Value.ToFloat();
                            break;
                          case "vat_amount":
                            _eventItem.VatAmount = EventItemListProperty.Value.ToFloat();
                            break;
                        }
                      }
                    }
                    break;
                }
              }
              CustomerActiveEvents.Add(_event);
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public async Task<bool> LoadCustomerPastEventsAsync() {
      if(this.CustomerPastEvents.Count > 0) {
        return await Task.FromResult(false);
      }
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/bookings/bookinghistory?customer_number={0}& search_filter=previous",CustomerNumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject eventResponse in response) {
              var _event = new DNEvent();
              foreach(JProperty eventProperty in eventResponse.Value<JToken>()) {
                switch(eventProperty.Name) {
                  case "advance_booking_days":
                    _event.AdvanceBookingDays = eventProperty.Value.ToInt();
                    break;
                  case "event_duration":
                    _event.Duration = eventProperty.Value.ToInt();
                    break;
                  case "_startDate":
                    _event.StartDate = eventProperty.Value.ToLong().ToDateTime();
                    break;
                  case "hall_number":
                    _event.HallNumber = eventProperty.Value.ToInt();
                    break;
                  case "reserved":
                    _event.Reserved = eventProperty.Value.ToBool();
                    break;
                  case "to_date":
                    _event.EndDate = eventProperty.Value.ToLong().ToDateTime();
                    break;
                  case "trip_type":
                    _event.TripType = eventProperty.Value.ToInt();
                    break;
                  case "event_id":
                    _event.EventId = eventProperty.Value.ToInt();
                    break;
                  case "event_period_id":
                    _event.PeriodId = eventProperty.Value.ToInt();
                    break;
                  case "event_name":
                    _event.EventName = eventProperty.Value.ToSafeString();
                    break;
                  case "event_description":
                    _event.Description = eventProperty.Value.ToSafeString();
                    break;
                  case "is_active":
                    _event.IsActive = eventProperty.Value.ToBool();
                    break;
                  case "location":
                    _event.Location = eventProperty.Value.ToSafeString();
                    break;
                  case "event_capacity":
                    _event.Capacity = eventProperty.Value.ToInt();
                    break;
                  case "language":
                    _event.Language = eventProperty.Value.ToSafeString();
                    break;
                  case "week_days":
                    _event.WeekDays = eventProperty.Value.ToSafeString();
                    break;
                  case "from_date":
                    _event.StartDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "items":
                    foreach(JObject eventitem in eventProperty.Value) {
                      var _eventItem = new DNEventItem();
                      foreach(JProperty EventItemListProperty in eventitem.Value<JToken>()) {
                        switch(EventItemListProperty.Name) {
                          case "customer_number":
                            _eventItem.CustomerNumber = EventItemListProperty.Value.ToInt();
                            break;
                          case "item_name":
                            _eventItem.ItemName = EventItemListProperty.Value.ToSafeString();
                            break;
                          case "item_number":
                            _eventItem.ItemNumber = EventItemListProperty.Value.ToInt();
                            break;
                          case "quantity":
                            _eventItem.Quantity = EventItemListProperty.Value.ToInt();
                            break;
                          case "sales_price":
                            _eventItem.SalesPrice = EventItemListProperty.Value.ToFloat();
                            break;
                          case "sales_price_with_discount":
                            _eventItem.SalesPriceWithDiscount = EventItemListProperty.Value.ToFloat();
                            break;
                          case "sales_price_without_vat":
                            _eventItem.SalesPriceWithoutVat = EventItemListProperty.Value.ToFloat();
                            break;
                          case "vat_amount":
                            _eventItem.VatAmount = EventItemListProperty.Value.ToFloat();
                            break;
                        }
                      }
                    }
                    break;
                }
              }
              CustomerPastEvents.Add(_event);
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public async Task<bool> LoadCustomerActiveTicketsAsync() {
      if(this.CustomerActiveTickets.Count > 0) {
        return await Task.FromResult(false);
      }
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/tickets/?customer_number={0}& search_filter=upcoming",CustomerNumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject eventResponse in response) {
              var _ticket = new DNCustomerTicket();
              foreach(JProperty eventProperty in eventResponse.Value<JToken>()) {
                switch(eventProperty.Name) {
                  case "customer_name":
                    _ticket.CustomerName = eventProperty.Value.ToSafeString();
                    break;
                  case "customer_number":
                    _ticket.CustomerNumber = eventProperty.Value.ToLong();
                    break;
                  case "expiry_date":
                    _ticket.ExpieryDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "flag":
                    _ticket.Flag = eventProperty.Value.ToSafeString();
                    break;
                  case "is_renewal":
                    _ticket.IsRenewal = eventProperty.Value.ToBool();
                    break;
                  case "is_send":
                    _ticket.IsSend = eventProperty.Value.ToBool();
                    break;
                  case "item_name":
                    _ticket.ItemName = eventProperty.Value.ToSafeString();
                    break;
                  case "item_number":
                    _ticket.ItemNumber = eventProperty.Value.ToLong();
                    break;
                  case "max_use_qty":
                    _ticket.MaxUseQuantity = eventProperty.Value.ToInt();
                    break;
                  case "order_number":
                    _ticket.OrderNumber = eventProperty.Value.ToLong();
                    break;
                  case "price_category":
                    _ticket.PriceCategory = eventProperty.Value.ToSafeString();
                    break;
                  case "purchase_date":
                    _ticket.PurchaseDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "serial_number":
                    _ticket.SerialNumber = eventProperty.Value.ToLong();
                    break;
                  case "shop_number":
                    _ticket.ShopNumber = eventProperty.Value.ToLong();
                    break;
                  case "status":
                    _ticket.Status = eventProperty.Value.ToSafeString();
                    break;
                  case "total_amount":
                    _ticket.TotalAmount = eventProperty.Value.ToDouble();
                    break;
                  case "use_qty":
                    _ticket.UserQuantity = eventProperty.Value.ToLong();
                    break;
                  case "valid":
                    _ticket.Valid = eventProperty.Value.ToBool();
                    break;
                  case "valid_from":
                    _ticket.ValidFrom = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                }
              }
              CustomerActiveTickets.Add(_ticket);
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public async Task<bool> LoadCustomerPastTicketsAsync() {
      if(this.CustomerPastTickets.Count > 0) {
        return await Task.FromResult(false);
      }
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/tickets/?customer_number={0}& search_filter=previous",CustomerNumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject eventResponse in response) {
              var _ticket = new DNCustomerTicket();
              foreach(JProperty eventProperty in eventResponse.Value<JToken>()) {
                switch(eventProperty.Name) {
                  case "customer_name":
                    _ticket.CustomerName = eventProperty.Value.ToSafeString();
                    break;
                  case "customer_number":
                    _ticket.CustomerNumber = eventProperty.Value.ToLong();
                    break;
                  case "expiry_date":
                    _ticket.ExpieryDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "flag":
                    _ticket.Flag = eventProperty.Value.ToSafeString();
                    break;
                  case "is_renewal":
                    _ticket.IsRenewal = eventProperty.Value.ToBool();
                    break;
                  case "is_send":
                    _ticket.IsSend = eventProperty.Value.ToBool();
                    break;
                  case "item_name":
                    _ticket.ItemName = eventProperty.Value.ToSafeString();
                    break;
                  case "item_number":
                    _ticket.ItemNumber = eventProperty.Value.ToLong();
                    break;
                  case "max_use_qty":
                    _ticket.MaxUseQuantity = eventProperty.Value.ToInt();
                    break;
                  case "order_number":
                    _ticket.OrderNumber = eventProperty.Value.ToLong();
                    break;
                  case "price_category":
                    _ticket.PriceCategory = eventProperty.Value.ToSafeString();
                    break;
                  case "purchase_date":
                    _ticket.PurchaseDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "serial_number":
                    _ticket.SerialNumber = eventProperty.Value.ToLong();
                    break;
                  case "shop_number":
                    _ticket.ShopNumber = eventProperty.Value.ToLong();
                    break;
                  case "status":
                    _ticket.Status = eventProperty.Value.ToSafeString();
                    break;
                  case "total_amount":
                    _ticket.TotalAmount = eventProperty.Value.ToDouble();
                    break;
                  case "use_qty":
                    _ticket.UserQuantity = eventProperty.Value.ToLong();
                    break;
                  case "valid":
                    _ticket.Valid = eventProperty.Value.ToBool();
                    break;
                  case "valid_from":
                    _ticket.ValidFrom = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                }
              }
              CustomerPastTickets.Add(_ticket);
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public async Task<bool> LoadEventTicketsAsync(DNEvent _event) {
      try {
        this.IsBusy = true;
        EventTickets.Clear();
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/bookings/bookinghistory/tickets?customer_number={0}&event_id={1}&event_period_id={2}",CustomerNumber,_event.EventId,_event.PeriodId);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject eventResponse in response) {
              var _ticket = new DNCustomerTicket();
              foreach(JProperty eventProperty in eventResponse.Value<JToken>()) {
                switch(eventProperty.Name) {
                  case "customer_name":
                    _ticket.CustomerName = eventProperty.Value.ToSafeString();
                    break;
                  case "customer_number":
                    _ticket.CustomerNumber = eventProperty.Value.ToLong();
                    break;
                  case "expiry_date":
                    _ticket.ExpieryDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "flag":
                    _ticket.Flag = eventProperty.Value.ToSafeString();
                    break;
                  case "is_renewal":
                    _ticket.IsRenewal = eventProperty.Value.ToBool();
                    break;
                  case "is_send":
                    _ticket.IsSend = eventProperty.Value.ToBool();
                    break;
                  case "item_name":
                    _ticket.ItemName = eventProperty.Value.ToSafeString();
                    break;
                  case "item_number":
                    _ticket.ItemNumber = eventProperty.Value.ToLong();
                    break;
                  case "max_use_qty":
                    _ticket.MaxUseQuantity = eventProperty.Value.ToInt();
                    break;
                  case "order_number":
                    _ticket.OrderNumber = eventProperty.Value.ToLong();
                    break;
                  case "price_category":
                    _ticket.PriceCategory = eventProperty.Value.ToSafeString();
                    break;
                  case "purchase_date":
                    _ticket.PurchaseDate = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                  case "serial_number":
                    _ticket.SerialNumber = eventProperty.Value.ToLong();
                    break;
                  case "shop_number":
                    _ticket.ShopNumber = eventProperty.Value.ToLong();
                    break;
                  case "status":
                    _ticket.Status = eventProperty.Value.ToSafeString();
                    break;
                  case "total_amount":
                    _ticket.TotalAmount = eventProperty.Value.ToDouble();
                    break;
                  case "use_qty":
                    _ticket.UserQuantity = eventProperty.Value.ToLong();
                    break;
                  case "valid":
                    _ticket.Valid = eventProperty.Value.ToBool();
                    break;
                  case "valid_from":
                    _ticket.ValidFrom = eventProperty.Value.ToLong().ToLocalDateTime();
                    break;
                }
              }
              EventTickets.Add(_ticket);
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(true);
    }
    public bool DoesImageExistRemotely(string uriToImage) {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriToImage);

      request.Method = "HEAD";

      try {
        using(HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {

          if(response.StatusCode == HttpStatusCode.OK) {
            return true;
          } else {
            return false;
          }
        }
      } catch(WebException) { return false; } catch {
        return false;
      }
    }
  }
}







