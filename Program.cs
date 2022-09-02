using System;
using System.Collections.Generic;
using System.Linq;

namespace RaiseToThePowerOf
{
    class Program
    {
        static void Main(string[] args)
        {
            float inputNumber = 2;
            int inputPower = 10;

            float result = RaiseToThePower(inputNumber, inputPower);

            Console.WriteLine(result);
        }

        private static float RaiseToThePower(float inputNumber, int inputPower)
        {
            Dictionary<int, float> firstIterationPowersAndNumbers = new Dictionary<int, float>();

            int baseSquarePower = 2;

            float minusOnePowerIteration;

            firstIterationPowersAndNumbers.Add(1, inputNumber);

            // With each step we raise a number in the power of n (n1 = 1, n++) to the power of 2, and add each result to the dictionary, until n * 2 becomes > p
            for (int i = 1; i * baseSquarePower < inputPower; i++)
            {
                int currentPower = i * baseSquarePower;

                minusOnePowerIteration = RaiseToThePowerUnoptimized(inputNumber, currentPower - 1);

                firstIterationPowersAndNumbers.Add(currentPower, inputNumber * minusOnePowerIteration);
            }

            // To get the input number raised to the target power we multiply the number raised to the power of m(first power component)
            // by the number raised to the power of n (second power component), so inputPower = n + m
            int firstPowerComponent = firstIterationPowersAndNumbers.Keys.Last<int>(); // !!!INCORRECT!!!

            int secondPowerComponent = inputPower - firstPowerComponent; // !!!INCORRECT!!! it uses the number before the inputPower, it can be very high, NEEDS FIXING

            float result = firstIterationPowersAndNumbers[secondPowerComponent] * firstIterationPowersAndNumbers[firstPowerComponent];

            return result;

        }

        private static float RaiseToThePowerUnoptimized(float inputNumber, int inputPower) 
        {
            int curentIteration = 1;

            float baseNumber, outputNumber = baseNumber = inputNumber;

            while (curentIteration < inputPower)
            {
                outputNumber *= baseNumber;

                curentIteration++;
            }

            return outputNumber;
        }
    }
}
