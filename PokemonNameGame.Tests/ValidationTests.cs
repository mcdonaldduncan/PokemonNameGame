using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PokemonNameGame.Tests
{
    public class ValidationTests
    {
        [Fact]
        public void TestRequiredAttribute()
        {
            var validator = new CustomRequiredAttribute();
            var toValidate = new GameServiceModel();

            var validationContext = new ValidationContext(toValidate);
            var validationResult = validator.GetValidationResult(toValidate, validationContext);

            Assert.Null(validationResult);
        }

        [Fact]
        void TestInvalidAttribute()
        {
            var test = new GameServiceModel();
            var context = new ValidationContext(test);
            var errors = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(test, context, errors, true));
        }
    }
}