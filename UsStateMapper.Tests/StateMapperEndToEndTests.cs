using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateMapperEndToEndTests {
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      subject = new StateMapper();
    }

    [TestCase("Alabama")]
    [TestCase("Alaska")]
    [TestCase("Arizona")]
    [TestCase("Arkansas")]
    [TestCase("California")]
    [TestCase("Colorado")]
    [TestCase("Connecticut")]
    [TestCase("Delaware")]
    [TestCase("Florida")]
    [TestCase("Georgia")]
    [TestCase("Hawaii")]
    [TestCase("Idaho")]
    [TestCase("Illinois")]
    [TestCase("Indiana")]
    [TestCase("Iowa")]
    [TestCase("Kansas")]
    [TestCase("Kentucky")]
    [TestCase("Louisiana")]
    [TestCase("Maine")]
    [TestCase("Maryland")]
    [TestCase("Massachusetts")]
    [TestCase("Michigan")]
    [TestCase("Minnesota")]
    [TestCase("Mississippi")]
    [TestCase("Missouri")]
    [TestCase("Montana")]
    [TestCase("Nebraska")]
    [TestCase("Nevada")]
    [TestCase("New Hampshire")]
    [TestCase("New Jersey")]
    [TestCase("New Mexico")]
    [TestCase("New York")]
    [TestCase("North Carolina")]
    [TestCase("North Dakota")]
    [TestCase("Ohio")]
    [TestCase("Oklahoma")]
    [TestCase("Oregon")]
    [TestCase("Pennsylvania")]
    [TestCase("Rhode Island")]
    [TestCase("South Carolina")]
    [TestCase("South Dakota")]
    [TestCase("Tennessee")]
    [TestCase("Texas")]
    [TestCase("Utah")]
    [TestCase("Vermont")]
    [TestCase("Virginia")]
    [TestCase("Washington")]
    [TestCase("West Virginia")]
    [TestCase("Wisconsin")]
    [TestCase("Wyoming")]
    [TestCase("District of Columbia")]
    [TestCase("American Samoa")]
    [TestCase("Guam")]
    [TestCase("Northern Mariana Islands")]
    [TestCase("Puerto Rico")]
    [TestCase("U.S. Virgin Islands")]
    public void ToState_When_State_Is_Provided(string statename) {
      var result = subject.ToState(statename);

      Assert.That(result, Is.EqualTo(statename));
    }

    [Test]
    public void ToState_Ignores_Whitespace_In_Input() {
      var result = subject.ToState("  New York    ");

      Assert.That(result, Is.EqualTo("New York"));
    }

    [Test]
    public void ToState_Ignores_Missing_Whitespace_Within_State_Name() {
      var result = subject.ToState("NewHampshire");

      Assert.That(result, Is.EqualTo("New Hampshire"));
    }

    [Test]
    public void ToState_Ignores_Capitalization() {
      var result = subject.ToState("penNSylVaniA");

      Assert.That(result, Is.EqualTo("Pennsylvania"));
    }

    [TestCase("AL", "Alabama")]
    [TestCase("AK", "Alaska")]
    [TestCase("AZ", "Arizona")]
    [TestCase("AR", "Arkansas")]
    [TestCase("CA", "California")]
    [TestCase("CO", "Colorado")]
    [TestCase("CT", "Connecticut")]
    [TestCase("DE", "Delaware")]
    [TestCase("DC", "District of Columbia")]
    [TestCase("FL", "Florida")]
    [TestCase("GA", "Georgia")]
    [TestCase("HI", "Hawaii")]
    [TestCase("ID", "Idaho")]
    [TestCase("IL", "Illinois")]
    [TestCase("IN", "Indiana")]
    [TestCase("IA", "Iowa")]
    [TestCase("KS", "Kansas")]
    [TestCase("KY", "Kentucky")]
    [TestCase("LA", "Louisiana")]
    [TestCase("ME", "Maine")]
    [TestCase("MD", "Maryland")]
    [TestCase("MA", "Massachusetts")]
    [TestCase("MI", "Michigan")]
    [TestCase("MN", "Minnesota")]
    [TestCase("MS", "Mississippi")]
    [TestCase("MO", "Missouri")]
    [TestCase("MT", "Montana")]
    [TestCase("NE", "Nebraska")]
    [TestCase("NV", "Nevada")]
    [TestCase("NH", "New Hampshire")]
    [TestCase("NJ", "New Jersey")]
    [TestCase("NM", "New Mexico")]
    [TestCase("NY", "New York")]
    [TestCase("NC", "North Carolina")]
    [TestCase("ND", "North Dakota")]
    [TestCase("OH", "Ohio")]
    [TestCase("OK", "Oklahoma")]
    [TestCase("OR", "Oregon")]
    [TestCase("PA", "Pennsylvania")]
    [TestCase("RI", "Rhode Island")]
    [TestCase("SC", "South Carolina")]
    [TestCase("SD", "South Dakota")]
    [TestCase("TN", "Tennessee")]
    [TestCase("TX", "Texas")]
    [TestCase("UT", "Utah")]
    [TestCase("VT", "Vermont")]
    [TestCase("VA", "Virginia")]
    [TestCase("WA", "Washington")]
    [TestCase("WV", "West Virginia")]
    [TestCase("WI", "Wisconsin")]
    [TestCase("WY", "Wyoming")]
    [TestCase("AS", "American Samoa")]
    [TestCase("GU", "Guam")]
    [TestCase("MP", "Northern Mariana Islands")]
    [TestCase("PR", "Puerto Rico")]
    [TestCase("VI", "U.S. Virgin Islands")]
    public void ToState_Returns_State_When_USPS_2_Letter_Code_Is_Supplied(string code, string state) {
      var result = subject.ToState(code);

      Assert.That(result, Is.EqualTo(state));
    }

    [Test]
    public void ToState_Returns_Empty_String_When_No_State_Is_Found() {
      var unknownStateInput = "Unknown state";

      var result = subject.ToState(unknownStateInput);

      Assert.That(result, Is.Empty);
    }

    [TestCase("US-AL", "Alabama")]
    [TestCase("US-AK", "Alaska")]
    [TestCase("US-AZ", "Arizona")]
    [TestCase("US-AR", "Arkansas")]
    [TestCase("US-CA", "California")]
    [TestCase("US-CO", "Colorado")]
    [TestCase("US-DE", "Delaware")]
    [TestCase("US-DC", "District of Columbia")]
    [TestCase("US-FL", "Florida")]
    [TestCase("US-GA", "Georgia")]
    [TestCase("US-HI", "Hawaii")]
    [TestCase("US-ID", "Idaho")]
    [TestCase("US-IL", "Illinois")]
    [TestCase("US-IN", "Indiana")]
    [TestCase("US-IA", "Iowa")]
    [TestCase("US-KS", "Kansas")]
    [TestCase("US-KY", "Kentucky")]
    [TestCase("US-LA", "Louisiana")]
    [TestCase("US-ME", "Maine")]
    [TestCase("US-MD", "Maryland")]
    [TestCase("US-MA", "Massachusetts")]
    [TestCase("US-MI", "Michigan")]
    [TestCase("US-MN", "Minnesota")]
    [TestCase("US-MS", "Mississippi")]
    [TestCase("US-MO", "Missouri")]
    [TestCase("US-MT", "Montana")]
    [TestCase("US-NE", "Nebraska")]
    [TestCase("US-NV", "Nevada")]
    [TestCase("US-NH", "New Hampshire")]
    [TestCase("US-NJ", "New Jersey")]
    [TestCase("US-NM", "New Mexico")]
    [TestCase("US-NY", "New York")]
    [TestCase("US-NC", "North Carolina")]
    [TestCase("US-ND", "North Dakota")]
    [TestCase("US-OH", "Ohio")]
    [TestCase("US-OK", "Oklahoma")]
    [TestCase("US-OR", "Oregon")]
    [TestCase("US-PA", "Pennsylvania")]
    [TestCase("US-RI", "Rhode Island")]
    [TestCase("US-SC", "South Carolina")]
    [TestCase("US-SD", "South Dakota")]
    [TestCase("US-TN", "Tennessee")]
    [TestCase("US-TX", "Texas")]
    [TestCase("US-UT", "Utah")]
    [TestCase("US-VT", "Vermont")]
    [TestCase("US-VA", "Virginia")]
    [TestCase("US-WA", "Washington")]
    [TestCase("US-WV", "West Virginia")]
    [TestCase("US-WI", "Wisconsin")]
    [TestCase("US-WY", "Wyoming")]
    [TestCase("US-AS", "American Samoa")]
    [TestCase("US-GU", "Guam")]
    [TestCase("US-MP", "Northern Mariana Islands")]
    [TestCase("US-PR", "Puerto Rico")]
    [TestCase("US-VI", "U.S. Virgin Islands")]
    public void ToState_Matches_State_When_ISO_2_Plus_2_Letter_Codes_Are_Supplied(string code, string state) {
      var result = subject.ToState(code);

      Assert.That(result, Is.EqualTo(state));
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
    public void ToState_Matches_State_When_Two_Digit_ANSI_Codes_Are_Supplied(string twoDigitAnsiCode, string expectedState) {
      var result = subject.ToState(twoDigitAnsiCode);

      Assert.That(result, Is.EqualTo(expectedState));
    }
  }
}