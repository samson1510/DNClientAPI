using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DNClientAPI.Models {
  public class DNGiftVouchers : BaseModel {
    private bool _singleCustomer;
    private decimal? _totalBalance;

    #region Properties

    private ObservableCollection<DNGiftVoucher> _vouchers;
    [JsonProperty("vouchers")]
    public ObservableCollection<DNGiftVoucher> Vouchers {
      get { return _vouchers; }
      set {
        if (_vouchers != value) {
          _vouchers = value;
          OnPropertyChanged("Vouchers");
        }
      }
    }
    
    [JsonProperty("total_balance")]
    public decimal? TotalBalance {
      get { return _totalBalance; }
      set {
        if (_totalBalance != value) {
          _totalBalance = value;
          OnPropertyChanged("total_balance");
        }
      }
    }
    
    [JsonProperty("SingleCustomer")]
    public bool SingleCustomer {
      get { return _singleCustomer; }
      set {
        if (_singleCustomer != value) {
          _singleCustomer = value;
          OnPropertyChanged("SingleCustomer");
        }
      }
    }
    #endregion Properties
  }
}