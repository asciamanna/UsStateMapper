using System;
using NUnit.Framework;

namespace UsStateMapper.Tests {
  [TestFixture]
  public class StateNotFoundExceptionTest {
    [Test]
    public void StateNotFoundException_Default_Constructor() {
      var expectedMessage = "Exception of type 'UsStateMapper.StateNotFoundException' was thrown.";
      
      var subject = new StateNotFoundException();

      Assert.That(subject.Message, Is.EqualTo(expectedMessage));
      Assert.That(subject.InnerException, Is.Null);
    }

    [Test]
    public void StateNotFoundException_Message_Constructor() {
      var customErrorMessage = "Custom Error Message";

      var subject = new StateNotFoundException(customErrorMessage);
     
      Assert.That(subject.Message, Is.EqualTo(customErrorMessage));
      Assert.That(subject.InnerException, Is.Null);
    }

    [Test]
    public void StateNotFoundException_Message_InnerException_Constructor() {
      var customErrorMessage = "Custom Error Message";
      var innerException = new Exception();

      var subject = new StateNotFoundException(customErrorMessage, innerException);

      Assert.That(subject.Message, Is.EqualTo(customErrorMessage));
      Assert.That(subject.InnerException, Is.SameAs(innerException));

    }
  }
}
