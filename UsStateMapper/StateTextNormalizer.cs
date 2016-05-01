namespace UsStateMapper {
  public interface IStateTextNormalizer {
    string Normalize(string stateText);
  }

  public class StateTextNormalizer : IStateTextNormalizer {
    public string Normalize(string stateText) {
      return stateText.Trim().Replace(" ", string.Empty).ToLower();
    }
  }
}
