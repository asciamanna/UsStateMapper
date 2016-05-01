﻿using System.Collections.Generic;

namespace UsStateMapper {
  public interface IStateNameLookup {
    string FindState(string normalizedStateText);
  }

  public class StateNameLookup : IStateNameLookup {
    public string FindState(string normalizedStateText) {
      return lookup[normalizedStateText];
    }
    private static Dictionary<string, string> lookup = new Dictionary<string, string> {
      {"alabama", "Alabama"},
      {"alaska", "Alaska"},
      {"arizona", "Arizona"},
      {"arkansas", "Arkansas"},
      {"california", "California"},
      {"colorado", "Colorado"},
      {"connecticut", "Connecticut"},
      {"delaware", "Delaware"},
      {"florida", "Florida"},
      {"georgia", "Georgia"},
      {"hawaii", "Hawaii"},
      {"idaho", "Idaho"},
      {"illinois", "Illinois"},
      {"indiana", "Indiana"},
      {"iowa", "Iowa"},
      {"kansas", "Kansas"},
      {"kentucky", "Kentucky"},
      {"louisiana", "Louisiana"},
      {"maine", "Maine"},
      {"maryland", "Maryland"},
      {"massachusetts", "Massachusetts"},
      {"michigan", "Michigan"},
      {"minnesota", "Minnesota"},
      {"mississippi", "Mississippi"},
      {"missouri", "Missouri"},
      {"montana", "Montana"},
      {"nebraska", "Nebraska"},
      {"nevada", "Nevada"},
      {"newhampshire", "New Hampshire"},
      {"newjersey", "New Jersey"},
      {"newmexico", "New Mexico"},
      {"newyork", "New York"},
      {"northcarolina", "North Carolina"},
      {"northdakota", "North Dakota"},
      {"ohio", "Ohio"},
      {"oklahoma", "Oklahoma"},
      {"oregon", "Oregon"},
      {"pennsylvania", "Pennsylvania"},
      {"rhodeisland", "Rhode Island"},
      {"southcarolina", "South Carolina"},
      {"southdakota", "South Dakota"},
      {"tennessee", "Tennessee"},
      {"texas", "Texas"},
      {"utah", "Utah"},
      {"vermont", "Vermont"},
      {"virginia", "Virginia"},
      {"washington", "Washington"},
      {"westvirginia", "West Virginia"},
      {"wisconsin", "Wisconsin"},
      {"wyoming", "Wyoming"}
    };

  }
}
