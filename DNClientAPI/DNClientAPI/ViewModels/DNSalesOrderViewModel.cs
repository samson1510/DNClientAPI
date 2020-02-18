using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataNova.Common;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using DNClientAPI.Models;
using DNClientAPI.Globalization;


namespace XRETAIL.ViewModels {
  public class DNSalesOrderViewModel:BaseViewModel {
    public ObservableCollection<DNSalesOrder> Orders { get; set; }
    private DNSalesOrder _selectedorder;
    private DNSalesOrderLine _selectedorderline;
    private bool _isVisibleNextCommand;
    private bool _isVisiblePreviousCommand;
    private DateTime LastRefreshTime;
    private DateTime LineLastRefreshTime;
    public DNSalesOrder SelectedOrder {
      get { return _selectedorder; }
      set {
        if(_selectedorder != value) {
          _selectedorder = value;
          OnPropertyChanged("SelectedOrder");
        }
      }
    }
    public DNSalesOrderLine SelectedOrderLine {
      get { return _selectedorderline; }
      set {
        if(_selectedorderline != value) {
          _selectedorderline = value;
          OnPropertyChanged("SelectedOrderLine");
          LoadStockDetails();
        }
      }
    }
    public bool IsVisibleNextCommand {
      get { return _isVisibleNextCommand; }
      set {
        if(_isVisibleNextCommand != value) {
          _isVisibleNextCommand = value;
          OnPropertyChanged("IsVisibleNextCommand");
        }
      }
    }
    public bool IsVisiblePreviousCommand {
      get { return _isVisiblePreviousCommand; }
      set {
        if(_isVisiblePreviousCommand != value) {
          _isVisiblePreviousCommand = value;
          OnPropertyChanged("IsVisiblePreviousCommand");
        }
      }
    }
    public override async Task<bool> LoadAsync() {
      try {
        this.IsBusy = true;
        await Task.Delay(100);
        this.SelectedOrder = null;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Headers/");
        if(this.Orders.Count > 0) {
          string tempLastrefreshDatetime = LastRefreshTime.ToString("yyyy-MM-dd HH:mm");
          tempLastrefreshDatetime = tempLastrefreshDatetime.Replace(".",":");
          url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Headers/?lastchangedate={0}",tempLastrefreshDatetime);
        } else {
          url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Headers/");
        }
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var OrderResponses = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JArray;
            if(OrderResponses != null) {
              foreach(var order in OrderResponses) {
                DNSalesOrder ObjOrder = new DNSalesOrder();
                foreach(JProperty property in order.Values<JToken>()) {
                  switch(property.Name) {
                    case "order_number":
                      ObjOrder.OrderNumber = property.Value.ToString();
                      break;
                    case "customer_number":
                      ObjOrder.CustomerNumber = property.Value.ToLong();
                      break;
                    case "customer_name":
                      ObjOrder.CustomerName = property.Value.ToString();
                      break;
                    case "shop_number":
                      ObjOrder.ShopNumber = property.Value.ToInt();
                      break;
                    case "name":
                      ObjOrder.ShopName = property.Value.ToSafeString();
                      break;
                    case "date":
                      ObjOrder.OrderDate = property.Value.ToLong().ToLocalDateTime();
                      break;
                    case "total_Order_amount":
                      ObjOrder.TotalAmount = property.Value.ToDouble();
                      break;
                    case "total_order_qty":
                      ObjOrder.TotalOrderedQuantity = property.Value.ToDouble();
                      break;
                    case "total_delivery_qty":
                      ObjOrder.TotalDeliveredQuantity = property.Value.ToDouble();
                      break;
                    case "order_statuscode":
                      ObjOrder.Status = property.Value.ToSafeString();
                      break;
                    case "total_lines":
                      ObjOrder.TotalOrderedLines = property.Value.ToInt();
                      break;
                    case "total_delivered_lines":
                      ObjOrder.TotalOrderedeliveredLines = property.Value.ToInt();
                      break;
                  }
                }
                var tempexistingorder = this.Orders.Where(c => c.OrderNumber == ObjOrder.OrderNumber).SingleOrDefault();
                if(tempexistingorder != null) {
                  if(ObjOrder.Status.ToLower() == "sold") {
                    this.Orders.Remove(tempexistingorder);
                  } else {
                    tempexistingorder.CustomerNumber = ObjOrder.CustomerNumber;
                    tempexistingorder.CustomerName = ObjOrder.CustomerName;
                    tempexistingorder.ShopNumber = ObjOrder.ShopNumber;
                    tempexistingorder.ShopName = ObjOrder.ShopName;
                    tempexistingorder.OrderDate = ObjOrder.OrderDate;
                    tempexistingorder.TotalAmount = ObjOrder.TotalAmount;
                    tempexistingorder.TotalOrderedQuantity = ObjOrder.TotalOrderedQuantity;
                    tempexistingorder.TotalDeliveredQuantity = ObjOrder.TotalDeliveredQuantity;
                    tempexistingorder.Status = ObjOrder.Status;
                    tempexistingorder.TotalOrderedLines = ObjOrder.TotalOrderedLines;
                    tempexistingorder.TotalOrderedeliveredLines = ObjOrder.TotalOrderedeliveredLines;
                  }
                } else {
                  if(ObjOrder.Status.ToLower() != "sold")
                    this.Orders.Add(ObjOrder);
                }
              }
            }
          }
        }
      } catch(Exception ex) {

      } finally {
        IsBusy = false;
        LastRefreshTime = System.DateTime.Now;
      }
      return await base.LoadAsync();
    }
    public async Task<bool> LoadHistoryAsync(string CustomerNumber,int length) {
      var httpResponse = await DNAPIHandler.Current.GetResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getwebsalesorders/?customerno={0}&shopno={1}&pageno={2}&pagesize={3}",CustomerNumber,DNGlobalProperties.Current.ShopNumber,0,length));
      if(httpResponse.StatusCode == HttpStatusCode.OK) {
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          string stringvalue = streamReader.ReadToEnd();
          var list = JsonConvert.DeserializeObject<List<DNSalesOrder>>(stringvalue);
          if(list == null) {
            return await Task.FromResult(false);
          } else {
            Orders = new ObservableCollection<DNSalesOrder>(list);
          }
        }
      }
      return await Task.FromResult(true);
    }
    public async Task<List<DNTicketDetail>> LoadTicketsAsync(string ordernumber) {
      return await DNAPIHandler.Current.GetResponseObjectAsync<List<DNTicketDetail>>(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getallticketbasedonorder/?orderno={0}",ordernumber));
    }
    public async Task LoadLinesAsync() {
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Lines/?ordernumber={0}&shopnumber={1}",this.SelectedOrder.OrderNumber,this.SelectedOrder.ShopNumber);
        if(this.SelectedOrder.Lines.Count == 0) {
          url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Lines/?ordernumber={0}&shopnumber={1}",this.SelectedOrder.OrderNumber,this.SelectedOrder.ShopNumber);
        } else {
          string tempLastrefreshDatetime = LineLastRefreshTime.ToString("yyyy-MM-dd HH:mm");
          tempLastrefreshDatetime = tempLastrefreshDatetime.Replace(".",":");
          url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Lines/?ordernumber={0}&shopnumber={1}&lastupdatetime={2}",this.SelectedOrder.OrderNumber,this.SelectedOrder.ShopNumber,tempLastrefreshDatetime);
        }
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JArray;
            if(response == null) {
              this.IsBusy = false;
              return;
            }
            foreach(var orderlineobj in response) {
              DNSalesOrderLine orderlines = new DNSalesOrderLine();
              foreach(JProperty property in orderlineobj.Values<JToken>()) {
                switch(property.Name.ToLower()) {
                  case "item_number":
                    orderlines.ItemNumber = property.Value.ToLong();
                    break;
                  case "item_name":
                    orderlines.ItemName = property.Value.ToSafeString();
                    break;
                  case "ordered_qty":
                    orderlines.OrderedQuantity = property.Value.ToDouble();
                    break;
                  case "line_total":
                    orderlines.Amount = property.Value.ToDouble();
                    break;
                  case "supplier_item_number":
                    orderlines.SupplierItemNo = property.Value.ToSafeString();
                    break;
                  case "delivered_qty":
                    orderlines.DeliveredQuantity = property.Value.ToDouble();
                    break;
                  case "item_location":
                    orderlines.ItemLocation = property.Value.ToSafeString();
                    break;
                  case "item_picklocation":
                    orderlines.PickLocation = property.Value.ToSafeString();
                    break;
                  case "item_lagerstock":
                    orderlines.StockQuantity = property.Value.ToDouble();
                    break;
                  case "kolli":
                    orderlines.Kolli = property.Value.ToDouble();
                    break;
                  case "sortmentcode":
                    orderlines.SortmentCode = property.Value.ToString();
                    break;
                  case "suppliername":
                    orderlines.SupplierName = property.Value.ToString();
                    break;
                  case "line_status":
                    if(property.Value.ToString().ToUpper() == "INPROGRESS")
                      orderlines.Status = OrderLineStatus.INPROGRESS;
                    else if(property.Value.ToString().ToUpper() == "DELIVERED")
                      orderlines.Status = OrderLineStatus.DELIVERED;
                    else if(property.Value.ToString().ToUpper() == "INPROGRESSVISITED")
                      orderlines.Status = OrderLineStatus.INPROGRESSVISITED;
                    else
                      orderlines.Status = OrderLineStatus.NONE;
                    break;
                }
              }
              var tempexistingorder = this.SelectedOrder.Lines.Where(c => c.ItemNumber == orderlines.ItemNumber).SingleOrDefault();
              if(tempexistingorder != null) {
                tempexistingorder.ItemNumber = orderlines.ItemNumber;
                tempexistingorder.ItemName = orderlines.ItemName;
                tempexistingorder.OrderedQuantity = orderlines.OrderedQuantity;
                tempexistingorder.Amount = orderlines.Amount;
                tempexistingorder.SupplierItemNo = orderlines.SupplierItemNo;
                tempexistingorder.DeliveredQuantity = orderlines.DeliveredQuantity;
                tempexistingorder.ItemLocation = orderlines.ItemLocation;
                tempexistingorder.PickLocation = orderlines.PickLocation;
                tempexistingorder.StockQuantity = orderlines.StockQuantity;
                tempexistingorder.Kolli = orderlines.Kolli;
                tempexistingorder.SortmentCode = orderlines.SortmentCode;
                tempexistingorder.SupplierName = orderlines.SupplierName;
                tempexistingorder.Status = orderlines.Status;
              } else {
                this.SelectedOrder.Lines.Add(orderlines);
              }
            }
          }
        }
      } catch(Exception ex) {
        string message = ex.ToString();
      } finally {
        this.IsBusy = false;
        LineLastRefreshTime = DateTime.Now;
      }
    }
    public async Task PickQuantity() {
      try {
        if(this.SelectedOrder == null || this.SelectedOrderLine == null) {
          return;
        }
        this.IsBusy = true;
        long UserNumber = 1;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Update/?shopnumber={0}&usernumber={1}",this.SelectedOrder.ShopNumber, UserNumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = "";
          double QtyToupdate = SelectedOrderLine.QuantityToDeliver;
          SelectedOrderLine.Isqtyreduced = false;
          json = JsonConvert.SerializeObject(new {
            line_order_number = _selectedorder.OrderNumber,
            item_number = _selectedorderline.ItemNumber,
            delivered_qty = QtyToupdate
          },new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JValue>(streamReader.ReadToEnd().Replace(",",".").Replace("\\","").Replace("\"",""));
            SelectedOrderLine.DeliveredQuantity = response.ToDouble();
            if(this.SelectedOrder.TotalOrderedeliveredLines != this.SelectedOrder.Lines.Count && SelectedOrderLine.DeliveredQuantity != 0 && this.SelectedOrder.TotalOrderedeliveredLines == 0)
              this.SelectedOrder.TotalOrderedeliveredLines = this.SelectedOrder.TotalOrderedeliveredLines + 1;
            if(SelectedOrderLine.DeliveredQuantity >= SelectedOrderLine.OrderedQuantity) {
              SelectedOrderLine.Status = OrderLineStatus.DELIVERED;
            } else if(SelectedOrderLine.DeliveredQuantity == 0) {
              SelectedOrderLine.Status = OrderLineStatus.INPROGRESSVISITED;
            } else if(SelectedOrderLine.DeliveredQuantity > 0)
              SelectedOrderLine.Status = OrderLineStatus.INPROGRESS;
            if(response.ToDouble() == 0 && SelectedOrderLine.Status == OrderLineStatus.INPROGRESSVISITED) {
              this.SelectedOrderLine.Difference = (this.SelectedOrderLine.OrderedQuantity - this.SelectedOrderLine.DeliveredQuantity);
            }
            await LoadStockDetails();
          }
        }
      } catch(Exception ex) {
      } finally {
        this.IsBusy = false;
      }
    }
    public async Task<bool> PrintOrders() {
      bool _issucess = false;
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/mobile/sales_orders/print/ordernumber={0}",SelectedOrder.OrderNumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);
        httpWebRequest.ContentLength = 0;
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            if(streamReader.ReadToEnd().ToBool()) {
              return await Task.FromResult(true);
            }
          }
        }
      } catch(Exception ex) {
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(_issucess);
    }
    public async Task<bool> FillLineStatus(bool Isurgent = false) {
      try {
        if(this.SelectedOrder == null || this.SelectedOrderLine == null) {
          return await Task.FromResult(false);
        }
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Update/?type={0}","filllinestatus");
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = "";
          json = JsonConvert.SerializeObject(new {
            line_order_number = _selectedorder.OrderNumber,
            item_number = _selectedorderline.ItemNumber,
            text_1 = "true",
            text_2 = Isurgent
          },new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var valuetest = streamReader.ReadToEnd().Replace("\\","").Replace("\"","");
            if(valuetest.ToBool()) {
              return await Task.FromResult(true);
            }
          }
        }
      } catch(Exception ex) {
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(false);
    }
    public async Task<bool> MarkLagerStatus() {
      try {
        if(this.SelectedOrder == null || this.SelectedOrderLine == null) {
          return await Task.FromResult(false);
        }
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/Update/?type={0}","filllagerstatus");
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = "";
          json = JsonConvert.SerializeObject(new {
            line_order_number = _selectedorder.OrderNumber,
            item_number = _selectedorderline.ItemNumber,
            text_1 = "true"
          },new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var valuetest = streamReader.ReadToEnd().Replace("\\","").Replace("\"","");
            if(valuetest.ToBool()) {
              return await Task.FromResult(true);
            }
          }
        }
      } catch(Exception ex) {
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(false);
    }
    public async Task LoadStockDetails() {
      try {
        this.IsBusy = true;
        if(this.SelectedOrderLine != null) {
          string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/items/Getitemstockdetails/?ShopNumber={0}&ItemNumber={1}&ordernumber={2}",this.SelectedOrder.ShopNumber,this.SelectedOrderLine.ItemNumber,this.SelectedOrder.OrderNumber);
          var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
          var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
          if(httpResponse.StatusCode == HttpStatusCode.OK) {
            using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
              var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
              var stockobj = response.Value<JToken>();
              if(stockobj == null) {
                return;
              }
              var properties = stockobj.Values<JToken>();
              foreach(JProperty property in stockobj.Values<JToken>()) {
                switch(property.Name) {
                  case "item_avialablestock":
                    this.SelectedOrderLine.AvailableStockQuantity = property.Value.ToDouble();
                    break;
                  case "item_theostock":
                    this.SelectedOrderLine.StockQuantity = property.Value.ToDouble();
                    break;
                  case "item_deliveredqty":
                    double deliveredqty = property.Value.ToDouble();
                    SelectedOrderLine.DeliveredQuantity = deliveredqty;
                    break;
                  case "line_status":
                    if(property.Value.ToString().ToUpper() == "INPROGRESS")
                      SelectedOrderLine.Status = OrderLineStatus.INPROGRESS;
                    else if(property.Value.ToString().ToUpper() == "DELIVERED")
                      SelectedOrderLine.Status = OrderLineStatus.DELIVERED;
                    else if(property.Value.ToString().ToUpper() == "INPROGRESSVISITED")
                      SelectedOrderLine.Status = OrderLineStatus.INPROGRESSVISITED;
                    else
                      SelectedOrderLine.Status = OrderLineStatus.NONE;
                    if(SelectedOrderLine.DeliveredQuantity == 0 && SelectedOrderLine.Status == OrderLineStatus.INPROGRESSVISITED) {
                      this.SelectedOrderLine.Difference = (this.SelectedOrderLine.OrderedQuantity - this.SelectedOrderLine.DeliveredQuantity);
                      this.SelectedOrderLine.QuantityToDeliver = this.SelectedOrderLine.Difference ?? 0;
                    }
                    if(this.SelectedOrder.TotalOrderedeliveredLines != this.SelectedOrder.Lines.Count && SelectedOrderLine.DeliveredQuantity != 0 && SelectedOrderLine.Status == OrderLineStatus.NONE)
                      this.SelectedOrder.TotalOrderedeliveredLines = this.SelectedOrder.TotalOrderedeliveredLines + 1;
                    break;
                }
              }
            }
          }
        }
      } catch(Exception ex) {
        string message = ex.ToString();
      } finally {
        this.IsBusy = false;
      }
    }

    public async Task<string> SaveOrder(DNSalesOrder salesOrder) {
      var url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/");
      string jsonPayload = JsonConvert.SerializeObject(salesOrder);
      var httpResponse = await DNAPIHandler.Current.PostResponseAsync(url,jsonPayload);
      var so = DNAPIHandler.Current.ReadResponse<DNSalesOrder>(httpResponse);
      return so.OrderNumber;
    }
    public async Task<DNSalesOrder> GetOrder(string orderNo) {
      var url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/sales_orders/" + orderNo);
      var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
      var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
      var so = DNAPIHandler.Current.ReadResponse<DNSalesOrder>(httpResponse);
      return so;
    }
  }
  public class DNTicketReport {
    public DNSalesOrder Order { get; set; }
    public List<DNTicketDetail> Tickets { get; set; }
    public string AppHostUrl { get; set; }
    public DNCompany Company { get; set; }
  }
}
