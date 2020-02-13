using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace XRETAIL.ViewModels {
  public class ItemTypeIDToEnumConverter : JsonConverter {
    Dictionary<string, DNItemType> idToEnumDictionary;

    public ItemTypeIDToEnumConverter() {
      idToEnumDictionary = new Dictionary<string, DNItemType>();
      idToEnumDictionary.Add("A", DNItemType.ColdStorage);
      idToEnumDictionary.Add("B", DNItemType.Frozen);
      idToEnumDictionary.Add("C", DNItemType.ElectricalItemExcGuarantee);
      idToEnumDictionary.Add("D", DNItemType.EnergyDrinks);
      idToEnumDictionary.Add("E", DNItemType.ElectricalItemIncGuarantee);
      idToEnumDictionary.Add("F", DNItemType.Food);
      idToEnumDictionary.Add("G", DNItemType.GoldSmith);
      idToEnumDictionary.Add("H", DNItemType.Tile);
      idToEnumDictionary.Add("I", DNItemType.CinemaTickets);
      idToEnumDictionary.Add("J", DNItemType.ShoppingBag);
      idToEnumDictionary.Add("K", DNItemType.Telekort);
      idToEnumDictionary.Add("L", DNItemType.Liquor);
      idToEnumDictionary.Add("M", DNItemType.MoneyGame);
      idToEnumDictionary.Add("N", DNItemType.AlcoholFree);
      idToEnumDictionary.Add("O", DNItemType.Commission);
      idToEnumDictionary.Add("P", DNItemType.Medicine);
      idToEnumDictionary.Add("Q", DNItemType.StoreSales);
      idToEnumDictionary.Add("R", DNItemType.Recipe);
      idToEnumDictionary.Add("S", DNItemType.SpilliKassa);
      idToEnumDictionary.Add("T", DNItemType.Tobbaco);
      idToEnumDictionary.Add("U", DNItemType.Paintball);
      idToEnumDictionary.Add("V", DNItemType.Renting);
      idToEnumDictionary.Add("W", DNItemType.Badekort);
      idToEnumDictionary.Add("X", DNItemType.Gebyr);
      idToEnumDictionary.Add("Z", DNItemType.Z);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {

    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      if(reader == null) { return null; }
      List<DNItemType> ItemTypeList = new List<DNItemType>();
      ItemTypeList.Add(DNItemType.Blank);
      if (reader.TokenType == JsonToken.StartArray) {
        JArray itemTypeJArray = JArray.Load(reader);

        foreach(JObject itemTypeJObject in itemTypeJArray) {
          if(itemTypeJObject["visible"].ToObject<bool>()) {
            if(idToEnumDictionary.ContainsKey(itemTypeJObject["id"].ToObject<string>())) {
              ItemTypeList.Add(idToEnumDictionary[itemTypeJObject["id"].ToObject<string>()]);
            }
          }
        }
      }
      return ItemTypeList;
    }

    public override bool CanRead
    {
        get { return true; }
    }

    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(List<DNItemType>);
    }

    public enum DNItemType {
      Blank,
      ElectricalItemExcGuarantee,
      ElectricalItemIncGuarantee,
      GoldSmith,
      Liquor,
      Renting,
      Z,
      Recipe,
      Tobbaco,
      EnergyDrinks,
      Tile,
      Telekort,
      MoneyGame,
      Commission,
      Medicine,
      Food,
      ColdStorage,
      Frozen,
      ShoppingBag,
      AlcoholFree,
      SpilliKassa,
      StoreSales,
      CinemaTickets,
      Badekort,
      Paintball,
      Gebyr
    }

  }
}
