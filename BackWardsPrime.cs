/*Description:

Backwards Read Primes are primes that when read backwards in base 10 (from right to left) are a different prime. 
(This rules out primes which are palindromes.)

Examples:
13 17 31 37 71 73 are Backwards Read Primes
13 is such because it's prime and read from right to left writes 31 which is prime too. Same for the others.

Task:
Find all Backwards Read Primes between two positive given numbers (both inclusive), the second one being greater than the first one. 
The resulting array or the resulting string will be ordered following the natural order of the prime numbers.

backwardsPrime(2, 100) => "13 17 31 37 71 73 79 97"
backwardsPrime(9900, 10000) => "9923 9931 9941 9967"*/

using System.Linq;
using System;
using System.Collections.Generic;

public class BackWardsPrime {
  
  public static string backwardsPrime(long start, long end) {
    Console.WriteLine(start + ", " + end);
  
    int[] numArray = Enumerable.Range((int)start, ((int)end - (int)start + 1)).ToArray();
    return String.Join(" ", numArray.Where(x => isPrime(Int32.Parse(x.ToString())) && isPrime(Int32.Parse(String.Join("", x.ToString().Reverse()))))
        .Select(y => y).Where(n => n != Int32.Parse(String.Join("", n.ToString().Reverse()))).Select(a => a));
  }
  
  public static bool isPrime(int number){
    if(number < 10)
        return false;     

    int numberOfDivisors = 0;

    for(int i = 2; i <= Math.Sqrt(number); i++)
    {
        if(number % i == 0)
            numberOfDivisors++;
    }
    
    if(numberOfDivisors == 0)
        return true;
    else
        return false; 
  }
}
