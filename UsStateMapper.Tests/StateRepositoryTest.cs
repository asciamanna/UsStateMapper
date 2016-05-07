using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateRepositoryTest {
    private StateRepository subject;

    [SetUp]
    public void SetUp() {
      subject = new StateRepository();  
    }

    [Test]
    public void GetAll_Reads_States_And_Territories_From_Json_Resource_File() {
      var result = subject.GetAll();

      Assert.That(result, Has.Count.EqualTo(56));
    }
  }
}
