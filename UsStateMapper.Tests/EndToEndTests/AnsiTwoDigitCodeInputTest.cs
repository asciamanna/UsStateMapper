using NUnit.Framework;

namespace UsStateMapper.Tests.EndToEndTests {
  [TestFixture]
  public class AnsiTwoDigitCodeInputTest {
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      subject = new StateMapper();
    }

    [TestCase("01", "Alabama")]
    [TestCase("02", "Alaska")]
    [TestCase("04", "Arizona")]
    [TestCase("05", "Arkansas")]
    [TestCase("06", "California")]
    [TestCase("08", "Colorado")]
    [TestCase("09", "Connecticut")]
    [TestCase("10", "Delaware")]
    [TestCase("11", "District of Columbia")]
    [TestCase("12", "Florida")]
    [TestCase("13", "Georgia")]
    [TestCase("15", "Hawaii")]
    [TestCase("16", "Idaho")]
    [TestCase("17", "Illinois")]
    [TestCase("18", "Indiana")]
    [TestCase("19", "Iowa")]
    [TestCase("20", "Kansas")]
    [TestCase("21", "Kentucky")]
    [TestCase("22", "Louisiana")]
    [TestCase("23", "Maine")]
    [TestCase("24", "Maryland")]
    [TestCase("25", "Massachusetts")]
    [TestCase("26", "Michigan")]
    [TestCase("27", "Minnesota")]
    [TestCase("28", "Mississippi")]
    [TestCase("29", "Missouri")]
    [TestCase("30", "Montana")]
    [TestCase("31", "Nebraska")]
    [TestCase("32", "Nevada")]
    [TestCase("33", "New Hampshire")]
    [TestCase("34", "New Jersey")]
    [TestCase("35", "New Mexico")]
    [TestCase("36", "New York")]
    [TestCase("37", "North Carolina")]
    [TestCase("38", "North Dakota")]
    [TestCase("39", "Ohio")]
    [TestCase("40", "Oklahoma")]
    [TestCase("41", "Oregon")]
    [TestCase("42", "Pennsylvania")]
    [TestCase("44", "Rhode Island")]
    [TestCase("45", "South Carolina")]
    [TestCase("46", "South Dakota")]
    [TestCase("47", "Tennessee")]
    [TestCase("48", "Texas")]
    [TestCase("49", "Utah")]
    [TestCase("50", "Vermont")]
    [TestCase("51", "Virginia")]
    [TestCase("53", "Washington")]
    [TestCase("54", "West Virginia")]
    [TestCase("55", "Wisconsin")]
    [TestCase("56", "Wyoming")]
    [TestCase("60", "American Samoa")]
    [TestCase("66", "Guam")]
    [TestCase("69", "Northern Mariana Islands")]
    [TestCase("72", "Puerto Rico")]
    [TestCase("78", "U.S. Virgin Islands")]
    public void ToState_Matches_State_When_Two_Digit_ANSI_Codes_Are_Supplied(string twoDigitAnsiCode,
      string expectedState) {
      var result = subject.ToState(twoDigitAnsiCode);

      Assert.That(result, Is.EqualTo(expectedState));
    }
  }
}