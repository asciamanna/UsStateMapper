namespace UsStateMapper {
  public class StateMapper {
    private readonly IStateTextNormalizer textNormalizer;
    private readonly IStateNameLookup stateNameLookup;

    public StateMapper() : this(new StateTextNormalizer(), new StateNameLookup()) {}

    public StateMapper(IStateTextNormalizer textNormalizer, IStateNameLookup stateNameLookup) {
      this.textNormalizer = textNormalizer;
      this.stateNameLookup = stateNameLookup;
    }

    public string ToState(string stateText) {
      return stateNameLookup.FindState(textNormalizer.Normalize(stateText));
    }
  }
}
