using Moq;
using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateMapperTest {
    private Mock<IStateNameLookup> lookup;
    private Mock<IStateTextNormalizer> normalizer;
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      lookup = new Mock<IStateNameLookup>();
      normalizer = new Mock<IStateTextNormalizer>();
      subject = new StateMapper(normalizer.Object, lookup.Object);
    }

    [Test]
    public void ToState() {
      var stateText = "FL";
      var normalizedText = "fl";
      var foundState = "Florida";
      normalizer.Setup(n => n.Normalize(stateText)).Returns(normalizedText);
      lookup.Setup(l => l.FindState(normalizedText)).Returns(foundState);

      var result = subject.ToState(stateText);

      Assert.That(result, Is.EqualTo(foundState));
    }
  }
}
