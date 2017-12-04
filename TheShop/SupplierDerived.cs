
namespace TheShop
{
    public class Supplier1 : Supplier
    {
        public override Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                NameOfArticle = "Article from supplier1",
                ArticlePrice = 458
            };
        }
    }

    public class Supplier2 : Supplier
    {
        public override Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                NameOfArticle = "Article from supplier2",
                ArticlePrice = 459
            };
        }
    }

    public class Supplier3 : Supplier
    {
        public override Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                NameOfArticle = "Article from supplier3",
                ArticlePrice = 460
            };
        }
    }
}
