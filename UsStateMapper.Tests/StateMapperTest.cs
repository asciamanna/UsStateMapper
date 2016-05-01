using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateMapperTest {
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
  }
}