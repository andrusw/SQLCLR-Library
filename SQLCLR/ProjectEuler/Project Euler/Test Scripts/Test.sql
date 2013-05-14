--sum of multiple of 3 or 5 below 1000 Ans: 233168
select dbo.SumMultiplesBelow(3,5,1000)

--sum even fibonacci numbers less than 4 million Ans: 4613732
select dbo.SumEvenFibonacci(4000000)

--largest prime factor of 600851475143 Ans: 6857
select dbo.LargestPrimeFactor(600851475143)

--A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
--Find the largest palindrome made from the product of two 3-digit numbers. Ans: 906609
select dbo.LargestPalindromeFromNdigitSize(3)

--2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
--What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?  Ans: 232792560 
select dbo.SmallestNumberDivisibleByRange(1,20) --a slow 21 seconds

--The sum of the squares of the first ten natural numbers is,
--12 + 22 + ... + 102 = 385
--The square of the sum of the first ten natural numbers is,
--(1 + 2 + ... + 10)2 = 552 = 3025
--Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
--Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.  Ans: 25164150 
select dbo.SquareSumRange(1,100) - dbo.SumSquareRange(1,100)

--By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
--What is the 10 001st prime number? Ans: 104743 
select dbo.nthPrime(10001)






