using Newtonsoft.Json;
using System;
using DataNova.Common;

namespace DNClientAPI.Globalization {
  public class DNGlobalProperties {
    public static DNGlobalProperties _current;
    public static DNGlobalProperties Current {
      get {
        if (_current == null) {
          _current = new DNGlobalProperties();
        }
        return _current;
      }
      set {
        _current = value;
      }
    }
    public void Reset() {
      ImagePath = "";     
    }
    public DNGlobalProperties() {
      Reset();
    }
    public string ImagePath { get; set; }
    public string ERPAPIAddress { get; set; }
    public string ERPAPIMerchentId { get; set; }
    public string ERPAPIUserNumber { get; set; }
    public string ERPAPISecretKey { get; set; }
    public string ERPAPIUserPassword { get; set; }
    public long ShopNumber { get; set; }
    public int ProfileNumber { get; set; }
    public DNLanguageType DefaultLanguage { get; set; }
  }
}

