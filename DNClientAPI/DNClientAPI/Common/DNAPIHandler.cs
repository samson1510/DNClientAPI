using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using DNClientAPI.Globalization;

namespace DataNova.Common {
  public class DNAPIHandler {
    public string DNSupportURL = "http://portal.datanova.no/ERPSupportServerMobile//DNSupportService.svc/license";
    public static DNAPIHandler _current;
    public static DNAPIHandler Current {
      get {
        if(_current == null) {
          _current = new DNAPIHandler();
        }
        return _current;
      }
      set {
        _current = value;
      }
    }
    #region Methods
    private bool checkURL(string url) {
      bool pageExists = false;
      try {
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        pageExists = response.StatusCode == HttpStatusCode.OK;
        response.Close();
      } catch(Exception e) {
        pageExists = false;
      }
      return pageExists;
    }

    #region old API
    private string ERPOldAPIAddress = "http://test.datanova.no/testdnapiservice/RestService.svc";
    private string _token;
    public string GetToken() {
      if(!string.IsNullOrEmpty(_token)) {
        return _token;
      }
      try {
        if(string.IsNullOrEmpty(ERPOldAPIAddress) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIMerchentId) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIUserNumber) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPISecretKey))
          return _token;
        var url = ERPOldAPIAddress + "/Authenticate/merchantid=" + DNGlobalProperties.Current.ERPAPIMerchentId + "&usernumber=" + DNGlobalProperties.Current.ERPAPIUserNumber + "&secretKey=" + DNGlobalProperties.Current.ERPAPISecretKey + "&format=xml";
        if(checkURL(url)) {
          using(DNWebClient _myWebClient = new DNWebClient()) {
            byte[] res1 = _myWebClient.DownloadData(url);
            string result = System.Text.Encoding.UTF8.GetString(res1);
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(result);
            XmlNodeList xnod = xdoc.GetElementsByTagName("Api_key");
            string error = "";
            error = xdoc.GetElementsByTagName("Error").Count > 0 ? xdoc.GetElementsByTagName("Error")[0].InnerText : "";
            if(!string.IsNullOrWhiteSpace(error)) {
              return _token;
            }
            if(xnod.Count > 0) {
              if(!string.IsNullOrWhiteSpace(xnod[0].InnerText)) {
                _token = xnod[0].InnerText;
              }
            }
          }
        }
      } catch(Exception) {
      }
      return _token;
    }

    public string GetVippsStatus(string transactionId) {
      try {
       string url = DNGlobalProperties.Current.ERPAPIAddress + "/back_office/getvippsstatus/" + transactionId;
        var httpWebRequest = DNAPIHandler.Current.GetWebRequestAsync("GET", url).Result;
        httpWebRequest.ContentLength = 0;
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            string result = streamReader.ReadToEnd();
            if(!string.IsNullOrEmpty(result)) {
              var trimmedResult = result.Replace("\\", "").Replace("\"", "");
              return trimmedResult;
            }
          }
        }
      } catch(Exception e) { }
      return null;
    }

    public byte[] ConvertJSONToBytes(string json) {
      try {
        string url = ERPOldAPIAddress + "/ConvertJSONToBytes/JSON=" + json;
        if(checkURL(url)) {
          using(DNWebClient webClient = new DNWebClient()) {
            byte[] res1 = webClient.DownloadData(url);
            string result = System.Text.Encoding.UTF8.GetString(res1);
            if(!string.IsNullOrEmpty(result)) {
              XmlDocument xdoc = new XmlDocument();
              xdoc.LoadXml(result);
              return null;
            }
            return null;
          }
        }

      } catch(Exception e) { }
      return null;
    }
    #endregion
    #region new API
    private string _apikey;
    public async Task<string> GetApiKeyAsync() {
      if(!string.IsNullOrEmpty(_apikey)) {
        return await Task.FromResult(_apikey);
      }
      try {
        if(string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIAddress) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIMerchentId) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPISecretKey))
          return await Task.FromResult(_apikey);
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(DNGlobalProperties.Current.ERPAPIAddress + "/authenticate");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        using(var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync())) {
          string json = JsonConvert.SerializeObject(new {
            merchant_id = DNGlobalProperties.Current.ERPAPIMerchentId,
            secret_key = DNGlobalProperties.Current.ERPAPISecretKey
          }, new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            _apikey = JsonConvert.DeserializeObject<APIKey>(streamReader.ReadToEnd()).api_key;
          }
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      }
      return await Task.FromResult(_apikey);
    }
    public async Task<bool> ForcefullyGetNewApiKeyAsync() {
      try {
        if(string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIAddress) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIMerchentId) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPISecretKey))
          return await Task.FromResult(false);
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(DNGlobalProperties.Current.ERPAPIAddress + "/authenticate");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        using(var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync())) {
          string json = JsonConvert.SerializeObject(new {
            merchant_id = DNGlobalProperties.Current.ERPAPIMerchentId,
            secret_key = DNGlobalProperties.Current.ERPAPISecretKey
          }, new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        if(httpResponse.StatusCode == HttpStatusCode.OK) {
          using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
            _apikey = JsonConvert.DeserializeObject<APIKey>(streamReader.ReadToEnd()).api_key;
          }
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
        return await Task.FromResult(false);
      }
      return await Task.FromResult(true);
    }
    private string _accessToken;
    private DateTime _accessTokenExpiration;
    public async Task<string> GetAccessTokenAsync(string apikey) {
      if(!string.IsNullOrEmpty(_accessToken) && DateTime.Now < _accessTokenExpiration) {
        return await Task.FromResult(_accessToken);
      }
      try {
        if(string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIAddress) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIUserNumber) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIUserPassword) || string.IsNullOrEmpty(apikey))
          return _accessToken;
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(DNGlobalProperties.Current.ERPAPIAddress + "/authorize");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        httpWebRequest.Headers.Add("x-api-key", apikey);
        using(var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync())) {
          string json = JsonConvert.SerializeObject(new {
            user_id = DNGlobalProperties.Current.ERPAPIUserNumber,
            password = DNGlobalProperties.Current.ERPAPIUserPassword
          }, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat, Formatting = Newtonsoft.Json.Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
          streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          _accessToken = JsonConvert.DeserializeObject<APIKey.AccessToken>(streamReader.ReadToEnd()).Token;
          _accessTokenExpiration = DateTime.Now.AddHours(8);
        }
      } catch(Exception exc) {
        string error = exc.Message + exc.StackTrace;
      }
      return await Task.FromResult(_accessToken);
    }
    public async Task<HttpWebRequest> GetWebRequestAsync(string method, string url, bool useAuthorization = true) {
      HttpWebRequest _request = null;
      var _apikey = await GetApiKeyAsync();
      if(string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIAddress) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIUserNumber) || string.IsNullOrEmpty(DNGlobalProperties.Current.ERPAPIUserPassword) || string.IsNullOrEmpty(_apikey))
        return await Task.FromResult(_request);
      _request = (HttpWebRequest)WebRequest.Create(url);
      if(useAuthorization) {
        _request.Headers.Add("Authorization", String.Format("Bearer {0}", await GetAccessTokenAsync(_apikey)));
      }
      _request.ContentType = "application/json";
      _request.Method = method;
      _request.Headers.Add("x-api-key", _apikey);
      return await Task.FromResult(_request);
    }
    public async Task<HttpWebResponse> PostResponseAsync(string url, string postobj) {
      var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("POST", url);
      using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
        streamWriter.Write(postobj);
      }
      return (HttpWebResponse)await httpWebRequest.GetResponseAsync();
    }
    public T ReadResponse<T>(HttpWebResponse httpResponse) {
      if(httpResponse.StatusCode == HttpStatusCode.OK) {
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          string json = streamReader.ReadToEnd();
          var obj = JsonConvert.DeserializeObject<T>(json);
          return obj;
        }
      }
      return default(T);
    }
    public async Task<HttpWebResponse> GetResponseAsync(string url, string method = "GET") {
      var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync(method, url);
      return (HttpWebResponse)await httpWebRequest.GetResponseAsync();
    }
    public async Task<T> GetResponseObjectAsync<T>(string url) {
      var httpResponse = await GetResponseAsync(url);
      if(httpResponse.StatusCode == HttpStatusCode.OK) {
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
          string json = streamReader.ReadToEnd();
          var obj = JsonConvert.DeserializeObject<T>(json);
          return obj;
        }
      }
      return default(T);
    }
    public async Task<HttpWebResponse> PutResponseAsync(string url, string postobj) {
      var httpWebRequest = await DNAPIHandler.Current.GetWebRequestAsync("PUT", url);
      using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
        streamWriter.Write(postobj);
      }
      return (HttpWebResponse)await httpWebRequest.GetResponseAsync();
    }
    #endregion

    #endregion
  }

  #region new api class
  public class APIKey {
    public string api_key { get; set; }
    public class AccessToken {
      public string Token { get; set; }
    }
  }
  #endregion
  public class DNWebClient :WebClient {
    protected override WebRequest GetWebRequest(Uri address) {
      WebRequest request = base.GetWebRequest(address);
      System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      if(request is HttpWebRequest) {
        (request as HttpWebRequest).KeepAlive = false;
      }
      return request;
    }
  }
}
