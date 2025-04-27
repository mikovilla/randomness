namespace randomness.Application
{
    public class MonteCarloPrimality
    {
        public static bool IsProbablyPrime(long n, int k = 5)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0) return false;

            // Write n as (2^r) * d + 1
            long d = n - 1;
            int r = 0;
            while (d % 2 == 0)
            {
                r++;
                d /= 2;
            }

            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                long a = 2 + rand.Next() % (n - 3); // Random base
                long x = ModPow(a, d, n);

                if (x == 1 || x == n - 1) continue;

                bool found = false;
                for (int j = 0; j < r - 1; j++)
                {
                    x = ModPow(x, 2, n);
                    if (x == n - 1)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) return false;
            }
            return true;
        }

        private static long ModPow(long baseValue, long exp, long mod)
        {
            long result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1) result = (result * baseValue) % mod;
                baseValue = (baseValue * baseValue) % mod;
                exp >>= 1;
            }
            return result;
        }
    }
}
