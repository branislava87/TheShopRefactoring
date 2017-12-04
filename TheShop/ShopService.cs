using System;
using System.Collections.Generic;

namespace TheShop
{
    public class ShopService
    {
        private DatabaseDriver databaseDriver;
        private Logger logger;

        public ShopService()
        {
            databaseDriver = new DatabaseDriver();
            logger = new Logger();
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            #region ordering article

            List<Supplier> suppliersList = new List<Supplier>() {
                new Supplier1(),
                new Supplier2(),
                new Supplier3()
            };

            Article article = null;
            for (int i = 0; i < suppliersList.Count; i++)
            {

                article = GetArticleDetails(suppliersList[i], maxExpectedPrice, id, i == suppliersList.Count - 1);
                if (article != null)
                    break;
            }

            #endregion

            #region selling article

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            logger.Debug("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                databaseDriver.Save(article);
                logger.Info("Article with id=" + id + " is sold.");
            }
            catch (ArgumentNullException)
            {
                logger.Error("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            #endregion
        }

        public void FindAndPrint(int id)
        {
            try
            {
                var article = databaseDriver.GetById(id);
                Console.WriteLine("Found article with ID: " + article.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Article not found: " + ex);
            }
        }

        private Article GetArticleDetails(Supplier supplier, int maxExpectedPrice, int id, bool lastSupplier)
        {
            var articleExists = supplier.ArticleInInventory(id);
            if (!articleExists)
                return null;

            var article = supplier.GetArticle(id);
            if (!lastSupplier && maxExpectedPrice < article.ArticlePrice)
                return null;

            return article;
        }
    }
}
