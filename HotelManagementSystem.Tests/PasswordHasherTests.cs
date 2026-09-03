using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Services;
using Xunit;

namespace HotelManagementSystem.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void VerifyPassword_CorrectPassword_ReturnsTrue()
        {
            // Arrange
            string password = "Hotel123!";
            string passwordHash =
                PasswordHasher.HashPassword(password);

            // Act
            bool result =
                PasswordHasher.VerifyPassword(
                    password,
                    passwordHash);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_IncorrectPassword_ReturnsFalse()
        {
            // Arrange
            string passwordHash =
                PasswordHasher.HashPassword("Hotel123!");

            // Act
            bool result =
                PasswordHasher.VerifyPassword(
                    "WrongPassword!",
                    passwordHash);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HashPassword_SamePassword_ProducesDifferentHashes()
        {
            // Arrange
            string password = "Hotel123!";

            // Act
            string firstHash =
                PasswordHasher.HashPassword(password);

            string secondHash =
                PasswordHasher.HashPassword(password);

            // Assert
            Assert.NotEqual(firstHash, secondHash);
        }

        [Fact]
        public void VerifyPassword_InvalidStoredHash_ReturnsFalse()
        {
            // Act
            bool result =
                PasswordHasher.VerifyPassword(
                    "Hotel123!",
                    "invalid-hash");

            // Assert
            Assert.False(result);
        }
    }
}