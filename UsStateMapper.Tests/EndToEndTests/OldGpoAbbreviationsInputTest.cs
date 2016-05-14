using NUnit.Framework;

namespace UsStateMapper.Tests.EndToEndTests {
  [TestFixture]
  public class OldGpoAbbreviationsInputTest {
    private StateMapper subject;

    [SetUp]
    public void SetUp() {
      subject = new StateMapper();
    }

    [TestCase("Ala.", "Alabama")]
    [TestCase("Ariz.", "Arizona")]
    [TestCase("Ark.", "Arkansas")]
    [TestCase("Calif.", "California")]
    [TestCase("Colo.", "Colorado")]
    [TestCase("Conn.", "Connecticut")]
    [TestCase("Del.", "Delaware")]
    [TestCase("D.C.", "District of Columbia")]
    [TestCase("Fla.", "Florida")]
    [TestCase("Ga.", "Georgia")]
    [TestCase("Ill.", "Illinois")]
    [TestCase("Ind.", "Indiana")]
    [TestCase("Kans.", "Kansas")]
    [TestCase("Ky.", "Kentucky")]
    [TestCase("La.", "Louisiana")]
    [TestCase("Md.", "Maryland")]
    [TestCase("Mass.", "Massachusetts")]
    [TestCase("Mich.", "Michigan")]
    [TestCase("Minn.", "Minnesota")]
    [TestCase("Miss.", "Mississippi")]
    [TestCase("Mo.", "Missouri")]
    [TestCase("Mont.", "Montana")]
    [TestCase("Nebr.", "Nebraska")]
    [TestCase("Nev.", "Nevada")]
    [TestCase("N.H.", "New Hampshire")]
    [TestCase("N.J.", "New Jersey")]
    [TestCase("N.M.", "New Mexico")]
    [TestCase("N.Y.", "New York")]
    [TestCase("N.C.", "North Carolina")]
    [TestCase("N. Dak.", "North Dakota")]
    [TestCase("Okla.", "Oklahoma")]
    [TestCase("Oreg.", "Oregon")]
    [TestCase("Pa.", "Pennsylvania")]
    [TestCase("R.I.", "Rhode Island")]
    [TestCase("S.C.", "South Carolina")]
    [TestCase("S. Dak.", "South Dakota")]
    [TestCase("Tenn.", "Tennessee")]
    [TestCase("Tex.", "Texas")]
    [TestCase("Vt.", "Vermont")]
    [TestCase("Va.", "Virginia")]
    [TestCase("Wash.", "Washington")]
    [TestCase("W. Va.", "West Virginia")]
    [TestCase("Wis.", "Wisconsin")]
    [TestCase("Wyo.", "Wyoming")]
    [TestCase("A.S.", "American Samoa")]
    [TestCase("M.P.", "Northern Mariana Islands")]
    [TestCase("P.R.", "Puerto Rico")]
    [TestCase("V.I.", "U.S. Virgin Islands")]
    public void ToState_Matches_State_When_Old_GPO_Abbreviations_Are_Supplied(string oldGpoAbbrev, string expectedState) {
      var result = subject.ToState(oldGpoAbbrev);

      Assert.That(result, Is.EqualTo(expectedState));
    }
  }
}