using System;
using DataNova.Common;

namespace DNClientAPI.Models {
  public class User {
    public string MobileNumber {
      get; set;
    }
    public string UserId {
      get; set;
    }
    public string UserName {
      get; set;
    }
    public string Password {
      get; set;
    }
    public string Email {
      get; set;
    }
    public DateTime LastLoggedIn {
      get; set;
    }
    public Nullable<DateTime> DateOfBirth {
      get; set;
    }
    public string Gender {
      get; set;
    }
    public string UserLanguage {
      get; set;
    }
    public DNThemeType Theme {
      get; set;
    }

    public string Message {
      get; set;
    }

    public string Identifier {
      get; set;
    }

    public bool ShowShopNotification {
      get; set;
    }
    public bool EnableIsSundayOpen {
      get; set;
    }
    public bool EnableIsGourmetStore {
      get; set;
    }
    public bool EnableIsSnalFruit {
      get; set;
    }
    public string SelectedCity {
      get; set;
    }

    public string Verified {
      get; set;
    }

    public bool Suspended {
      get; set;
    }
    //public List<DNDropDownshop> ddBinddata {
    //  get; set;
    //}

    //public List<UsersShops> shops {
    //  get; set;
    //}
  }

  //public class UsersShops
  //{
  //  public int shop_number {
  //    get; set;
  //  }
  //  public string name {
  //    get; set;
  //  }
  //}
  public static class Constants {
    public static string Username = "Xamarin";
    public static string Password = "password";
  }
}
