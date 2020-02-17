using Newtonsoft.Json;
using DataNova.Common;
using System.Linq;
using System.Runtime.Serialization;

namespace DNClientAPI.Models {

  /// <summary>
  /// Form
  /// </summary>
  public class DNForm {

    #region Properties
    public string Type { get; set; }
    /// <summary>
    /// Module Number
    /// </summary>
    [JsonProperty("module_number")]
    public long ModuleNumber {
      get; set;
    }
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("module_name")]
    public string ModuleName {
      get; set;
    }
    /// <summary>
    /// Form Number
    /// </summary>
    [JsonProperty("form_number")]
    public long Number { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("readaccess")]
    public bool Readaccess { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("writeaccess")]
    public bool Writeaccess { get; set; }
    /// <summary>
    /// Link
    /// </summary>
    public string Link { get; set; }
    public string Title { get; set; }

    public string Icon { get; set; }
    public string Location { get; set; }
    public string Url { get; set; }

    #endregion Properties

  }
  public class DNGridOptions {
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public string FilterText { get; set; }
    public string SortedColumn { get; set; }
    public SortType SortOrder { get; set; }
    public DNGridOptions () {}
    public new string ToString () {
      string _query = "";
      if(PageIndex > 0) {
        _query = "Page=" + PageIndex;
      }
      if(PageSize > 0) {
        _query = (string.IsNullOrEmpty(_query)? "page_size=": "&page_size=") + PageSize;
      }
      if(!string.IsNullOrEmpty(FilterText)) {
        _query = (string.IsNullOrEmpty(_query) ? "filter=" : "&filter=") + FilterText;
      }
      if(!string.IsNullOrEmpty(SortedColumn)) {
        _query = (string.IsNullOrEmpty(_query) ? "orderby=" : "&orderby=") + SortedColumn + " " + SortOrder;
      }
      return _query;
    }
  }
}
