using System.Collections.Generic;

namespace UsStateMapper {
  public static class ExtensionMethods {
    private const string IsoTwoPlusTwoCodePrefix = "US-";

    public static string NormalizeStateText(this string stateText) {
      return TrimIsoTwoPlusTwoCodePrefix(stateText).Trim().Replace(" ", string.Empty).Replace(".", string.Empty).ToLower();
    }

    private static string TrimIsoTwoPlusTwoCodePrefix(string stateText) {
      return stateText.Replace(IsoTwoPlusTwoCodePrefix, string.Empty);
    }

    public static void AddIfKeyDoesntExist(this Dictionary<string, string> stateNameLookup, string key, string value) {
      if (!stateNameLookup.ContainsKey(key))
        stateNameLookup.Add(key, value);
    }
  }
}
