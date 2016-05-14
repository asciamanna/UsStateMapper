using NUnit.Framework;

namespace UsStateMapper.Tests.EndToEndTests {
  [TestFixture]
  public class StateNameInputTest {
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

    [Test]
    public void ToState_Returns_Empty_String_When_No_State_Is_Found() {
      var unknownStateInput = "Unknown state";

      var result = subject.ToState(unknownStateInput);

      Assert.That(result, Is.Empty);
    }
  }
} 