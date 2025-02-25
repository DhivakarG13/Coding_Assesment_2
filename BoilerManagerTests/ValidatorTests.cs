using BoilerManager.Helpers;

namespace BoilerManagerTests
{
    public class ValidatorTests
    {
        [InlineData("1",1)]
        [InlineData("1",4)]
        [InlineData("2",4)]
        [InlineData("3",4)]
        [InlineData("4",4)]
        public void ChoiceAndTotalChoices_ValidateChoice_ReturnsTrueIfValidChoice(string? Choice, int TotalChoices)
        {

            bool actualResult = ValidationServiceUtility.ValidateChoice(Choice, TotalChoices);

            Assert.True(actualResult);
        }

        [InlineData("", 1)]
        [InlineData("1A", 4)]
        [InlineData("2 2", 4)]
        [InlineData("*", 4)]
        [InlineData(null, 4)]
        public void ChoiceAndTotalChoices_ValidateChoice_ReturnsFalseIfInValidChoice(string? Choice, int TotalChoices)
        {

            bool actualResult = ValidationServiceUtility.ValidateChoice(Choice, TotalChoices);

            Assert.False(actualResult);
        }

        [InlineData("5", 1)]
        [InlineData("6", 4)]
        [InlineData("7", 4)]
        [InlineData("88", 4)]
        [InlineData("9", 4)]
        public void ChoiceAndTotalChoices_ValidateChoice_ReturnsFalseIfOutOfRangeValidChoice(string? Choice, int TotalChoices)
        {

            bool actualResult = ValidationServiceUtility.ValidateChoice(Choice, TotalChoices);

            Assert.False(actualResult);
        }
    }
}