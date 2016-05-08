using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace UsStateMapper {
  public interface IStateNameDictionaryBuilder {
    Dictionary<string, string> Create();
  }

  public class StateNameDictionaryBuilder : IStateNameDictionaryBuilder {
    private readonly IStateRepository stateRepository;

    public StateNameDictionaryBuilder() : this(new StateRepository()) {}

    public StateNameDictionaryBuilder(IStateRepository stateRepository) {
      this.stateRepository = stateRepository;
    }

    public Dictionary<string, string> Create() {
      var states = stateRepository.GetAll();
      var stateNameLookup = CreateStateNameDictionaryWithStateKeys(states);
      AddUspsCodeKeys(states, stateNameLookup);
      AddAnsiTwoDigitCodeKeys(states, stateNameLookup);
      AddUscgCodeKeys(states, stateNameLookup);
      AddOldGpoAbbreviationKeys(states, stateNameLookup);
      return stateNameLookup;
    }

    private static void AddAnsiTwoDigitCodeKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.AnsiTwoDigitCode))) {
        stateNameLookup.Add(state.AnsiTwoDigitCode, state.Name);
      }
    }

    private static void AddUspsCodeKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.UspsCode))) {
        stateNameLookup.Add(state.UspsCode.ToLower(), state.Name);
      }
    }

    private static void AddUscgCodeKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.UscgCode))) {
        if (!stateNameLookup.ContainsKey(state.UscgCode.ToLower()))
        stateNameLookup.Add(state.UscgCode.ToLower(), state.Name);
      }
    }

    private static void AddOldGpoAbbreviationKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.OldGpoAbbreviation))) {
        if (!stateNameLookup.ContainsKey(state.OldGpoAbbreviation.ToLower().Replace(".", string.Empty)))
          stateNameLookup.Add(state.OldGpoAbbreviation.ToLower().Replace(".", string.Empty), state.Name);
      }
    }

    private static Dictionary<string, string> CreateStateNameDictionaryWithStateKeys(List<State> states) {
      return states.ToDictionary(s => s.Name.ToLower().Replace(" ", string.Empty).Replace(".", string.Empty), s => s.Name);
    }
  }
}