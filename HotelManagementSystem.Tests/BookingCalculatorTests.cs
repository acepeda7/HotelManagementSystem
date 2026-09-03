using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Services;
using Xunit;

namespace HotelManagementSystem.Tests
{
    public class BookingCalculatorTests
    {
        [Fact]
        public void CalculateNights_FiveNightStay_ReturnsFive()
        {
            DateTime checkIn = new DateTime(2026, 9, 10);
            DateTime checkOut = new DateTime(2026, 9, 15);

            int result =
                BookingCalculator.CalculateNights(
                    checkIn,
                    checkOut);

            Assert.Equal(5, result);
        }

        [Fact]
        public void CalculateNights_OneNightStay_ReturnsOne()
        {
            DateTime checkIn = new DateTime(2026, 9, 10);
            DateTime checkOut = new DateTime(2026, 9, 11);

            int result =
                BookingCalculator.CalculateNights(
                    checkIn,
                    checkOut);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CalculateSubtotal_PriceAndNights_ReturnsCorrectAmount()
        {
            decimal result =
                BookingCalculator.CalculateSubtotal(
                    125m,
                    4);

            Assert.Equal(500m, result);
        }

        [Fact]
        public void CalculateDiscount_TenPercent_ReturnsCorrectAmount()
        {
            decimal result =
                BookingCalculator.CalculateDiscount(
                    500m,
                    10m);

            Assert.Equal(50m, result);
        }

        [Fact]
        public void CalculateDiscount_SeventyPercent_ReturnsCorrectAmount()
        {
            decimal result =
                BookingCalculator.CalculateDiscount(
                    500m,
                    70m);

            Assert.Equal(350m, result);
        }

        [Fact]
        public void CalculateDiscount_ResultIsRoundedToTwoDecimals()
        {
            decimal result =
                BookingCalculator.CalculateDiscount(
                    333.33m,
                    15m);

            Assert.Equal(50.00m, result);
        }

        [Fact]
        public void CalculateTotal_SubtractsDiscount()
        {
            decimal result =
                BookingCalculator.CalculateTotal(
                    500m,
                    75m);

            Assert.Equal(425m, result);
        }

        [Fact]
        public void CalculateTotal_WithoutDiscount_ReturnsSubtotal()
        {
            decimal result =
                BookingCalculator.CalculateTotal(
                    500m,
                    0m);

            Assert.Equal(500m, result);
        }
    }
}
