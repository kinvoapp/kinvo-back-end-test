using Aliquota.Domain.Entities;
using Xunit;

namespace Aliquota.Domain.Test.Entities {
    public class UserTest {
        [Fact]
        public void SetPasswordAndVerifyPassword_ShouldReturnTrueOnPasswordOK() {
            var user = new User("kurt.godel@email.com", "Kurt Gödel");

            var password = "IFellIncomplete123";
            user.SetPassword(password);
            Assert.True(user.VerifyPassword(password));
        }

        [Fact]
        public void SetPasswordAndVerifyPassword_ShouldReturnFalseOnPasswordNotOK() {
            var user = new User("kurt.godel@email.com", "Kurt Gödel");

            var password = "IFellIncomplete123";
            var wrongPassword = "MathsIsComplete123";
            user.SetPassword(password);
            Assert.False(user.VerifyPassword(wrongPassword));
        }
    }
}