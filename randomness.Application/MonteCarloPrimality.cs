namespace randomness.Application
{
    public class MonteCarloPrimality
    {
        // Determines whether a given number 'n' is *probably* prime using the Monte Carlo method.
        // 'k' specifies the number of iterations, increasing reliability.
        public static bool IsProbablyPrime(long n, int k = 5)
        {
            // Handle edge cases: numbers less than 2 are not prime.
            if (n < 2) return false;
            // Special cases: 2 and 3 are prime numbers.
            if (n == 2 || n == 3) return true;
            // Eliminate even numbers (except 2), which are obviously composite.
            if (n % 2 == 0) return false;

            // Express 'n - 1' in the form (2^r) * d + 1, where 'd' is odd.
            long d = n - 1;
            int r = 0;
            while (d % 2 == 0)
            {
                r++;   // Count the power of 2 factor
                d /= 2; // Reduce 'd' until it is odd
            }

            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                // Select a random base 'a' in range [2, n-2]
                long a = 2 + rand.Next() % (n - 3);
                // Compute a^d mod n
                long x = ModPow(a, d, n);

                // If x == 1 or x == n-1, the base 'a' suggests primality
                if (x == 1 || x == n - 1) continue;

                bool found = false;
                // Iterate 'r-1' times to check higher power residues
                for (int j = 0; j < r - 1; j++)
                {
                    x = ModPow(x, 2, n); // Compute x² mod n
                    if (x == n - 1)
                    {
                        found = true; // A witness found, move to next iteration
                        break;
                    }
                }
                // If no witness was found, 'n' is composite
                if (!found) return false;
            }

            // If none of the k tests proved 'n' composite, it's *probably* prime
            return true;
        }

        // Computes (baseValue^exp) % mod using efficient modular exponentiation (fast exponentiation method)
        private static long ModPow(long baseValue, long exp, long mod)
        {
            long result = 1;
            while (exp > 0)
            {
                // If the current bit of 'exp' is set, multiply 'result' by baseValue
                if ((exp & 1) == 1) result = (result * baseValue) % mod;

                // Square baseValue and reduce the exponent by half
                baseValue = (baseValue * baseValue) % mod;
                exp >>= 1; // Bit-shift right to halve the exponent
            }
            return result;
        }
    }
}
