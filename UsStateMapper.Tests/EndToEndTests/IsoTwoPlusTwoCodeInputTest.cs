using NUnit.Framework;

namespace UsStateMapper.Tests.EndToEndTests {
  [TestFixture]
  public class IsoTwoPlusTwoCodeInputTest {
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      subject = new StateMapper();
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
  }
}