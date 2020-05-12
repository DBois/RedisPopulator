# Redis Data Populator
This is just a simple program to populate your Redis database with data and headers from a CSV file.  
By default, this code will use elements at the first indices as the key for the hashes.  
```
InvoiceNo,StockCode,Description,Quantity,InvoiceDate,UnitPrice,CustomerID,Country
536365,85123A,WHITE HANGING HEART T-LIGHT HOLDER,6,12/1/2010 8:26,2.55,17850,United Kingdom
```
If your CSV data looks like the above, the keys will look like this:  
`InvoiceNo:536365` and the key will store the rest of the data in the hash.  
