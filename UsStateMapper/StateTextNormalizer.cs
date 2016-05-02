namespace UsStateMapper {
  public interface IStateTextNormalizer {
    string Normalize(string stateText);
  }

  public class StateTextNormalizer : IStateTextNormalizer {
    private const string IsoTwoPlusTwoCodePrefix = "US-";
    
    public string Normalize(string stateText) {
      return TrimIsoTwoPlusTwoCodePrefix(stateText).Trim().Replace(" ", string.Empty).Replace(".", string.Empty).ToLower();
    }

    private string TrimIsoTwoPlusTwoCodePrefix(string stateText) {
      return stateText.Replace(IsoTwoPlusTwoCodePrefix, string.Empty);
    }
  }
}
