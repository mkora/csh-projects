## ASP.NET API. List of Products

### Notes

- Using in-memory DB, Entity DB Context

- [Task Class](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=netframework-4.7.2)

- [API Exmaple](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio)

- Postman for testing

### API Endpoints

- Get all products

	- Route: GET https://localhost:44347/api/products

- Add a new product to a list
	
	- Route: POST https://localhost:44347/api/products

	- Header: Content-Type: application/json
	
	- Body (raw):

	```
	{
		"Id": 1,
		"Name": "Product",
		"Price": 100.00,
		"Description": "This a test product"
	}
	```

- Update a product

	- Route: PUT https://localhost:44347/api/products/1

	- Header: Content-Type: application/json
	
	- Body (raw):

	```
	{
		"Name": "New Product Name"
	}
	```

- Delete a product

	- Route: DELETE https://localhost:44347/api/products/1

	- Header: Content-Type: application/json