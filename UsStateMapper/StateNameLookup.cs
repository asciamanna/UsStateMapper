using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

    private Dictionary<string, string> StateDictionary => stateDictionary ?? (stateDictionary = builder.Create());
  }
}
