using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using DNClientAPI.Models;
using DataNova.Common;
using DNClientAPI.Globalization;


namespace XRETAIL.ViewModels {
  public enum DNUserCredentialValidatation {
    NONE, MOBILEEMPTY, PASSWORDEMPTY, VALID, MOBILEINVALID, PASSWORDINVALID, USERIDEMPTY, INVALIDOPERATOR, EMAILEMPTY, EMAILINVALID, USERALREADYEXISTS, NOINTERNET
  }
  public abstract class DNUserViewModel:BaseViewModel {
    protected bool _areCredentialsInvalid;
    protected User _user;
    protected string _stripcardid = "0";
    protected string _userLanguagePreference;
    protected string _mobilenumberEntry;
    protected string _emailEntry;
    protected string _passwordEntry;
    protected string _newpassword;
    protected string _reenterpassword;
    protected string _oldPassword;
    protected string _useridEntry;
    protected bool _fromOtpPage = false;
    protected DNCustimerLoginType _loginIdType;
    public DNUserViewModel() {
      AreCredentialsInvalid = false;
      _user = new User();
    }
    private bool _isnewrequest = false;
    public bool Isnewrequest {
      get => _isnewrequest;
      set {
        if(value == _isnewrequest)
          return;
        _isnewrequest = value;
        OnPropertyChanged(nameof(Isnewrequest));
      }
    }
    public string PasswordEntry {
      get => _passwordEntry;
      set {
        if(value == _passwordEntry)
          return;
        _passwordEntry = value;
        OnPropertyChanged(nameof(PasswordEntry));
      }
    }
    public string Verified {
      get => _user.Verified;
      set {
        if(value == _user.Verified)
          return;
        _user.Verified = value;
        OnPropertyChanged(nameof(Verified));
      }
    }
    public string ReEnterPasswordEntry {
      get => _reenterpassword;
      set {
        if(value == _reenterpassword)
          return;
        _reenterpassword = value;
        OnPropertyChanged(nameof(ReEnterPasswordEntry));
      }
    }
    public string OldPassword {
      get => _oldPassword;
      set {
        if(value == _oldPassword)
          return;
        _oldPassword = value;
        OnPropertyChanged(nameof(OldPassword));
      }
    }
    public string MobileNumberEntry {
      get => _mobilenumberEntry;
      set {
        if(value == _mobilenumberEntry)
          return;
        _mobilenumberEntry = value;
        OnPropertyChanged(nameof(MobileNumberEntry));
      }
    }
    public string UserIdEntry {
      get => _useridEntry;
      set {
        if(value == _useridEntry)
          return;
        _useridEntry = value;
        OnPropertyChanged(nameof(UserIdEntry));
      }
    }

    public string UserName {
      get => _user.UserName;
      set {
        if(value == _user.UserName)
          return;
        _user.UserName = value;
        OnPropertyChanged(nameof(UserName));
      }
    }
    public string NewPassword {
      get => _newpassword;
      set {
        if(value == _newpassword)
          return;
        _newpassword = value;
        OnPropertyChanged(nameof(NewPassword));
      }
    }
    public string Password {
      get => _user.Password;
      set {
        if(value == _user.Password)
          return;
        _user.Password = value;
        OnPropertyChanged(nameof(Password));
      }
    }
    public string MobileNumber {
      get => _user.MobileNumber;
      set {
        if(value == _user.MobileNumber)
          return;
        _user.MobileNumber = value;
        OnPropertyChanged(nameof(MobileNumber));
      }
    }
    public bool AreCredentialsInvalid {
      get => _areCredentialsInvalid;
      set {
        if(value == _areCredentialsInvalid)
          return;
        _areCredentialsInvalid = value;
        OnPropertyChanged(nameof(AreCredentialsInvalid));
      }
    }
    public string UserNumber {
      get => _user.UserId;
      set {
        if(value == _user.UserId)
          return;
        _user.UserId = value;
        OnPropertyChanged(nameof(UserNumber));
      }
    }
    public Nullable<DateTime> DateOfBirth {
      get => _user.DateOfBirth;
      set {
        if(value == _user.DateOfBirth)
          return;
        _user.DateOfBirth = value;
        OnPropertyChanged(nameof(DateOfBirth));
      }
    }
    public string Email {
      get => _user.Email;
      set {
        if(value == _user.Email)
          return;
        _user.Email = value;
        OnPropertyChanged(nameof(Email));
      }
    }
    public string EmailEntry {
      get => _emailEntry;
      set {
        if(value == _emailEntry)
          return;
        _emailEntry = value;
        OnPropertyChanged(nameof(EmailEntry));
      }
    }
    public string Gender {
      get => _user.Gender;
      set {
        if(value == _user.Gender)
          return;
        _user.Gender = value;
        OnPropertyChanged(nameof(Gender));
      }
    }
    public string StripCardId {
      get {
        return _stripcardid;
      }
      set {
        if(_stripcardid != value) {
          _stripcardid = value;
          OnPropertyChanged("StripCardId");
        }
      }
    }
    public string UserLanguagePreference {
      get => _user.UserLanguage;
      set {
        if(_user.UserLanguage != null) {
          if(value == _user.UserLanguage)
            return;
          _user.UserLanguage = value;
        } else {
          _user.UserLanguage = value;
        }
        OnPropertyChanged(nameof(UserLanguagePreference));
        DNLanguageType dNLanguageType;
        Enum.TryParse(UserLanguagePreference,true,out dNLanguageType);
        DNMultiLanguage.Language = dNLanguageType;
      }
    }
    public DNUserCredentialValidatation CredentialValidation {
      get; set;
    }
    public async Task<User> GetUserNumber(string mobilenumber,string email) {
      User user = null;
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/customers/?mobile={0}&email={1}",mobilenumber,email);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject[]>(streamReader.ReadToEnd());
            foreach(JObject property in response) {
              foreach(JProperty _jproperty in property.Value<JToken>()) {
                switch(_jproperty.Name) {
                  case "customer_number":
                    UserNumber = _jproperty.Value.ToString();
                    break;
                }
              }
            }
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {

      }
      return await Task.FromResult(user);
    }
    protected virtual async Task<User> UserAuthenticated(string mobilenumber,string userid,string password) {
      return await Task.FromResult<User>(null);
    }
    public virtual async Task<bool> SaveUserAsync(DNLanguageType dNLanguageType = DNLanguageType.Blank) {
      try {
        this.IsBusy = true;
        int langvalue;
        if(dNLanguageType == DNLanguageType.Blank) {
          langvalue = (int)DNLanguageType.Norwegian_Bokmal;
        } else {
          langvalue = (int)dNLanguageType;
        }
        string url = DNGlobalProperties.Current.ERPAPIAddress + "/customers/" + UserNumber;
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);
        string customer_gender = "";
        if(Gender.ToLower() == DNMultiLanguage.GetMessage("male").ToLower()) {
          customer_gender = "M";
        } else if(Gender.ToLower() == DNMultiLanguage.GetMessage("female").ToLower()) {
          customer_gender = "F";
        }
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            name = UserName,
            customer_number = UserNumber,
            sex = customer_gender,
            language = langvalue
          },new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JArray;
            return await Task.FromResult(true);
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(false);
    }
    public virtual async Task<bool> UpdatePassword() {
      try {
        this.IsBusy = true;

        string url = DNGlobalProperties.Current.ERPAPIAddress + "/customers/password";
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);

        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            old_password = Password,
            customer_number = UserNumber,
            new_password = NewPassword
          },new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JArray;
            return await Task.FromResult(true);
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(false);
    }
    public virtual async Task<ObservableCollection<DNUserViewModel>> TodaysLoggedInPerOperator(string OperatorNo) {
      ObservableCollection<DNUserViewModel> _loggedinUsers = new ObservableCollection<DNUserViewModel>();
      try {
        this.IsBusy = true;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + string.Format(@"/users/todaysloggedin/{0}",OperatorNo));
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(true)
          if(httpResponse.StatusCode == HttpStatusCode.OK) {
            using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
              var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JArray;

              foreach(var loggedinuserobj in response) {
                foreach(JProperty property in loggedinuserobj.Values<JToken>()) {
                  switch(property.Name.ToLower()) {
                    case "user_number":
                      this.UserNumber = property.Value.ToSafeString();
                      break;
                    case "name":
                      this.UserName = property.Value.ToSafeString();
                      break;
                    case "language":
                      switch(property.Value.ToInt()) {
                        case 0:
                          this.UserLanguagePreference = DNLanguageType.Norwegian_Bokmal.ToSafeString();
                          break;
                        case 1:
                          this.UserLanguagePreference = DNLanguageType.English.ToSafeString();
                          break;
                        case 2:
                          this.UserLanguagePreference = DNLanguageType.Swedish.ToSafeString();
                          break;
                        case 3:
                          this.UserLanguagePreference = DNLanguageType.Danish.ToSafeString();
                          break;
                        case 4:
                          this.UserLanguagePreference = DNLanguageType.German.ToSafeString();
                          break;
                        case 5:
                          this.UserLanguagePreference = DNLanguageType.Finnish.ToSafeString();
                          break;
                        default:
                          this.UserLanguagePreference = DNLanguageType.Norwegian_Bokmal.ToSafeString();
                          break;
                      }
                      break;
                  }
                }
                _loggedinUsers.Add(this);
              }
            }
          }
      } catch(Exception ex) {
        string message = ex.Message;
        return await Task.FromResult(_loggedinUsers);
      } finally {
        this.IsBusy = false;
      }
      return await Task.FromResult(_loggedinUsers);
    }
  }
  public class DNCustomerViewModel:DNUserViewModel {
    public ObservableCollection<DNCustomerCategory> CustomerCategory {
      get; set;
    }
    private ObservableCollection<DNCustomer> _customers;
    public DNCustomerViewModel() : base() {
      _customers = new ObservableCollection<DNCustomer>();
    }
    public ObservableCollection<DNCustomer> Customers {
      get {
        return _customers;
      }
      set {
        if(_customers != value) {
          _customers = value;
          OnPropertyChanged("Customers");
        }
      }
    }
    public DNCustimerLoginType CustomerLoginType {
      get {
        return _loginIdType;
      }
      set {
        _loginIdType = value;
      }
    }
    protected virtual async Task<User> UserForgotDetailOtpGenerate(string customerMobileNo,string customerEmailId) {
      User user = null;
      string customertype = "email";
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        EmailAddressAttribute e = new EmailAddressAttribute();
        if(e.IsValid(customerEmailId)) {
          customertype = "email";
        } else {
          customertype = "sms";
        }
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + "/customers/{0}/otpforgotpassword?otp_delivery_method=" + customertype,customerEmailId);
        //?otp_delivery_method=mobile
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            if(response.Count > 0) {
              user = new User();
              CredentialValidation = DNUserCredentialValidatation.VALID;
              foreach(JProperty property in response.Values<JToken>()) {
                switch(property.Name) {
                  case "message":
                    user.Message = property.Value.ToString();
                    break;
                }
              }
              CredentialValidation = DNUserCredentialValidatation.VALID;
            } else {
              user = null;
            }
          }
        }
        return await Task.FromResult(user);
      } catch(Exception ex) {
        string ss = ex.Message;

        user = null;
        return await Task.FromResult(user);
      }
    }
    protected virtual async Task<User> UserOtpVerification(string customeremailId,string optNo) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + "/customers/{0}/otpforgotpasswordverify",customeremailId);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);

        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            otp_code = optNo.ToSafeString()
          },new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();

        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            if(response.Count > 0) {
              user = new User();
              CredentialValidation = DNUserCredentialValidatation.VALID;
              foreach(JProperty property in response.Values<JToken>()) {
                switch(property.Name) {
                  case "identifier":
                    user.Identifier = property.Value.ToString();
                    break;
                }
              }
              CredentialValidation = DNUserCredentialValidatation.VALID;
            } else {
              user = null;
            }
          }
        }
        return await Task.FromResult(user);
      } catch(Exception ex) {
        string ss = ex.Message;

        user = null;
        return await Task.FromResult(user);
      }
    }
    protected virtual async Task<User> UserOtpLoginVerification(string customeremailId,string optNo) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + "/customers/{0}/otp",customeremailId);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            otp_code = optNo.ToSafeString()
          },new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            if(response.Count > 0) {
              user = new User();
              CredentialValidation = DNUserCredentialValidatation.VALID;
              foreach(JProperty property in response.Values<JToken>()) {
                switch(property.Name) {
                  case "identifier":
                    user.Identifier = property.Value.ToString();
                    break;
                }
              }
              CredentialValidation = DNUserCredentialValidatation.VALID;
            } else {
              user = null;
            }
          }
        }
        return await Task.FromResult(user);
      } catch(Exception ex) {
        string ss = ex.Message;
        user = null;
        return await Task.FromResult(user);
      }
    }
    protected virtual async Task<User> OTPForUSerVerification(string customerNo,string OTPType) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + "/customers/{0}/otp?otp_delivery_method=" + OTPType,customerNo);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            if(response.Count > 0) {
              user = new User();
              CredentialValidation = DNUserCredentialValidatation.VALID;
              foreach(JProperty property in response.Values<JToken>()) {
                switch(property.Name) {
                  case "message":
                    user.Message = property.Value.ToString();
                    break;
                }
              }
              CredentialValidation = DNUserCredentialValidatation.VALID;
            } else {
              user = null;
            }
          }
        }
        return await Task.FromResult(user);
      } catch(Exception ex) {
        string ss = ex.Message;
        user = null;
        return await Task.FromResult(user);
      }
    }
    protected virtual async Task<User> UserResetPasswordVerify(string customeremailId,string _identifier,string changePassword) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + "/customers/{0}/resetpassword",customeremailId);
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);

        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            identifier = _identifier.ToSafeString(),
            new_password = changePassword.ToSafeString()
          },new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            if(response.Count > 0) {
              user = new User();
              CredentialValidation = DNUserCredentialValidatation.VALID;
              foreach(JProperty property in response.Values<JToken>()) {
                switch(property.Name) {
                  case "message":
                    user.Message = property.Value.ToString();
                    break;
                }
              }
              CredentialValidation = DNUserCredentialValidatation.VALID;
            } else {
              user = null;
            }
          }
        }
        return await Task.FromResult(user);
      } catch(Exception ex) {
        string ss = ex.Message;
        user = null;
        return await Task.FromResult(user);
      }
    }
    protected virtual async Task<User> UserloginResetPasswordVerify(string customerno,string changePassword,string oldpassword) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        string url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + "/customers/password");
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);

        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            customer_number = customerno,
            old_password = oldpassword.ToSafeString(),
            new_password = changePassword.ToSafeString()
          },new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            if(response.Count > 0) {
              user = new User();
              CredentialValidation = DNUserCredentialValidatation.VALID;
              foreach(JProperty property in response.Values<JToken>()) {
                switch(property.Name) {
                  case "customer_number":
                    if(property.Value.ToString() == customerno) {
                      user.Message = "Password changed successfully";
                    }
                    break;
                }
              }
              CredentialValidation = DNUserCredentialValidatation.VALID;
            } else {
              user = null;
            }
          }
        }
        return await Task.FromResult(user);
      } catch(Exception ex) {
        string ss = ex.Message;
        user = null;
        return await Task.FromResult(user);
      }
    }
    protected virtual async Task<User> UserProfileDetail(string customerNo) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        string url = DNGlobalProperties.Current.ERPAPIAddress + "/customers/" + customerNo;
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
        var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            if(response.Count > 0) {
              user = new User();
              CredentialValidation = DNUserCredentialValidatation.VALID;
              foreach(JProperty property in response.Values<JToken>()) {
                switch(property.Name) {
                  case "customer_number":
                    user.UserId = property.Value.ToString();
                    break;
                  case "name":
                    user.UserName = property.Value.ToString().ToUpper();
                    OnPropertyChanged(nameof(UserName));
                    break;
                  case "dob":
                    //user.DateOfBirth = property.Value.ToString().ToDateTime();
                    break;
                  case "sex":
                    user.Gender = property.Value.ToString();
                    break;
                  case "password":
                    //user.Password = property.Value.ToString();
                    break;
                  case "language":
                    user.UserLanguage = ((DNLanguageType)property.Value.ToString().ToInt()).ToString().Replace("_"," ");
                    break;
                  case "card":
                    try {
                      foreach(JObject obj in property.Values<JToken>()) {
                        foreach(JProperty peroprty in obj.Values<JToken>()) {
                          if(peroprty.Name == "card_number") {
                            StripCardId = peroprty.Value.ToString();
                            break;
                          }
                        }
                      }
                    } catch(Exception ex) {
                      string ss = ex.Message;
                    }
                    break;
                  case "mobile_number":
                    user.MobileNumber = property.Value.ToString();
                    break;
                  case "email":
                    user.Email = property.Value.ToString();
                    break;
                }
              }
              CredentialValidation = DNUserCredentialValidatation.VALID;
            } else {
              user = null;
            }
          }
        }
        return await Task.FromResult(user);
      } catch(Exception ex) {
        string ss = ex.Message;
        user = null;
        return await Task.FromResult(user);
      }
    }
    protected override async Task<User> UserAuthenticated(string mobilenumber,string userid,string password) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;
        if(string.IsNullOrEmpty(mobilenumber) && this.CustomerLoginType == DNCustimerLoginType.Mobile) {
          user = null;
          CredentialValidation = DNUserCredentialValidatation.MOBILEEMPTY;
          return await Task.FromResult(user);
        } else if(string.IsNullOrEmpty(mobilenumber) && this.CustomerLoginType == DNCustimerLoginType.Email) {
          user = null;
          CredentialValidation = DNUserCredentialValidatation.EMAILEMPTY;
          return await Task.FromResult(user);
        }
        if(string.IsNullOrEmpty(password)) {
          user = null;
          CredentialValidation = DNUserCredentialValidatation.PASSWORDEMPTY;
          return await Task.FromResult(user);
        }
        string url = DNGlobalProperties.Current.ERPAPIAddress + "/customers/authorize";
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url,false);
        if(httpWebRequest == null) {
          return await Task.FromResult(user);
        }
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            user_id = mobilenumber,
            @password = password
          },new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
          var userobj = response.Value<JToken>("customer");
          var userproperties = userobj.Values<JToken>();
          if(userproperties.Count() > 0) {
            user = new User();
            user.UserId = userid;
            user.Password = password;
            user.MobileNumber = mobilenumber;
            CredentialValidation = DNUserCredentialValidatation.VALID;
            foreach(JProperty property in userobj.Values<JToken>()) {
              switch(property.Name) {
                case "customer_number":
                  user.UserId = property.Value.ToString();
                  break;
                case "name":
                  user.UserName = property.Value.ToString().ToUpper();
                  OnPropertyChanged(nameof(UserName));
                  break;
                case "dob":
                  //user.DateOfBirth = property.Value.ToString().ToDateTime();
                  break;
                case "sex":
                  user.Gender = property.Value.ToString();
                  break;
                case "password":
                  //user.Password = property.Value.ToString();
                  break;
                case "language":
                  user.UserLanguage = ((DNLanguageType)property.Value.ToString().ToInt()).ToString().Replace("_"," ");
                  break;
                case "card":
                  try {
                    foreach(JObject obj in property.Values<JToken>()) {
                      foreach(JProperty peroprty in obj.Values<JToken>()) {
                        if(peroprty.Name == "card_number") {
                          StripCardId = peroprty.Value.ToString();
                          break;
                        }
                      }
                    }
                  } catch(Exception ex) {
                    string ss = ex.Message;
                  }
                  break;
                case "mobile_number":
                  user.MobileNumber = property.Value.ToString();
                  break;
                case "email":
                  user.Email = property.Value.ToString();
                  break;
                case "is_verified":
                  user.Verified = property.Value.ToString();
                  break;
              }
            }
            if(password == user.Password) {
              CredentialValidation = DNUserCredentialValidatation.VALID;
              try {
                if(!string.IsNullOrEmpty(user.MobileNumber)) {
                  //CrossFirebasePushNotification.Current.Subscribe(DNEngine.Current.GetViewModel<DNAuthenticationViewModel>().AppDetails.APIMerchentId + user.MobileNumber + PushNotificationMessageType.Receipt.ToString());
                }
              } catch(Exception ex) {
              }
              return await Task.FromResult(user);
            } else {
              user = null;
              CredentialValidation = DNUserCredentialValidatation.PASSWORDINVALID;
              return await Task.FromResult(user);
            }
          } else {
            if(this.CustomerLoginType == DNCustimerLoginType.Mobile) {
              CredentialValidation = DNUserCredentialValidatation.MOBILEINVALID;
            } else if(this.CustomerLoginType == DNCustimerLoginType.Email) {
              CredentialValidation = DNUserCredentialValidatation.EMAILINVALID;
            }
            user = null;
            return await Task.FromResult(user);
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
        if(this.CustomerLoginType == DNCustimerLoginType.Mobile) {
          CredentialValidation = DNUserCredentialValidatation.MOBILEINVALID;
        } else if(this.CustomerLoginType == DNCustimerLoginType.Email) {
          CredentialValidation = DNUserCredentialValidatation.EMAILINVALID;
        }
        user = null;
        return await Task.FromResult(user);
      }
    }
    protected virtual async Task<User> UserAuthenticatedWeb(string mobilenumber,string userid,string password) {
      User user = null;
      try {
        CredentialValidation = DNUserCredentialValidatation.NONE;

        if(string.IsNullOrEmpty(mobilenumber) && this.CustomerLoginType == DNCustimerLoginType.Mobile) {
          user = null;
          CredentialValidation = DNUserCredentialValidatation.MOBILEEMPTY;
          return await Task.FromResult(user);
        } else if(string.IsNullOrEmpty(mobilenumber) && this.CustomerLoginType == DNCustimerLoginType.Email) {
          user = null;
          CredentialValidation = DNUserCredentialValidatation.EMAILEMPTY;
          return await Task.FromResult(user);
        }
        if(string.IsNullOrEmpty(password)) {
          user = null;
          CredentialValidation = DNUserCredentialValidatation.PASSWORDEMPTY;
          return await Task.FromResult(user);
        }
        string url = DNGlobalProperties.Current.ERPAPIAddress + "/customers/authorize";
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url,false);
        if(httpWebRequest == null) {
          return await Task.FromResult(user);
        }
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            user_id = mobilenumber,
            @password = password
          },new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
          var userobj = response.Value<JToken>("customer");
          var userproperties = userobj.Values<JToken>();
          if(userproperties.Count() > 0) {
            user = new User();
            user.UserId = userid;
            user.Password = password;
            user.MobileNumber = mobilenumber;
            CredentialValidation = DNUserCredentialValidatation.VALID;
            foreach(JProperty property in userobj.Values<JToken>()) {
              switch(property.Name) {
                case "customer_number":
                  user.UserId = property.Value.ToString();
                  break;
                case "name":
                  user.UserName = property.Value.ToString().ToUpper();
                  OnPropertyChanged(nameof(UserName));
                  break;
                case "dob":
                  //user.DateOfBirth = property.Value.ToString().ToDateTime();
                  break;
                case "sex":
                  user.Gender = property.Value.ToString();
                  break;
                case "password":
                  //user.Password = property.Value.ToString();
                  break;
                case "language":
                  user.UserLanguage = ((DNLanguageType)property.Value.ToString().ToInt()).ToString().Replace("_"," ");
                  break;
                case "card":
                  try {
                    foreach(JObject obj in property.Values<JToken>()) {
                      foreach(JProperty peroprty in obj.Values<JToken>()) {
                        if(peroprty.Name == "card_number") {
                          StripCardId = peroprty.Value.ToString();
                          break;
                        }
                      }
                    }
                  } catch(Exception ex) {
                    string ss = ex.Message;
                  }
                  break;
                case "mobile_number":
                  user.MobileNumber = property.Value.ToString();
                  break;
                case "email":
                  user.Email = property.Value.ToString();
                  break;

              }
            }
            if(password == user.Password) {
              CredentialValidation = DNUserCredentialValidatation.VALID;
              mobilenumber = null;
              try {
                if(!string.IsNullOrEmpty(mobilenumber)) {
                  //CrossFirebasePushNotification.Current.Subscribe(DNEngine.Current.GetViewModel<DNAuthenticationViewModel>().AppDetails.APIMerchentId + mobilenumber + PushNotificationMessageType.Receipt.ToString());
                }
              } catch(Exception ex) {
              }
              return await Task.FromResult(user);
            } else {
              user = null;
              CredentialValidation = DNUserCredentialValidatation.PASSWORDINVALID;
              return await Task.FromResult(user);
            }
          } else {
            if(this.CustomerLoginType == DNCustimerLoginType.Mobile) {
              CredentialValidation = DNUserCredentialValidatation.MOBILEINVALID;
            } else if(this.CustomerLoginType == DNCustimerLoginType.Email) {
              CredentialValidation = DNUserCredentialValidatation.EMAILINVALID;
            }
            user = null;
            return await Task.FromResult(user);
          }
        }
      } catch(Exception ex) {
        string ss = ex.Message;
        if(this.CustomerLoginType == DNCustimerLoginType.Mobile) {
          CredentialValidation = DNUserCredentialValidatation.MOBILEINVALID;
        } else if(this.CustomerLoginType == DNCustimerLoginType.Email) {
          CredentialValidation = DNUserCredentialValidatation.EMAILINVALID;
        }
        user = null;
        return await Task.FromResult(user);
      }
    }
    public override async Task<bool> SaveUserAsync(DNLanguageType dNLanguageType = DNLanguageType.Blank) {
      try {
        this.IsBusy = true;
        string url = DNGlobalProperties.Current.ERPAPIAddress + "/back_office/savecustomer/";
        var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST",url);
        if(httpWebRequest == null) {
          return await Task.FromResult(false);
        }
        string loginid = "";
        if(CustomerLoginType == DNCustimerLoginType.Mobile)
          loginid = MobileNumber;
        else if(CustomerLoginType == DNCustimerLoginType.Email)
          loginid = Email;
        using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
          string json = JsonConvert.SerializeObject(new {
            customer_number = (Isnewrequest ? "0" : UserNumber),
            name = UserName,
            dob = (DateOfBirth != null ? DateOfBirth.Value.ToUnixDateTime() : -2209008070000),
            email = Email,
            mobile_number = MobileNumber,
            login_id = loginid,
            password = Password,
            sex = Gender
          },new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
          var userobj = response.Value<JToken>("customer");
          if(userobj == null) {
            if(Isnewrequest) {
              return await Task.FromResult(true);

            } else {
              return await Task.FromResult(false);
            }
          } else {
            return await Task.FromResult(true);
          }
        }
      } catch(WebException ex) {
        string ss = ex.Message;
        if(ex.Response != null) {
          using(var errorResponse = (HttpWebResponse)ex.Response) {
            using(var streamReader = new StreamReader(errorResponse.GetResponseStream())) {
              var response = JsonConvert.DeserializeObject(streamReader.ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
              if(response != null) {
                var responsevalue = response.Value<JToken>("message").Value<string>();
                if(Regex.Replace(responsevalue,@"\s","").ToLower() == "customeralreadyexists") {
                  AreCredentialsInvalid = true;
                  CredentialValidation = DNUserCredentialValidatation.USERALREADYEXISTS;
                }
              }
            }
          }
        }
        return await Task.FromResult(false);
      } finally {
        this.IsBusy = false;
      }
    }

    public async Task<List<DNCustomer>> GetCustomerListAsync(int pageindex,int PageSize) {
      string url = "";
      List<DNCustomer> lstCustomer = new List<DNCustomer>();
      url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/customers/?page={0}&page_size={1}",pageindex,PageSize);
      var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
      var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();

      if(httpResponse.StatusCode == HttpStatusCode.OK) {
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          string customerListJson = streamReader.ReadToEnd();
          var customers = JsonConvert.DeserializeObject<List<DNCustomer>>(customerListJson);
          Customers = new ObservableCollection<DNCustomer>(customers);
        }
      }
      return lstCustomer;
    }
    public override async Task<bool> LoadAsync() {
      string url = "";
      int pageIndex = 1;
      int pageSize = 50;
      List<DNCustomer> lstCustomer = new List<DNCustomer>();
      url = string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/customers/?page={0}&page_size={1}",pageIndex,pageSize);
      var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("GET",url);
      var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
      if(httpResponse.StatusCode == HttpStatusCode.OK) {
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          string customerListJson = streamReader.ReadToEnd();
          var customers = JsonConvert.DeserializeObject<List<DNCustomer>>(customerListJson);
          Customers = new ObservableCollection<DNCustomer>(customers);
        }
      }
      return true;
    }
    public override async Task<bool> LoadAsync(APIFilter filter) {
      var httpResponse = await DNAPIHandler.Current.PostResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getfilteredcustomers/"),filter.FilterToJSON());
      if(httpResponse.StatusCode == HttpStatusCode.OK) {
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          try {
            string customerListJson = streamReader.ReadToEnd();
            var customers = JsonConvert.DeserializeObject<List<DNCustomer>>(customerListJson);
            Customers = new ObservableCollection<DNCustomer>(customers);
          } catch(Exception ex) {
            var x = ex.Message;
          }
        }
      }
      return true;
    }
    public override async Task<BaseModel> LoadAsync(object CustomerNumber) {
      return await DNAPIHandler.Current.GetResponseObjectAsync<DNCustomer>(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/customers/{0}",CustomerNumber));
    }
    public async Task<bool> LoadByTypeAsync(string customertype) {
      Customers = new ObservableCollection<DNCustomer>(await DNAPIHandler.Current.GetResponseObjectAsync<List<DNCustomer>>(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/customers/{0}/",customertype)));
      return true;
    }
    public async Task<List<DNTicketDetail>> LoadActiveSeasonCardsAsync(string CustomerNumber) {
      return await DNAPIHandler.Current.GetResponseObjectAsync<List<DNTicketDetail>>(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getallseasontickets/?customerno={0}",CustomerNumber));
    }
    public async Task<bool> LoadCustomerCategoryAsync(APIFilter filter) {
      bool _isvalue = false;
      if(this.IsLoaded)
        return await Task.FromResult(_isvalue);
      try {
        HttpWebResponse httpResponse = await DNAPIHandler.Current.PostResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/getfilteredcustomercategories/"),filter.FilterToJSON());
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var lstCustomerCategory = JsonConvert.DeserializeObject<List<DNCustomerCategory>>(streamReader.ReadToEnd());
            if(lstCustomerCategory != null) {
              CustomerCategory = new ObservableCollection<DNCustomerCategory>(lstCustomerCategory);
              IsLoaded = true;
              _isvalue = true;
            }
          }
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      }
      return await Task.FromResult(_isvalue);
    }

    public override async Task<DNActionResult> SaveAsync(BaseModel model) {
      DNCustomer _customer = (DNCustomer)model;
      var result = new DNActionResult();
      result.ValidationErrors = Validate(_customer);
      result.Notification = result.ValidationErrors.Count == 0 ? NotificationType.success : NotificationType.warning;
      if(result.Notification == NotificationType.success) {
        result.Action = DNActionCommand.Save;
        try {
          string json = JsonConvert.SerializeObject(_customer,new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented,NullValueHandling = NullValueHandling.Ignore });
          var httpResponse = await DNAPIHandler.Current.PostResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/savecustomer/"),json);
          if(httpResponse.StatusCode != HttpStatusCode.OK) {
            result.Notification = NotificationType.error;
          }
          if(httpResponse.StatusCode == HttpStatusCode.OK) {
            using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
              result.ReturnModel = JsonConvert.DeserializeObject<DNCustomer>(streamReader.ReadToEnd());
            }
          } else {
            result.Notification = NotificationType.error;
          }
        } catch(Exception exc) {
          string error = exc.Message + exc.StackTrace;
          result.Notification = NotificationType.error;
        }
      }
      return await Task.FromResult(result);
    }
    public async Task<NotificationType> SaveWebshopCustomer(DNCustomer customer) {
      string json = JsonConvert.SerializeObject(customer);
      string url = DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/savecustomerwebshop/";
      HttpWebResponse httpResponse = null;
      try {
        httpResponse = await DNAPIHandler.Current.PostResponseAsync(url,json);
      } catch(WebException e) {
        return NotificationType.error;
      }
      if(httpResponse.StatusCode == HttpStatusCode.OK) {
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          string val = streamReader.ReadToEnd();
          bool success = val.ToBool();
          return success ? NotificationType.success : NotificationType.warning;
        }
      }
      return NotificationType.error;
    }
    public override async Task<DNActionResult> DeleteAsync(BaseModel model) {
      DNCustomer _customer = (DNCustomer)model;
      var result = new DNActionResult();
      if(_customer.CustomerNumber == 0) {
        result.ValidationErrors.Add("CustomerNumber","customerdoesnotexist");
      }
      result.Notification = result.ValidationErrors.Count == 0 ? NotificationType.success : NotificationType.warning;
      if(result.Notification == NotificationType.success) {
        result.Action = DNActionCommand.Delete;
        try {
          try {
            var httpResponse = await DNAPIHandler.Current.GetResponseAsync(string.Format(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/customer/{0}",_customer.CustomerNumber),"DELETE");
            if(httpResponse.StatusCode == HttpStatusCode.OK) {
              result.Notification = NotificationType.success;
            } else {
              result.Notification = NotificationType.error;
            }
          } catch(WebException ex) {
            using(var streamReader = new StreamReader(ex.Response.GetResponseStream())) {
              DNResponse Errorresponseobj = JsonConvert.DeserializeObject<DNResponse>(streamReader.ReadToEnd());
              result.ValidationErrors = SendErrorResponse(Errorresponseobj);
              result.Notification = result.ValidationErrors.Count == 0 ? NotificationType.success : NotificationType.warning;
            }
          }
        } catch(Exception exc) {
          string error = exc.Message + exc.StackTrace;
          result.Notification = NotificationType.error;
        }
      }
      return await Task.FromResult(result);
    }

    public Dictionary<string,string> SendErrorResponse(DNResponse Errorresponseobj) {
      Dictionary<string,string> Error = new Dictionary<string,string>();
      if(Errorresponseobj.Code == "40016") {
        Error.Add("Id","customerlinkedtoshop");
      }
      if(Errorresponseobj.Code == "40017") {
        Error.Add("Id","customerlinkedtosupplier");
      }
      if(Errorresponseobj.Code == "40018") {
        Error.Add("Id","customerlinkedtomanufacturer");
      }
      if(Errorresponseobj.Code == "40019") {
        Error.Add("Id","customernotdeleted");
      }
      return Error;
    }

    public async Task<List<DNInvoiceDeliveryTypes>> GetInvoiceDeliveryTypesForCustomer(string customerType) {
      List<DNInvoiceDeliveryTypes> deliveryTypes = new List<DNInvoiceDeliveryTypes>();
      try {
        HttpWebResponse httpResponse = await DNAPIHandler.Current.GetResponseAsync(DNGlobalProperties.Current.ERPAPIAddress + @"/back_office/invoice/delivery_types" + (!string.IsNullOrEmpty(customerType) ? "?customer_type=" + customerType : ""));
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            var lsttypes = JsonConvert.DeserializeObject<List<DNInvoiceDeliveryTypes>>(streamReader.ReadToEnd());
            if(lsttypes != null) {
              deliveryTypes = lsttypes;
            }
          }
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      }
      return await Task.FromResult(deliveryTypes);
    }
  }
}
