--To be used on Adventure Works sample database
EXEC InsertCurrency_CS 'AAA', 'Currency Test'

SELECT * from Sales.Currency where CurrencyCode = 'AAA'


