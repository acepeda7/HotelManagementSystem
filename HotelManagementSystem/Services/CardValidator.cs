using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public static class CardValidator
    {
        public static bool IsValid(string? cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                return false;
            }

            cardNumber = cardNumber.Replace(" ", string.Empty);

            if (cardNumber.Length < 13 ||
                cardNumber.Length > 19 ||
                !cardNumber.All(char.IsDigit))
            {
                return false;
            }

            int sum = 0;
            bool doubleDigit = false;

            for (int index = cardNumber.Length - 1;
                 index >= 0;
                 index--)
            {
                int digit = cardNumber[index] - '0';

                if (doubleDigit)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            return sum % 10 == 0;
        }
    }
}