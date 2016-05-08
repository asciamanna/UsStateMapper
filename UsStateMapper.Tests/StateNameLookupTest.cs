using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateNameLookupTest {
    private Mock<IStateNameDictionaryBuilder> builder;
    private StateNameLookup subject;

    [SetUp]
    public void SetUp() {
      builder = new Mock<IStateNameDictionaryBuilder>();
      subject = new StateNameLookup(builder.Object);
    }

    [Test]
    public void FindState() {
      builder.Setup(b => b.Create()).Returns(new Dictionary<string, string> {{"me", "Maine"}});

      var result = subject.FindState("me");

      Assert.That(result, Is.EqualTo("Maine"));
    }

    [Test]
    public void FindState_Returns_Empty_String_When_Not_Found() {
      builder.Setup(b => b.Create()).Returns(new Dictionary<string, string> { { "me", "Maine" } });

      var result = subject.FindState("ky");

      Assert.That(result, Is.Empty);
    }

    [Test]
    public void FindState_Creates_State_Dictionary_Only_Once() {
      builder.Setup(b => b.Create()).Returns(new Dictionary<string, string> { { "me", "Maine" } });

      subject.FindState("ky");
      subject.FindState("pa");

      builder.Verify(b => b.Create(), Times.Once);
    }
  }
}
