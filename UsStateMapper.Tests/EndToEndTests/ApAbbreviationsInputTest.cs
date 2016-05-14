using NUnit.Framework;

namespace UsStateMapper.Tests.EndToEndTests {
  [TestFixture]
  public class ApAbbreviationsInputTest {
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      subject = new StateMapper();
    }

    [TestCase("Kan.", "Kansas")]
    [TestCase("Neb.", "Nebraska")]
    [TestCase("N.M.", "New Mexico")]
    [TestCase("N.D.", "North Dakota")]
    [TestCase("Ore.", "Oregon")]
    [TestCase("S.D.", "South Dakota")]
    [TestCase("W.Va.", "West Virginia")]
    public void ToState_Matches_State_When_AP_Abbreviations_Are_Supplied(string apAbbreviation, string expectedState) {
      var result = subject.ToState(apAbbreviation);

      Assert.That(result, Is.EqualTo(expectedState));
    }
  }
}