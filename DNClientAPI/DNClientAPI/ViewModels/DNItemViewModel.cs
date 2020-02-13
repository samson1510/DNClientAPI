using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNClientAPI.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using DataNova.Common;
using DNClientAPI.Globalization;

using System.Linq;

namespace XRETAIL.ViewModels {
  public class DNItemViewModel : BaseViewModel {
    private DNItem _selecteditem;
    public ObservableCollection<DNItem> Items { get; set; }
    public int TotalRecords { get; set; }
    public DNItemViewModel() {
      Items = new ObservableCollection<DNItem>();
    }
    public async Task<bool> LoadAsync(APIFilter filter,string profileno) {
      Items.Clear();
      bool _isvalue = false;
      try {
        var httpResponse = await DNAPIHandler.Current.PostResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getfiltereditems/profilenumber={0}",profileno), filter.FilterToJSON());
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var items = JsonConvert.DeserializeObject<List<DNItem>>(streamReader.ReadToEnd());
            if(items != null) {
              Items = new ObservableCollection<DNItem>(items);
            }
          }
          _isvalue = true;
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      }
      return await Task.FromResult(_isvalue);
    }

    public  async Task<BaseModel> LoadAsync(object itemnumber,string profileNo,string shopNumber="") {
      DNItem _item = null;
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/items/{0}?profile_number={1}&shop_number={2}",itemnumber,profileNo,shopNumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET", url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            string value = streamReader.ReadToEnd();
            _item = JsonConvert.DeserializeObject<DNItem>(value);
            if(_item.Sortment == null) _item.Sortment = new DNSortimentCode();
          }
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(_item);
    }

    public async Task<BaseModel> LoadAddtionalDetailsAsync(object itemnumber) {
      DNItem _item = null;
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/item/additional_details?item_number={0}", itemnumber);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET", url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            string value = streamReader.ReadToEnd();
            _item = JsonConvert.DeserializeObject<DNItem>(value);
            _item.VatCode = _item.VatRate.Id.ToString();
            _item.VatName = _item.VatRate.Name;
            _item.Quantity = "1";
            _item.vatpercentage = (double)_item.VatRate.Rate;
            _item.Itemnumber = _item.Itemnumber;
            if(_item.TicketInformation != null) {
              if(_item.TicketInformation.ValidTillLongNullable != null) {
                _item.TicketInformation.ValidTill = _item.TicketInformation.ValidTillLong.ToLocalDateTime();
              }
            }
            if(_item.Sortment == null) _item.Sortment = new DNSortimentCode();
          }
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(_item);
    }

    private class itemSearch {
      public string item_numbers { get; set; }
    }

    public async Task<List<DNItem>> LoadItemsAsync(List<string> itemNumbers,string profileno) {
      var searchobj = new itemSearch() { item_numbers = string.Join(",", itemNumbers) };
      List<DNItem> list = new List<DNItem>();
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getselecteditems/profilenumber={0}",profileno);
        var httpResponse = await DNAPIHandler.Current.PostResponseAsync(url, JsonConvert.SerializeObject(searchobj));
        list = DNAPIHandler.Current.ReadResponse<List<DNItem>>(httpResponse);
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(list);
    }

    public async Task<List<DNEventBookingItem>> LoadItemsCommonAsync(List<string> itemNumbers,string profileno) {
      var searchobj = new itemSearch() { item_numbers = string.Join(",", itemNumbers) };
      List<DNEventBookingItem> list = new List<DNEventBookingItem>();
      List<DNItem> listItem = new List<DNItem>();
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getselecteditems/profilenumber={0}",profileno);
        var httpResponse = await DNAPIHandler.Current.PostResponseAsync(url, JsonConvert.SerializeObject(searchobj));
        listItem = DNAPIHandler.Current.ReadResponse<List<DNItem>>(httpResponse);
        foreach(var data in listItem) {
          DNEventBookingItem _commonItem = new DNEventBookingItem();

          _commonItem.Name = data.ItemName;
          _commonItem.Number = long.Parse(data.Itemnumber.ToString());
          _commonItem.SalesPrice = data.SalesPrice;

          _commonItem.Type = DNBookingItemType.Item;
          list.Add(_commonItem);
        }


      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(list);
    }

    public async Task<List<DNItem>> LoadItemAsync(List<string> itemNumbers,string profileno) {
      var searchobj = new itemSearch() { item_numbers = string.Join(",",itemNumbers) };
      List<DNItem> list = new List<DNItem>();
      List<DNItem> listItem = new List<DNItem>();
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getselecteditems/profilenumber={0}",profileno);
        var httpResponse = await DNAPIHandler.Current.PostResponseAsync(url,JsonConvert.SerializeObject(searchobj));
        listItem = DNAPIHandler.Current.ReadResponse<List<DNItem>>(httpResponse);
        foreach(var data in listItem) {
          DNItem _commonItem = new DNItem();

          _commonItem.ItemName = data.ItemName;
          _commonItem.Itemnumber = long.Parse(data.Itemnumber.ToString());
          _commonItem.SalesPrice = data.SalesPrice;
          list.Add(_commonItem);
        }


      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(list);
    }

    public async Task<List<DNItemType>> LoadItemTypesAsync() {
      List<DNItemType> itemList = new List<DNItemType>();
      try {
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/itemtypes");
        var httpResponse = await DNAPIHandler.Current.GetResponseAsync(url);
        if(httpResponse.StatusCode == System.Net.HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            string json = streamReader.ReadToEnd();
            itemList = JsonConvert.DeserializeObject<List<DNItemType>>(json, new ItemTypeIDToEnumConverter());
          }
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      } finally {
      }
      return await Task.FromResult(itemList);
    }
    public async Task<DNActionResult> DeleteAsync(BaseModel model,string profileno,string userno,string shopNo) {
      DNItem item = (DNItem)model;
      var result = new DNActionResult();
      if(item.Itemnumber == 0) {
        result.ValidationErrors.Add("ItemNumber", "itemdoesnotexist");
      }
      result.Notification = result.ValidationErrors.Count == 0 ? NotificationType.success : NotificationType.warning;
      if(result.Notification == NotificationType.success) {
        result.Action = DNActionCommand.Delete;
        try {
          string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/item/deleteitem?itemnumber={0}&userno={1}&profileno={2}&shopno={2}", item.Itemnumber,userno,profileno,shopNo);
          var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET", url);
          var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
          if(httpResponse.StatusCode == HttpStatusCode.OK) {
            using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
              bool isvalid = streamReader.ReadToEnd().ToBool();
              result.Notification = isvalid ? NotificationType.success : NotificationType.error;
            }
          }
        } catch(Exception exc) {
          string error = exc.Message + exc.StackTrace;
        }
      }
      return await Task.FromResult(result);
    }
    public override async Task<DNActionResult> SaveAsync(BaseModel model) {
      DNItem item = (DNItem)model;
      var result = new DNActionResult();
      result.ValidationErrors = Validate(item);
      result.Notification = result.ValidationErrors.Count == 0 ? NotificationType.success : NotificationType.warning;
      if(result.Notification == NotificationType.success) {
        result.Action = DNActionCommand.Save;
        try {
          var json = JsonConvert.SerializeObject(item, new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
          var httpResponse = (HttpWebResponse)await DNAPIHandler.Current.PostResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/saveitem/?shop_number={0}&user_number={1}", item.LoginShopNumber, item.LogInUserId), json);
          if(httpResponse.StatusCode == HttpStatusCode.OK) {
            using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
              result.ReturnModel = JsonConvert.DeserializeObject<DNItem>(streamReader.ReadToEnd());
              if(result.ReturnModel == null) {
                result.Notification = NotificationType.error;
              }
            }
          } else {
            result.Notification = NotificationType.error;
          }
        } catch(Exception exc) {
          string error = exc.Message + exc.StackTrace;
        }
      }
      return await Task.FromResult(result);
    }
    public async Task<DNActionResult> SaveAddtionalDetailsAsync(BaseModel model) {
      DNItem item = (DNItem)model;
      var result = new DNActionResult();
      result.ValidationErrors = Validate(item);
      result.Notification = result.ValidationErrors.Count == 0 ? NotificationType.success : NotificationType.warning;
      if(result.Notification == NotificationType.success) {
        result.Action = DNActionCommand.Save;
        try {
          var json = JsonConvert.SerializeObject(item, new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
          var httpResponse = (HttpWebResponse)await DNAPIHandler.Current.PostResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/item/additional_details/"), json);
          if(httpResponse.StatusCode == HttpStatusCode.OK) {
            using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
              result.ReturnModel = JsonConvert.DeserializeObject<DNItem>(streamReader.ReadToEnd());
              if(result.ReturnModel == null) {
                result.Notification = NotificationType.error;
              }
            }
          } else {
            result.Notification = NotificationType.error;
          }
        } catch(Exception exc) {
          string error = exc.Message + exc.StackTrace;
        }
      }
      return await Task.FromResult(result);
    }
    public async Task<long> GetMaxNumberAsync() {
      long _maxnumber = 0;
      try {
        _maxnumber = await DNAPIHandler.Current.GetResponseObjectAsync<long>(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @" / back_office/item/generateeancode?shopno={0}", DNGlobalProperties.Current.ShopNumber));
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      }
      return _maxnumber;
    }
    public async Task<bool> IsExists(long itemnumber) {
      bool isexists = false;
      try {
        isexists = await DNAPIHandler.Current.GetResponseObjectAsync<bool>(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/item/Checkitemexists?itemnumber={0}&profileno={1}", itemnumber, DNGlobalProperties.Current.ProfileNumber));
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      }
      return isexists;
    }
    public override Dictionary<string, string> Validate(BaseModel itemmodel) {
      var model = itemmodel as DNItem;
      Dictionary<string, string> itemError = new Dictionary<string, string>();
      if(string.IsNullOrEmpty(model.ItemName)) {
        itemError.Add("ItemName", "itemnameisrequired");
      }
      if(model.ItemInPackage == 0 || model.ItemInPackage < 0) {
        itemError.Add("itemINPackage", "enterpositivevalue");
      }
      if(model.ItemType == DNItemType.Commission && model.CommissionType == DNCommissionType.Blank) {
        itemError.Add("commissionerror", "commissiontypenotset");
      }
      return itemError;
    }
  }
}
