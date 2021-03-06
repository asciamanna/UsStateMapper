﻿using System.Collections.Generic;

namespace UsStateMapper {
  public interface IStateNameLookup {
    string FindState(string normalizedStateText);
  }

  public class StateNameLookup : IStateNameLookup {
    private readonly IStateNameDictionaryBuilder builder;

    public StateNameLookup() : this(new StateNameDictionaryBuilder()) {}

    public StateNameLookup(IStateNameDictionaryBuilder builder) {
      this.builder = builder;
    }

    public string FindState(string normalizedStateText) {
      string state;
      var found = StateDictionary.TryGetValue(normalizedStateText, out state);
      return found ? state : string.Empty;
    }

    private Dictionary<string, string> stateDictionary;

    private Dictionary<string, string> StateDictionary {
      get { return stateDictionary ?? (stateDictionary = builder.Create()); }
    }
  }
}
