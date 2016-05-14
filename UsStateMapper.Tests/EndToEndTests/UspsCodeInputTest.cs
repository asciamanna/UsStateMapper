using NUnit.Framework;

namespace UsStateMapper.Tests.EndToEndTests {
  [TestFixture]
  public class UspsCodeInputTest {
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      subject = new StateMapper();
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
  }
}