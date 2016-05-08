namespace UsStateMapper {
  public static class StringExtensions {
    private const string IsoTwoPlusTwoCodePrefix = "US-";

    public static string NormalizeStateText(this string stateText) {
      return TrimIsoTwoPlusTwoCodePrefix(stateText).Trim().Replace(" ", string.Empty).Replace(".", string.Empty).ToLower();
    }

    private static string TrimIsoTwoPlusTwoCodePrefix(string stateText) {
      return stateText.Replace(IsoTwoPlusTwoCodePrefix, string.Empty);
    }
  }
}
