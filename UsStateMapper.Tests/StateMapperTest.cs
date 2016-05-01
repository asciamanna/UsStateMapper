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
  }
}