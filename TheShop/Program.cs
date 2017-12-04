using System;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
        var shopService = new ShopService();

			//order and sell
			shopService.OrderAndSellArticle(1, 20, 10);
	
            //print article on console
            shopService.FindAndPrint(1);
            shopService.FindAndPrint(12);

            Console.ReadKey();
		}
	}
}