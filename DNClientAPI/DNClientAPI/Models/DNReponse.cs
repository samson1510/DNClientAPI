using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DNClientAPI.Models {
  public class DNResponse {

    #region properties
    /// <summary>
    /// Code
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }

    /// <summary>
    /// Message
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }
    #endregion
  }
}
