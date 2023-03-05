using VpuDotnet.Entities;
using VpuDotnet.Contexts;
using System.Text.Json;

var context = new CoffeeContext();
context.Create(new Coffee
{
   CreatedAt =DateTime.Now,
    CoffeeName =  "Americano",
    CoffeeType = "Arabica",
    Count = 2,
    Price = 14
});
context.Create(new Coffee
{
    CreatedAt =DateTime.Now,
    CoffeeName = "Espresso",
    CoffeeType = "Robusta",
    Count = 1,
    Price = 9
});
context.Create(new Coffee
{
    CreatedAt =DateTime.Now,
    CoffeeName = "Latte",
    CoffeeType = "Arabica",
    Count = 1,
    Price = 20
});
context.Create(new Coffee
{
     CreatedAt =DateTime.Now,
    CoffeeName = "Mocachno",
    CoffeeType = "Arabica",
    Count = 3,
    Price = 18
});
context.Save();


context.PrintAllSortedByDate();
context.PrintAllSortedPrice();
context.GetAllMoney();

