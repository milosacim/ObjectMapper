using ObjectConversion;

CustomMapper service = new();

Product product = new Product { Id=1, Name="Single product", Description="Another test"};
ProductDto productDto = service.MapObject<Product, ProductDto>(product);

Person person = new()
{
    Id = 1,
    FirstName = "Milos",
    LastName = "Acimovic"
};

PersonDto personDto = service.MapObject(person, (PersonDto dto) => dto.FullName = $"{person.FirstName} {person.LastName}");

List<Product> products = new();

for (var i = 0; i < 2; i++)
{
    products.Add(new Product { Id = i, Name = $"Product {i}", Description = $"This is a test{i}." });
}

List<ProductDto> productDtos = new();

productDtos = service.MapObjects<Product, ProductDto>(products);

foreach (ProductDto dto in productDtos)
{
    Console.WriteLine($"Name: {dto.Name}, Description: {dto.Description}");
}

Console.WriteLine($"\nSingle product:\nName: {productDto.Name}, Description: {productDto.Description}");

Console.WriteLine($"\nPerson with custom Map:\nFull Name: {personDto.FullName}");

Console.ReadLine();