using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DataNova.Common;
using DNClientAPI.Models;

namespace XRETAIL.ViewModels {
  public class BaseViewModel : INotifyPropertyChanged {
    private int _badgeCount;
    private string _searchtext;
    public ICommand RefreshCommand { get; set; }
    public bool IsLoaded { get; set; }

    private bool _isRefreshEnabled = true;
    public bool IsRefreshEnabled {
      get { return _isRefreshEnabled; }
      set { SetProperty(ref _isRefreshEnabled, value); }
    }
    public string Read {
      get; set;
    }
    public string write {
      get; set;
    }
    public string delete {
      get; set;
    }
    protected bool isBusy = false;
    private bool isNormal = true;
    public virtual bool IsBusy {
      get { return isBusy; }
      set {
        if (isBusy != value) {
          isBusy = value;
          IsNormal = !value;
          OnPropertyChanged("IsBusy");
        }
      }
    }
    public bool IsNormal {
      get { return isNormal; }
      set {
        if (isNormal != value) {
          isNormal = value;
          OnPropertyChanged("IsNormal");
        }
      }
    }
    public virtual string SearchText {
      get { return _searchtext; }
      set {
        if (_searchtext != value) {
          _searchtext = value;
          OnPropertyChanged("SearchText");
        }
      }
    }
    string title = string.Empty;
    public string Title {
      get { return title; }
      set { SetProperty(ref title, value); }
    }

    string _subTitle = string.Empty;
    public string SubTitle {
      get { return _subTitle; }
      set { SetProperty(ref _subTitle, value); }
    }

    string titleFromResource = string.Empty;
    public string TitleFromResource {
      get { return titleFromResource; }
      set { SetProperty(ref titleFromResource, value); }
    }
       
    string subtitleFromResource = string.Empty;
    public string SubtitleFromResource {
      get { return subtitleFromResource; }
      set { SetProperty(ref subtitleFromResource, value); }
    }
    public bool IsSeparatorVisible { get; set; }
    public double Height { get; set; }
    public bool IsNotificationVisible { get; set; }
    public virtual int BadgeCount {
      get { return _badgeCount; }
      set { SetProperty(ref _badgeCount, value); }
    }
    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName]string propertyName = "",
        Action onChanged = null) {
      if (EqualityComparer<T>.Default.Equals(backingStore, value))
        return false;

      backingStore = value;
      onChanged?.Invoke();
      OnPropertyChanged(propertyName);
      return true;
    }
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
      var changed = PropertyChanged;
      if (changed == null)
        return;

      changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
    public virtual async Task<bool> AddItemAsync(object itemno, double qty = 1, string returntext = "") {
      return await Task.FromResult(true);
    }

    public virtual async Task<bool> UpdateItemAsync(object item) {
      return await Task.FromResult(true);
    }

    public virtual async Task<bool> AddDunCodeItemsAsync(object itemno, double qty = 1) {
      return await Task.FromResult(true);
    }

    public virtual async Task<bool> DeleteItemAsync(object item) {
      return await Task.FromResult(true);
    }

    public virtual async Task<BaseModel> LoadAsync(object obj) {
      return await Task.FromResult<BaseModel>(null);
    }
    public virtual async Task<bool> LoadAsync() {
      return await Task.FromResult(true);
    }
    public virtual async Task<bool> LoadAsync(APIFilter filter) {
      return await Task.FromResult(true);
    }
    public virtual async Task<bool> SaveAsync() {
      return await Task.FromResult(true);
    }
    public virtual async Task<DNActionResult> SaveAsync(BaseModel model) {
      return await Task.FromResult(new DNActionResult());
    }
    public virtual async Task<DNActionResult> DeleteAsync(BaseModel model) {
      return await Task.FromResult(new DNActionResult());
    }
    public virtual async Task<bool> SearchAsync() {
      return await Task.FromResult(true);
    }
    public virtual async Task<bool> LoadMasterLoyalty() {
      return await Task.FromResult(true);
    }

    public virtual async Task<bool> RefreshAsync() {
      return await Task.FromResult(true);
    }
    public virtual async Task<int> GetDiscountCountsAsync() {
      return await Task.FromResult(0);
    }
    public virtual async Task<bool> AddGiftVoucherAsync(object itemno, double qty = 1) {
      return await Task.FromResult(true);
    }

    public virtual async Task<bool> AddPayOutAsync(object itemno, double qty = 1) {
      return await Task.FromResult(true);
    }
    public virtual async Task<bool> AddPayinAsync(object itemno, double qty = 1) {
      return await Task.FromResult(true);
    }
    public virtual Dictionary<string, string> Validate(BaseModel model) {
      return new Dictionary<string, string>();
    }

    public APIFilter GenerateFilter(List<string> columnlist,List<string> filterlist,List<string> columnDisplayName) {
      APIFilter filter = new APIFilter();
      List<APIColumnQuery> colQueries = new List<APIColumnQuery>();
      string[] SplitColumns = columnlist[0].Split(',');
      string[] FilterList = filterlist[0].Split(',');
      string[] DisplayList = null;
      if(columnDisplayName.Count > 0) {
        DisplayList = columnDisplayName[0].Split(',');
      }
      filter.ColumnInfo = new DNAPIColumn[DisplayList.Length - 1];
      if(columnlist != null && columnlist.Count > 0) {
        for(int i = 0;i < SplitColumns.Length;i++) {
          if(SplitColumns[i] != "") {
            var orderQuery1 = new APIColumnQuery();
            orderQuery1.name = SplitColumns[i];
            orderQuery1.search = new APISearchValue();
            orderQuery1.search.value = FilterList[i];
            colQueries.Add(orderQuery1);
            filter.ColumnInfo[i - 1] = new DNAPIColumn() {
              DisplayName = DisplayList[i],
              TableColumnName = SplitColumns[i]
            };
          }
        }
      }
      filter.columns = new APIColumnQuery[colQueries.Count];
      for(int i = 0;i < filter.columns.Length;i++) {
        filter.columns[i] = colQueries[i];
      }
      filter.order = new APIOrderQuery[1];
      filter.order[0] = new APIOrderQuery() {
        column = 0,
        dir = "asc"
      };
      return filter;
    }
  }
  public class DNActionResult {
    public NotificationType Notification { get; set; }
    public DNActionCommand Action {
      get; set;
    }
    public Dictionary<string, string> ValidationErrors { get; set; }
    public DNActionResult() {
      ValidationErrors = new Dictionary<string, string>();
    }
    public string Message {
      get {
        string _message = "Info";
        switch (Notification) {
          case NotificationType.success:
            switch (Action) {
              case DNActionCommand.Save:
                _message = "recordsaved";
                break;
              case DNActionCommand.Delete:
                _message = "recorddeleted";
                break;
              case DNActionCommand.DeleteLine:
                _message = "recorddeleted";
                break;
            }          
            break;
          case NotificationType.warning:
            _message = "recordworning";
            break;
          case NotificationType.info:
            _message = "recordworning";
            break;
          case NotificationType.error:
            _message = "recorderror";
            break;
        }
        return _message;
      }
    }
    public BaseModel ReturnModel {
      get;set;
    }
  }

  public enum NotificationType {
    error,
    success,
    warning,
    info
  }

  public enum DNActionCommand {
    New,
    Delete,
    Save,
    DeleteLine,
    Show,
    Back,
    Copy,
    savetimeinfo,
    Refresh,
    SaveAdditionalDetails,
    AddBlankRow,
    sendEmail,
    process,
    Publish,
    Apply,
    Navigate,
    Get,
    Load,
    CopyWeak
  }
}
