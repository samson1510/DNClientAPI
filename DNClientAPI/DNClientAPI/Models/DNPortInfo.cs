using Newtonsoft.Json;

namespace DNClientAPI.Models {
  public class DNPortInfo {

    [JsonProperty("port_id")]
    public int Id { get; set; }

    /// <summary>
    /// Port Name
    /// </summary>
    [JsonProperty("port_name")]
    public string PortName { get; set; }


    /// <summary>
    /// IP Address
    /// </summary>
    [JsonProperty("port_ipaddress")]
    public string ipaddress { get; set; }

    /// <summary>
    /// CoAllowedFlag
    /// </summary>
    [JsonProperty("port_isallowed")]
    public bool isAllowed { get; set; }
  }
}
