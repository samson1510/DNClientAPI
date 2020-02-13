using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DNClientAPI.Models {
  public abstract class BaseModel: INotifyPropertyChanged {
    public string Title { get; set; }
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
      var changed = PropertyChanged;
      if (changed == null)
        return;

      changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
}
