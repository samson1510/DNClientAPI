using Newtonsoft.Json;

namespace DNClientAPI.Models {
  public class DNRelatedItemDetails {
    /// <summary>
    /// Related Item Number
    /// </summary>
    [JsonProperty("related_item_number")]
    public long RelatedItemNumber { get; set; }

    /// <summary>
    /// Related Item Name
    /// </summary>
    [JsonProperty("related_item_name")]
    public string RelatedItemName { get; set; }

    /// <summary>
    /// Relationship
    /// </summary>
    [JsonProperty("relationship")]
    public string Relationship { get; set; }

    /// <summary>
    /// LogicalGroupNumber
    /// </summary>
    [JsonProperty("logical_group_number")]
    public long LogicalGroupNumber { get; set; }

    /// <summary>
    /// Related Items
    /// </summary>
    [JsonProperty("relateditems")]
    public bool RelatedItems { get; set; }

    /// <summary>
    /// Upselling Items
    /// </summary>
    [JsonProperty("upsellingitems")]
    public bool UpsellingItems { get; set; }
  }
}
