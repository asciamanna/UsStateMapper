using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateTextNormailzerTest {
    StateTextNormalizer subject;

    [SetUp]
    public void SetUp() {
      subject = new StateTextNormalizer();
    }

    [Test]
    public void Normailze_Strips_IsoTwoPlusTwo_Prefix() {
      var prefix = "US-";
      var postalCodeAbbreviation = "ME";

      var result = subject.Normalize(prefix + postalCodeAbbreviation);

      Assert.That(result, Is.EqualTo(postalCodeAbbreviation.ToLower()));
    }

    [Test]
    public void Normalize_Strips_All_Spaces_And_Periods_From_Input() {
      var input = "  washington d.c.  ";

      var result = subject.Normalize(input);

      Assert.That(result, Is.Not.StringContaining(" "));
      Assert.That(result, Is.Not.StringContaining("."));
    }
  }
}
