using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace DNClientAPI.Models {
  public class DNShop : BaseModel {

    public DNShop() {
      ContactDetails = new DNContactDetails();
      Profile = new DNShopProfile();
      CorrespondanceAddress = new DNAddress();
      ContactDetails = new DNContactDetails();
      InvoiceCustomer = new DNCustomer();
    }

    private bool? _vatfree;

    [JsonProperty("filter_codes")]
    public IList<string> FilterCodes { get; set; }

    [JsonProperty("shop_number")]
    public long ShopNumber { get; set; }
    [JsonProperty("name")]
    public string Shopname { get; set; }
    [JsonProperty("number")]
    public string PinCode { get; set; }  //check if need to remove
    [JsonProperty("city")]
    public string City { get; set; } //check if need to remove
    [JsonProperty("country")]
    public string Cuntry { get; set; }
    [JsonProperty("correspondence_address")]
    public DNAddress CorrespondanceAddress { get; set; }
    [JsonProperty("address1")]
    public string Address { get; set; }
    public string ShopEMail { get; set; }
    public string ShopPhoneNumber { get; set; }
    public string ShopMobileNumber { get; set; }

    [JsonProperty("contact_details")]
    public DNContactDetails ContactDetails { get; set; }
    public double Distancefromcurrent { get; set; }
    public TimeSpan MondayStart { get; set; }
    public TimeSpan MondayEnd { get; set; }
    public TimeSpan TuesdayStart { get; set; }
    public TimeSpan TuesdayEnd { get; set; }
    public TimeSpan WednesdayStart { get; set; }
    public TimeSpan WednesdayEnd { get; set; }
    public TimeSpan ThursdayStart { get; set; }
    public TimeSpan ThursdayEnd { get; set; }
    public TimeSpan FridayStart { get; set; }
    public TimeSpan FridayEnd { get; set; }
    public TimeSpan SaturdayStart { get; set; }
    public TimeSpan SaturdayEnd { get; set; }
    public TimeSpan SundayStart { get; set; }
    public TimeSpan SundayEnd { get; set; }
    public string MonFriTime { get; set; }
    public string SaturdayTime { get; set; }
    public string SundayTime { get; set; }
    public bool IsSundayOpen { get; set; }
    public string ContactPerson { get; set; }
    public bool Select { get; set; }
    [JsonProperty("planned_gross_profit")]
    public double ShopPlannedGrossProfit { get; set; }
    [JsonProperty("customer_number_series_start")]
    public string CustomerNumberSeriesStart { get; set; }
    [JsonProperty("customer_number_series_stop")]
    public string CustomerNumberSeriesStop { get; set; }
    [JsonProperty("discount_percent")]
    public double ShopDiscount { get; set; }
    [JsonProperty("vat_free")]
    public bool VATFree { get; set; }
    [JsonProperty("global_location_number")]
    public string GlobalLocationNumber { get; set; }
    [JsonProperty("profile")]
    public DNShopProfile Profile { get; set; }
    [JsonProperty("judicial_name")]
    public string JudicialCompanyName { get; set; }
    [JsonProperty("judicial_number")]
    public string JudicialCompanyNumber { get; set; }
    [JsonProperty("company_number")]
    public string CompanyNumber { get; set; }

    [JsonProperty("check")]
    public bool select { get; set; }

        #region invoice
        [JsonProperty("iban")]
    public string IBAN { get; set; }
    [JsonProperty("swift_code")]
    public string SWIFT { get; set; }
    [JsonProperty("bank_account_number")]
    public string BankAccountNumber { get; set; }
    [JsonProperty("surcharge_allowed")]
    public bool SurchargeAllowed { get; set; }
    [JsonProperty("minimum_surcharge_amount")]
    public double MinimumSurchargeAmount { get; set; }
    [JsonProperty("surcharge_amount")]
    public double SurchargeAmount { get; set; }
    [JsonProperty("days_of_remark")]
    public int DaysOfRemark { get; set; }
    [JsonProperty("invoice_customer")]
    public DNCustomer InvoiceCustomer { get; set; }
    [JsonProperty("invoice_notes")]
    public string InvoiceNote { get; set; }

    [JsonProperty("is_levysurcharge")]
    public bool LevySurcharge { get; set; }

    [JsonProperty("linkshop_customerno")]
    public long Linkshopcustomerno { get; set; }

    [JsonProperty("linkshop_customername")]
    public string Linkshopcustomername { get; set; }
    #endregion


    [JsonProperty("isusershop")]
    public bool IsuserShop {
      get; set;
    }
    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }
  }


  public class Sortment_FilterCode : BaseModel {

    public bool select { get; set; }
    [JsonProperty("item_filter_code")]
    public string ItemFilterCode { get; set; }

    [JsonProperty("item_filter_name")]
    public string ItemFilterName { get; set; }

    [JsonProperty("total_filtered_records")]
    public int TotalFilteredRecords { get; set; }

    [JsonProperty("total_records")]
    public int TotalRecords { get; set; }
  }

}
