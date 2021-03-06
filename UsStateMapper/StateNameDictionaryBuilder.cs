﻿using System.Collections.Generic;
using System.Linq;

namespace UsStateMapper {
  public interface IStateNameDictionaryBuilder {
    Dictionary<string, string> Create();
  }

  public class StateNameDictionaryBuilder : IStateNameDictionaryBuilder {
    private readonly IStateRepository stateRepository;

    public StateNameDictionaryBuilder() : this(new StateRepository()) { }

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
      AddApAbbreviationKeys(states, stateNameLookup);
      AddOtherAbbreviationKeys(states, stateNameLookup);
      return stateNameLookup;
    }

    private static Dictionary<string, string> CreateStateNameDictionaryWithStateKeys(List<State> states) {
      return states.ToDictionary(s => s.Name.NormalizeStateText(), s => s.Name);
    }

    private static void AddAnsiTwoDigitCodeKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.AnsiTwoDigitCode))) {
        stateNameLookup.Add(state.AnsiTwoDigitCode, state.Name);
      }
    }

    private static void AddUspsCodeKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.UspsCode))) {
        stateNameLookup.Add(state.UspsCode.NormalizeStateText(), state.Name);
      }
    }

    private static void AddUscgCodeKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.UscgCode))) {
        stateNameLookup.AddIfKeyDoesntExist(state.UscgCode.NormalizeStateText(), state.Name);
      }
    }

    private static void AddOldGpoAbbreviationKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.OldGpoAbbreviation))) {
        stateNameLookup.AddIfKeyDoesntExist(state.OldGpoAbbreviation.NormalizeStateText(), state.Name);
      }
    }

    private static void AddOtherAbbreviationKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => s.OtherAbbreviations != null && s.OtherAbbreviations.Any())) {
        state.OtherAbbreviations.ForEach(o => stateNameLookup.AddIfKeyDoesntExist(o.NormalizeStateText(), state.Name));
      } 
    }

    private void AddApAbbreviationKeys(List<State> states, Dictionary<string, string> stateNameLookup) {
      foreach (var state in states.Where(s => !string.IsNullOrWhiteSpace(s.ApStyleAbbreviation))) {
        stateNameLookup.AddIfKeyDoesntExist(state.ApStyleAbbreviation.NormalizeStateText(), state.Name);
      }
    }
  }
}