using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateNameLookupBuilderTest {
    private Mock<IStateRepository> repository;
    private StateNameLookupBuilder subject;

    [SetUp]
    public void SetUp() {
      repository = new Mock<IStateRepository>();
      subject = new StateNameLookupBuilder(repository.Object);
    }

    [Test]
    public void Create_Adds_StateName_As_Key_For_StateLookup() {
      var states = new List<State> { new State { Name = "Maine" }, new State { Name = "Nevada" } };
      repository.Setup(r => r.GetAll()).Returns(states);

      var lookup = subject.Create();

      Assert.That(lookup, Has.Count.EqualTo(states.Count));
      Assert.That(lookup.ContainsKey("maine"));
      Assert.That(lookup["maine"], Is.EqualTo("Maine"));
      Assert.That(lookup.ContainsKey("nevada"));
      Assert.That(lookup["nevada"], Is.EqualTo("Nevada"));
    }
  }
}
