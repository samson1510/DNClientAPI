
using Newtonsoft.Json;

namespace DNClientAPI.Models {

  /// <summary>
  /// Contact Details
  /// </summary>

  public class DNContactDetails : DNContactDetail {

    /// <summary>
    /// Contact Details Parent Type
    /// </summary>
    public enum ParentClassType {

      /// <summary>
      /// Supplier
      /// </summary>
      SUPP,

      /// <summary>
      /// Customer
      /// </summary>
      CUST,

      /// <summary>
      /// User
      /// </summary>
      USER,

      /// <summary>
      /// Company
      /// </summary>
      COMP,

      /// <summary>
      /// Shop
      /// </summary>
      SHOP
    }

    #region Properties

    /// <summary>
    /// Parent Class Type
    /// </summary>
    [JsonProperty("ParentType")]
    public ParentClassType ParentType { get; set; }
    /// <summary>
    /// Returns the first phone number found in the list of contact details
    /// </summary>
    //[JsonProperty("telephone_number")]
    //public string Telephone { get; set; }

    /// <summary>
    /// Returns the first fax number found in the list of contact details
    /// </summary>
    //[JsonProperty("fax")]
    //public string Fax { get; set; }

    /// <summary>
    /// Returns the first website found in the list of contact details
    /// </summary>
    //[JsonProperty("website")]
    //public string Website { get; set; }

    /// <summary>
    /// Returns the first mifare found in the list of contact details
    /// </summary>
    [JsonProperty("mifare")]
    public string Mifare { get; set; }

    /// <summary>
    /// Returns the first facebook ID found in the list of contact details
    /// </summary>
    [JsonProperty("facebook_id")]
    public string FacebookId { get; set; }

    /// <summary>
    /// Returns the first push found in the list of contact details
    /// </summary>
    [JsonProperty("push")]
    public string Push { get; set; }

    /// <summary>
    /// Returns the first customer ID found in the list of contact details
    /// </summary>
    [JsonProperty("customer_id")]
    public string CustId { get; set; }

    ///// <summary>
    ///// Returns the first phone number found in the list of contact details
    ///// </summary>
    //[JsonProperty("mobile_number")]
    //public string MobileNumber { get; set; }


    #endregion Properties


  }
}