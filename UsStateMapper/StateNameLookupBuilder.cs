using System.Collections.Generic;
using System.Linq;

namespace UsStateMapper {
  public class StateNameLookupBuilder {
    private readonly IStateRepository stateRepository;

    public StateNameLookupBuilder(IStateRepository stateRepository) {
      this.stateRepository = stateRepository;
    }

    public Dictionary<string, string> Create() {
      var states = stateRepository.GetAll();
      var stateNameLookup = CreateStateNameDictionaryWithStateKeys(states);
      AddUspsCodeKeys(states, stateNameLookup);
      AddAnsiTwoDigitCodeKeys(states, stateNameLookup);
      AddUscgCodeKeys(states, stateNameLookup);
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

    private static Dictionary<string, string> CreateStateNameDictionaryWithStateKeys(List<State> states) {
      return states.ToDictionary(s => s.Name.ToLower(), s => s.Name);
    }
  }
}