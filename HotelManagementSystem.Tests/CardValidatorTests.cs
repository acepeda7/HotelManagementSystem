using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Services;
using Xunit;

namespace HotelManagementSystem.Tests
{
    public class CardValidatorTests
    {
        [Theory]
        [InlineData("4242 4242 4242 4242")]
        [InlineData("4111111111111111")]
        [InlineData("5555555555554444")]
        [InlineData("4111 1111 1111 1111")]
        public void IsValid_ValidCardNumber_ReturnsTrue(
            string cardNumber)
        {
            // Act
            bool result = CardValidator.IsValid(cardNumber);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("4111111111111112")]
        [InlineData("5555555555554445")]
        public void IsValid_InvalidLuhnNumber_ReturnsFalse(
            string cardNumber)
        {
            // Act
            bool result = CardValidator.IsValid(cardNumber);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("123")]
        [InlineData("4111abcd11111111")]
        [InlineData("4111-1111-1111-1111")]
        [InlineData("41111111111111111111")]
        public void IsValid_InvalidFormat_ReturnsFalse(
            string cardNumber)
        {
            // Act
            bool result = CardValidator.IsValid(cardNumber);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_NullCardNumber_ReturnsFalse()
        {
            // Act
            bool result = CardValidator.IsValid(null);

            // Assert
            Assert.False(result);
        }
    }
}