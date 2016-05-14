using Moq;
using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateMapperTest {
    private Mock<IStateNameLookup> lookup;
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      lookup = new Mock<IStateNameLookup>();
      subject = new StateMapper(lookup.Object);
    }

    [Test]
    public void ToState_Changes_Input_Text_To_Lowercase() {
      const string stateText = "FL";
      const string foundState = "Florida";
      lookup.Setup(l => l.FindState(stateText.ToLower())).Returns(foundState);

      var result = subject.ToState(stateText);

      Assert.That(result, Is.EqualTo(foundState));
    }

    [Test]
    public void ToState_Changes_Input_Text_To_Extract_Prefix_From_AnsiTwoPlusTwoCodes() {
      const string stateText = "US-FL";
      const string normalizedText = "fl";
      const string foundState = "Florida";
      lookup.Setup(l => l.FindState(normalizedText)).Returns(foundState);

      var result = subject.ToState(stateText);

      Assert.That(result, Is.EqualTo(foundState));
    }

    [Test]
    public void ToState_Removes_Spaces_And_Periods_From_Input_Text() {
      const string stateText = "Washington D.C.";
      const string normalizedText = "washingtondc";
      const string foundState = "District Of Columbia";
      lookup.Setup(l => l.FindState(normalizedText)).Returns(foundState);

      var result = subject.ToState(stateText);

      Assert.That(result, Is.EqualTo(foundState));
    }
  }
}
