using NUnit.Framework;

namespace UsStateMapper.Tests.EndToEndTests {
  [TestFixture]
  public class UscgCodeInputTest {
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      subject = new StateMapper();
    }

    [TestCase("HA", "Hawaii")]
    [TestCase("KA", "Kansas")]
    [TestCase("MC", "Michigan")]
    [TestCase("NB", "Nebraska")]
    [TestCase("WN", "Washington")]
    [TestCase("WS", "Wisconsin")]
    [TestCase("CM", "Northern Mariana Islands")]
    public void ToState_Matches_State_When_USCG_Codes_That_Dont_Conflict_With_USPS_Codes_Are_Supplied(string uscgCode,
      string expectedState) {
      var result = subject.ToState(uscgCode);

      Assert.That(result, Is.EqualTo(expectedState));
    }
  }
}