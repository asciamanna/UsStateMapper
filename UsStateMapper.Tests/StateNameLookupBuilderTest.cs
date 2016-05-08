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

      var result = subject.Create();

      Assert.That(result, Has.Count.EqualTo(states.Count));
      AssertKeyThenValue(result, "maine", "Maine");
      AssertKeyThenValue(result, "nevada", "Nevada");
    }

    [Test]
    public void Create_Adds_UspsCode_As_Key_For_StateLookup() {
      var states = new List<State> { new State { Name = "Maine", UspsCode = "ME" }, new State { Name = "Nevada", UspsCode = "NV" } };
      repository.Setup(r => r.GetAll()).Returns(states);

      var result = subject.Create();

      Assert.That(result, Has.Count.EqualTo(states.Count * 2), "There isn't a key present for both the state name and USPS code.");
      AssertKeyThenValue(result, "me", "Maine");
      AssertKeyThenValue(result, "nv", "Nevada");
    }

    [Test]
    public void Create_Adds_AnsiTwoDigitCode_As_Key_For_StateLookup() {
      var states = new List<State> {
        new State {Name = "Maine", AnsiTwoDigitCode = "23"},
        new State {Name = "Nevada", AnsiTwoDigitCode = "32"}
      };
      repository.Setup(r => r.GetAll()).Returns(states);

      var result = subject.Create();

      Assert.That(result, Has.Count.EqualTo(states.Count * 2),
        "There isn't a key present for both the state name and ANSI two digit code.");
      AssertKeyThenValue(result, "23", "Maine");
      AssertKeyThenValue(result, "32", "Nevada");
    }

    [Test]
    public void Create_Adds_UscgCode_As_Key_For_StateLookup_If_It_Does_Not_Match_Usps_Code() {
      var states = new List<State> {
        new State {Name = "Nebraska", UspsCode = "NE", UscgCode = "NB"},
      };
      repository.Setup(r => r.GetAll()).Returns(states);

      var result = subject.Create();

      AssertKeyThenValue(result, "ne", "Nebraska");
      AssertKeyThenValue(result, "nb", "Nebraska");
    }

    [Test]
    public void Create_Does_Not_Add_UscgCode_As_Key_For_StateLookup_If_It_Matches_Usps_Code() {
      var states = new List<State> {
        new State {Name = "Texas", UspsCode = "TX", UscgCode = "TX"},
      };
      repository.Setup(r => r.GetAll()).Returns(states);

      var result = subject.Create();

      Assert.That(result, Has.Count.EqualTo(2), "There should only be a key present for the state name and USPS code.");
    }

    [Test]
    public void Create_Adds_OldGpo_Abbreviation_As_Key_To_StateLookup_Removing_Periods() {
      var states = new List<State> {
        new State {Name = "Illinois", OldGpoAbbreviation = "Ill." },
      };
      repository.Setup(r => r.GetAll()).Returns(states);

      var result = subject.Create();

      AssertKeyThenValue(result, "ill", "Illinois");
    }

    [Test]
    public void Create_Does_Not_Add_OldGpo_Abbreviation_As_Key_If_It_Conflicts_With_Another_Key() {
      var states = new List<State> {
        new State {Name = "Hawaii", OldGpoAbbreviation = "Hawaii" },
        new State {Name = "Kentucky", UspsCode = "KY", OldGpoAbbreviation = "Ky."}
      };
      repository.Setup(r => r.GetAll()).Returns(states);

      var result = subject.Create();
      Assert.That(result, Has.Count.EqualTo(3), "The lookup should only contain keys for Hawaii name, Kentucky name, and Kentucky USPS code.");
    }

    private static void AssertKeyThenValue(Dictionary<string, string> lookup, string key, string value) {
      Assert.That(lookup.ContainsKey(key));
      Assert.That(lookup[key], Is.EqualTo(value));
    }
  }
}
