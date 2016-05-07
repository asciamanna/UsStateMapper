using System.Collections.Generic;

namespace UsStateMapper {
  public class State {
    public string Name { get; set; }
    public string IsoTwoPlusTwoCode { get; set; }
    public string AnsiTwoDigitCode { get; set; }
    public string UspsCode { get; set; }
    public string UscgCode { get; set; }
    public string OldGpoAbbreviation { get; set; }
    public string ApStyleAbbreviation { get; set; }
    public List<string> OtherAbbreviations { get; set; }
  }
}
