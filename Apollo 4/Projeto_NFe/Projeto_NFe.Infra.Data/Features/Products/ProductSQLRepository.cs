using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Products
{
    public class ProductSQLRepository : IProductRepository
    {
        private readonly string SQL_INSERT = "INSERT INTO TBProduct (Code,Description, UnitaryValue) VALUES (@Code,@Description, @UnitaryValue)";
        private readonly string SQL_UPDATE = "UPDATE TBProduct SET Code = @Code, Description = @Description, UnitaryValue = @UnitaryValue WHERE IdProduct = @IdProduct";
        private readonly string SQL_GET = "SELECT * FROM TBProduct WHERE IdProduct = @IdProduct";
        private readonly string SQL_GETALL = "SELECT * FROM TBProduct";
        private readonly string SQL_DELETE = "DELETE FROM TBProduct WHERE IdProduct = @IdProduct";
        private readonly string SQL_CHECK_DEPENDENCY = "SELECT CAST(CASE WHEN EXISTS(SELECT IdProduct FROM TBProduct INNER JOIN TBItemInvoice ON IdProduct = ProductId WHERE IdProduct = @IdProduct) THEN 1 ELSE 0 END AS BIT) AS Exist";

        private readonly long _lessThan = 1;
        private readonly int _exist = 1;

        public Product Save(Product product)
        {
            product.Validate();
            product.Id = Db.Insert(SQL_INSERT, Take(product, false));

            return product;
        }

        public Product Update(Product product)
        {
            if (product.Id < _lessThan)
                throw new IdentifierUndefinedException();

            product.Validate();
            Db.Update(SQL_UPDATE, Take(product));

            return product;
        }

        public Product Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return Db.Get(SQL_GET, Make, new object[] { "@IdProduct", id });
        }

        public IEnumerable<Product> GetAll()
        {
            return Db.GetAll(SQL_GETALL, Make);
        }

        public void Delete(Product product)
        {
            if (product.Id < _lessThan)
                throw new IdentifierUndefinedException();

            Db.Delete(SQL_DELETE, new object[] { "@IdProduct", product.Id });
        }

        public bool CheckDependency(Product product)
        {
            int result = Db.Get(SQL_CHECK_DEPENDENCY, MakeExist, new object[]
                {
                "@IdProduct", product.Id
                }
            );

            return result == _exist;
        }

        private static Func<IDataReader, int> MakeExist = ReadInt;

        private static int ReadInt(IDataReader reader)
        {
            return Convert.ToInt32(reader["Exist"]);
        }

        private static Func<IDataReader, Product> Make = reader =>
         new Product
         {
             Id = Convert.ToInt64(reader["IdProduct"]),
             Code = Convert.ToString(reader["Code"]),
             Description = Convert.ToString(reader["Description"]),
             UnitaryValue = Convert.ToDouble(reader["UnitaryValue"])
         };

        private object[] Take(Product product, bool hasId = true)
        {
            object[] parametros = null;
            if (hasId)
            {
                parametros = new object[]
                    {
                "@Code", product.Code,
                "@Description", product.Description,
                "@UnitaryValue", product.UnitaryValue,
                "@IdProduct", product.Id
                };
            }
            else
            {
                parametros = new object[]
              {
                "@Code", product.Code,
                "@Description", product.Description,
                "@UnitaryValue", product.UnitaryValue
              };
            }

            return parametros;
        }
    }
}
