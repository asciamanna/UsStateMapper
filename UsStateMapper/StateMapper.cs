namespace UsStateMapper {
  public class StateMapper {
    private readonly IStateNameLookup stateNameLookup;

    public StateMapper() : this(new StateNameLookup()) {}

    public StateMapper(IStateNameLookup stateNameLookup) {
      this.stateNameLookup = stateNameLookup;
    }

    public string ToState(string stateText) {
      return stateNameLookup.FindState(stateText.NormalizeStateText());
    }
  }
}
