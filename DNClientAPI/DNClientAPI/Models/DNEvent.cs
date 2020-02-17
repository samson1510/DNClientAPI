using DataNova.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace DNClientAPI.Models {

  public class DNEvent:BaseModel {
    private long _startdatelong;
    private long _enddatelong;
    private long _salestartdatelong;
    private long _saleenddatelong;
    private int _eventid;

    public DNEvent() {
      IsAllowForApp = true;
      IsAllowForST = true;
      IsAllowForWebShop = true;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("eventid")]
    public int EventId {
      get {
        return _eventid;
      }
      set {
        if(_eventid != value) {
          LargeImagePath = "bookingimages/" + value + ".jpg";
          SmallImagePath = "bookingimages/" + value + "_1.jpg";
          _eventid = value;
        }
      }
    }
    private string _largeImagePath;
    public string LargeImagePath {
      get { return _largeImagePath; }
      set {
        if(_largeImagePath != value) {
          _largeImagePath = value;
          OnPropertyChanged("LargeImagePath");
        }
      }
    }
    private string _smallImagePath;
    public string SmallImagePath {
      get { return _smallImagePath; }
      set {
        if(_smallImagePath != value) {
          _smallImagePath = value;
          OnPropertyChanged("LargeImagePath");
        }
      }
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("eventname")]
    public string EventName {
      get; set;
    }
    [JsonProperty("event_type")]
    public int? EventType {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("description")]
    public string Description {
      get; set;
    }
    //added for grouping of events
    public int EventTypeId {
      get; set;
    }
    //added for grouping of events name
    public string EventTypeName {
      get; set;
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("spaceid")]
    public long PhysicalSpaceId {
      get; set;
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("spacename")]
    public string PhysicalSpaceName {
      get; set;
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("shopno")]
    public long ShopNo {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("shopname")]
    public string ShopName {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("spaceno")]
    public int SpaceNo {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("entityname")]
    public string EntityName {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("instanceid")]
    public int Instanceid {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("startdate")]
    public long StartdateLong {
      get {
        return _startdatelong;
      }
      set {
        if(_startdatelong != value) {
          _startdatelong = value;
          StartDate = _startdatelong.ToLocalDateTime();
        }
      }
    }
    [JsonProperty("_startdate")]
    public DateTime? StartDate {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("enddate")]
    public long EnddateLong {
      get {
        return _enddatelong;
      }
      set {
        if(_enddatelong != value) {
          _enddatelong = value;
          EndDate = _enddatelong.ToLocalDateTime();
        }
      }
    }
    [JsonProperty("_enddate")]
    public DateTime? EndDate {
      get; set;
    }
    [JsonProperty("salestartdate")]
    public long SaleStartDateLong {
      get {
        return _salestartdatelong;
      }
      set {
        if(_salestartdatelong != value) {
          _salestartdatelong = value;
          SaleStartDate = _salestartdatelong.ToLocalDateTime();
        }
      }
    }
    public DateTime? SaleStartDate {
      get; set;
    }
    [JsonProperty("saleenddate")]
    public long SaleEndDateLong {
      get {
        return _saleenddatelong;
      }
      set {
        if(_saleenddatelong != value) {
          _saleenddatelong = value;
          SaleEndDate = _saleenddatelong.ToLocalDateTime();
        }
      }
    }
    public DateTime? SaleEndDate {
      get; set;
    }
    [JsonProperty("startTime")]
    public string StartTime { get; set; }
    [JsonProperty("endTime")]
    public string EndTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("hall")]
    public bool Hall {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("language")]
    public string Language {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("weekdays")]
    public string WeekDays {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("tourid")]
    public string TourId {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("tourperiodid")]
    public int TourPeriodId {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("guide")]
    public int Guide {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("staff")]
    public string Staff {
      get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("isactive")]
    public bool IsActive {
      get; set;
    }
    [JsonProperty("isallowforst")]
    public bool IsAllowForST {
      get; set;
    }
    [JsonProperty("isallowforwebshop")]
    public bool IsAllowForWebShop {
      get; set;
    }
    [JsonProperty("isallowforapp")]
    public bool IsAllowForApp {
      get; set;
    }
    [JsonProperty("isAllowForCustInfo")]
    public bool IsAllowForCustInfo {
      get; set;
    }
    [JsonProperty("tickets")]
    public List<DNEventBookingItem> Tickets {
      get; set;
    }
    [JsonProperty("alternateticketitems")]
    public List<DNItem> AlternateItems {
      get; set;
    }
    public string LargeImage { get; set; }
    public string SmallImage { get; set; }
    [JsonProperty("ticketTemplateId")]
    public long TicketTemplateId {
      get; set;
    }
    [JsonProperty("capacity")]
    public long Capacity {
      get; set;
    }
    public int AdvanceBookingDays {
      get; set;
    }
    public int Duration {
      get; set;
    }
    public int HallNumber {
      get; set;
    }
    public bool Reserved {
      get; set;
    }
    public int TripType {
      get; set;
    }
    [JsonProperty("period_id")]
    public int PeriodId {
      get; set;
    }
    public string Location {
      get; set;
    }
    public int TypeId {
      get; set;
    }
    public string ErrorSmallImagePath {
      get {
        string path = "";
        switch(this.EventType) {
          case 1:
            path = "webshop/event_small.jpg";
            break;
          case 2:
            path = "webshop/ticket_small.jpg";
            break;
          case 3:
            path = "webshop/seasoncard_small.jpg";
            break;
          case 4:
            path = "webshop/ticket_small.jpg";
            break;
        }
        return path;
      }
    }
    public string ErrorLargeImagePath {
      get {
        string path = "";
        switch(this.EventType) {
          case 1:
            path = "webshop/event_large.jpg";
            break;
          case 2:
            path = "webshop/ticket_large.jpg";
            break;
          case 3:
            path = "webshop/seasoncard_large.jpg";
            break;
          case 4:
            path = "webshop/ticket_large.jpg";
            break;
        }
        return path;
      }
    }
    private bool _isSellingFast;
    [JsonProperty("IsSellingFast")]
    public bool IsSellingFast {
      get { return _isSellingFast; }
      set {
        if(_isSellingFast != value) {
          _isSellingFast = value;
          OnPropertyChanged("IsSellingFast");
        }
      }
    }

    private int _ticketsLeft;
    [JsonProperty("TicketsLeft")]
    public int TicketsLeft {
      get { return _ticketsLeft; }
      set {
        if(_ticketsLeft != value) {
          _ticketsLeft = value;
          OnPropertyChanged("TicketsLeft");
        }
      }
    }
    public bool HasStatus {
      get { return IsSellingFast || TicketsLeft < 5; }
    }
    [JsonProperty("specialprograms")]
    public string SpecialPrograms {
      get; set;
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("keyhighlights")]
    public string KeyHighlights {
      get; set;
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("shopaddress")]
    public DNAddress ShopAddress {
      get; set;
    }
    public DateTime SelectedDate {
      get; set;
    }
    public long SelectedDateLong { get; set; }
    public int Currentweakno { get; set; }
    public int Sourceweakno { get; set; }

    [JsonProperty("instances")]
    public List<DNInstance> Instances { get; set; }

    [JsonProperty("total_records")]
    public int TotalRecords {
      get; set;
    }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords {
      get; set;
    }

  }
  public class Event {
    [JsonProperty("id")]
    public int EventId { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    public string Description { get; set; }
    [JsonProperty("start")]
    public DateTime Start { get; set; }
    [JsonProperty("end")]
    public DateTime End { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [JsonProperty("startTime")]
    public TimeSpan StartTime { get; set; }
    [JsonProperty("endTime")]
    public TimeSpan EndTime { get; set; }
    public string UserType { get; set; }
    [JsonProperty("allDay")]
    public bool AllDay { get; set; }

    [JsonProperty("ShopName")]
    public string ShopName { get; set; }

    [JsonProperty("shopaddress")]
    public DNAddress ShopAddress {
      get; set;
    }
    public string imagepathSmall { get; set; }
    public string imagepathlarge { get; set; }

    [JsonProperty("total_records")]
    public int TotalRecords {
      get; set;
    }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords {
      get; set;
    }
  }
  public class DNEventType {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class DNInstance {

    private DateTime _StartDate;
    private DateTime _EndDate;
    private string _StartTimeString;
    private string _EndTimeString;
    private long _salestartdatelong;
    private long _saleenddatelong;

    private long _startdatelong;
    private long _enddatelong;

    [JsonProperty("eventid")]
    public int EventId { get; set; }
    /// <summary>
    /// Instance id
    /// </summary>
    [JsonProperty("id")]
    public int Instanceid {
      get; set;
    }
    /// <summary>
    /// Start date
    /// </summary>
    [JsonProperty("startdate")]
    public DateTime StartDate {
      get {
        return _StartDate;
      }
      set {
        if(_StartDate != value) {
          _StartDate = value;
          StartDateString = _StartDate.ToString("dd.MM.yyyy");
        }
      }
    }
    [JsonProperty("startDateString")]
    public string StartDateString {
      get; set;
    }
    /// <summary>
    /// Enddate
    /// </summary>
    [JsonProperty("enddate")]
    public DateTime EndDate {
      get { return _EndDate; }
      set {
        if(_EndDate != value) {
          _EndDate = value;
          EndDateString = _EndDate.ToString("dd.MM.yyyy");
        }
      }
    }

    [JsonProperty("start_date")]
    public Int64 StartdateLong {
      get {
        return _startdatelong;
      }
      set {
        if(_startdatelong != value) {
          _startdatelong = value;
          StartDate = _startdatelong.ToLocalDateTime();
        }
      }
    }

    [JsonProperty("end_date")]
    public Int64 EnddateLong {
      get {
        return _enddatelong;
      }
      set {
        if(_enddatelong != value) {
          _enddatelong = value;
          EndDate = _enddatelong.ToLocalDateTime();
        }
      }
    }


    [JsonProperty("endDateString")]
    public string EndDateString {
      get; set;
    }
    /// <summary>
    /// Hall
    /// </summary>
    [JsonProperty("hall")]
    public bool Hall {
      get; set;
    }
    /// <summary>
    /// Language
    /// </summary>
    [JsonProperty("language")]
    public string Language {
      get; set;
    }
    /// <summary>
    /// Weekdays
    /// </summary>
    [JsonProperty("weekdays")]
    public string Weekdays {
      get; set;
    }
    /// <summary>
    /// Isactive
    /// </summary>
    [JsonProperty("is_active")]
    public bool Isactive {
      get; set;
    }
    /// <summary>
    /// IsAllowForST
    /// </summary>
    [JsonProperty("is_allowed_for_st")]
    public bool IsAllowForST {
      get; set;
    }
    /// <summary>
    /// IsAllowForWebShop
    /// </summary>
    [JsonProperty("is_allowed_for_webshop")]
    public bool IsAllowForWebShop {
      get; set;
    }
    /// <summary>
    /// IsAllowForApp
    /// </summary>
    [JsonProperty("is_allowed_for_app")]
    public bool IsAllowForApp {
      get; set;
    }
    /// <summary>
    /// IsAllowForCustInfo
    /// </summary>
    [JsonProperty("is_allowed_for_cust_info")]
    public bool IsAllowForCustInfo {
      get; set;
    }
    /// <summary>
    /// TicketTemplateId
    /// </summary>
    [JsonProperty("ticket_template_id")]
    public long TicketTemplateId {
      get; set;
    }
    /// <summary>
    /// Capacity
    /// </summary>
    [JsonProperty("capacity")]
    public long Capacity {
      get; set;
    }

    public DateTime? SaleStartDate {
      get; set;
    }
    public DateTime? SaleEndDate {
      get; set;
    }

    [JsonProperty("sale_start_date")]
    public long SaleStartDateLong {
      get {
        return _salestartdatelong;
      }
      set {
        if(_salestartdatelong != value) {
          _salestartdatelong = value;
          SaleStartDate = _salestartdatelong.ToLocalDateTime();
        }
      }
    }

    [JsonProperty("sale_end_date")]
    public long SaleEndDateLong {
      get {
        return _saleenddatelong;
      }
      set {
        if(_saleenddatelong != value) {
          _saleenddatelong = value;
          SaleEndDate = _saleenddatelong.ToLocalDateTime();
        }
      }
    }

    /// <summary>
    /// ShopNo
    /// </summary>
    [JsonProperty("shop_number")]
    public long ShopNo {
      get; set;
    }

    /// <summary>
    /// Terminal Number
    /// </summary>
    [JsonProperty("terminal_number")]
    public long TerminalNo {
      get; set;
    }

    /// <summary>
    /// ShopName
    /// </summary>
    [JsonProperty("shop_name")]
    public string ShopName {
      get; set;
    }
    /// <summary>
    /// LastUpadedDate
    /// </summary>
    [JsonProperty("last_modified_date")]
    public long? LastUpadedDate {
      get; set;
    }
    /// <summary>
    /// LastUpadedUserNumber
    /// </summary>
    [JsonProperty("last_modified_user")]
    public int? LastUpadedUserNumber {
      get; set;
    }
    /// <summary>
    /// PeriodsList
    /// </summary>
    [JsonProperty("periods")]
    public List<DNPeriods> PeriodsList {
      get; set;
    }
    /// <summary>
    /// Shop Address
    /// </summary>
    [JsonProperty("shopaddress")]
    public DNAddress ShopAddress {
      get; set;
    }

    [JsonProperty("isactive")]
    public bool IsActive {
      get; set;
    }
    //[DisplayName("Starttime")]

    public TimeSpan StartTime { get; set; }

    //[DisplayName("Endtime")]
    public TimeSpan EndTime { get; set; }
    [JsonProperty("start_time")]
    public string StartTimeString {
      get {
        return _StartTimeString;
      }
      set {
        if(_StartTimeString != value) {
          _StartTimeString = value;
          if(_StartTimeString != "") {
            var hours = Int32.Parse(_StartTimeString.Replace(":",".").Split('.')[0]);
            var minutes = Int32.Parse(_StartTimeString.Replace(":",".").Split('.')[1]);
            var ts = new TimeSpan(hours,minutes,0);
            StartTime = ts;
          }
        }
      }
    }
    [JsonProperty("end_time")]
    public string EndTimeString {
      get {
        return _EndTimeString;
      }
      set {
        if(_EndTimeString != value) {
          _EndTimeString = value;
          if(_EndTimeString != "") {
            var hours = Int32.Parse(_EndTimeString.Replace(":",".").Split('.')[0]);
            var minutes = Int32.Parse(_EndTimeString.Replace(":",".").Split('.')[1]);
            var ts = new TimeSpan(hours,minutes,0);
            EndTime = ts;
          }
        }
      }
    }

    [JsonProperty("period_id")]
    public int PeriodId {
      get; set;
    }

    //[JsonProperty("instanceid")]
    //public int InstanceDelId {
    //  get; set;
    //}

    [JsonProperty("total_records")]
    public int TotalRecords {
      get; set;
    }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords {
      get; set;
    }

  }
  public class DNPeriods {
    private string _StartTimeString;
    private string _EndTimeString;

    /// <summary>
    /// Period id
    /// </summary>
    [JsonProperty("id")]
    public int PeriodId {
      get; set;
    }
    /// <summary>
    /// Start Time
    /// </summary>
    [JsonProperty("start_time")]
    public string StartTimeString {
      get {
        return _StartTimeString;
      }
      set {
        if(_StartTimeString != value) {
          _StartTimeString = value;
          StartTime = TimeSpan.Parse(_StartTimeString);
        }
      }
    }

    [JsonProperty("starttime")]
    public TimeSpan StartTime {
      get; set;
    }
    /// <summary>
    /// End Time
    /// </summary>
    [JsonProperty("end_time")]
    public string EndTimeString {
      get {
        return _EndTimeString;
      }
      set {
        if(_EndTimeString != value) {
          _EndTimeString = value;
          EndTime = TimeSpan.Parse(_EndTimeString);
        }
      }
    }

    [JsonProperty("endtime")]
    public TimeSpan EndTime {
      get; set;
    }

    /// <summary>
    /// Guide
    /// </summary>
    [JsonProperty("guide")]
    public int Guide {
      get; set;
    }
    /// <summary>
    /// Staff
    /// </summary>
    [JsonProperty("staff")]
    public string Staff {
      get; set;
    }
  }

  public class DelPeriod {
    [JsonProperty("instanceid")]
    public int Instanceid {
      get; set;
    }

    [JsonProperty("period_id")]
    public int PeriodId {
      get; set;
    }

  }

}

