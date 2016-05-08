using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StringExtensionsTest {
    [Test]
    public void NormailzeStateText_Strips_IsoTwoPlusTwo_Prefix() {
      var prefix = "US-";
      var postalCodeAbbreviation = "ME";

      var result = (prefix + postalCodeAbbreviation).NormalizeStateText();

      Assert.That(result, Is.EqualTo(postalCodeAbbreviation.ToLower()));
    }

    [Test]
    public void Normalize_Strips_All_Spaces_And_Periods_From_Input() {
      var subject = "  washington d.c.  ";

      var result = subject.NormalizeStateText();

      Assert.That(result, Is.Not.StringContaining(" "));
      Assert.That(result, Is.Not.StringContaining("."));
    }
  }
}
