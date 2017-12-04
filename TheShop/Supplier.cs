using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public abstract class Supplier
    {

        public abstract Article GetArticle(int id);

        public virtual bool ArticleInInventory(int id)
        {
            return true;
        }
    }
}
