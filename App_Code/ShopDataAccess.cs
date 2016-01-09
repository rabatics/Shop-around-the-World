using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for ShopDataAccess
/// </summary>
public class ShopDataAccess
{
	public ShopDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static String getProductpath(int id)  
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "getProductpath";
        comm.CommandType = CommandType.StoredProcedure;

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();

        param1.ParameterName = "@pCountryId";
        param1.Value = id;
        param1.DbType = DbType.Int16;
        comm.Parameters.Add(param1);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@productPath";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.String;
        param3.Size = 500;
        comm.Parameters.Add(param3);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        String path = comm.Parameters["@productPath"].Value.ToString();
        return path;
    }


    public static DataTable GetProducts(String country)
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "SELECT Product.productName,Product.productShortDesc,Product.productPrice,Product.productImagePath,Country.countryName,Vendor.vendorName,Product.productId FROM dbo.Product INNER JOIN dbo.Country ON Product.productCountryId=Country.countryId INNER JOIN dbo.Vendor ON Product.vendorId=Vendor.vendorId  where dbo.Product.productCountryId='" + country + "';";
        comm.CommandType = CommandType.Text;
        // execute the stored procedure and return the results    
        return GenericDataAccess.ExecuteSelectCommand(comm);
        
    }

    public static Product GetProduct(int productId)
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "SELECT Product.productName,Product.productShortDesc,Product.productPrice,Product.productImagePath,Product.productQty,Country.countryName,Country.countryId,Vendor.vendorName,Vendor.vendorId,Product.productId,Product.productRating FROM dbo.Product INNER JOIN dbo.Country ON Product.productCountryId=Country.countryId INNER JOIN dbo.Vendor ON Product.vendorId=Vendor.vendorId  where dbo.Product.productId='" + productId + "';";
        comm.CommandType = CommandType.Text;
        // execute the stored procedure and return the results    
        DataTable table=GenericDataAccess.ExecuteSelectCommand(comm);
        DbDataReader reader = table.CreateDataReader();
        Product product = new Product();
        while (reader.Read())
        {
            product.setProductId(reader.GetInt32(9));
            product.setproductName(reader.GetString(0));
            product.setProductShortDesc(reader.GetString(1));
            product.setProductPrice(reader.GetDouble(2));
            product.setProductImagePath(reader.GetString(3));
            product.setProductQuantity(reader.GetInt32(4));
            product.setProductCountryId(reader.GetInt32(6));
            product.setproductVendorName(reader.GetString(7));
            product.setProductVendorId(reader.GetInt32(8));
            product.setProductRating(reader.GetInt32(10));
        }
        return product;
    }


    public static Product[] GetCart(int customerId)
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "SELECT ShoppingCart.customerId,ShoppingCart.productId,ShoppingCart.quantity,Product.productName,Product.productPrice,Product.productImagePath,Product.productCountryId,Product.categoryId,Product.vendorId,Product.productRating,Product.productShortDesc,Product.productLongDesc,Vendor.vendorName FROM dbo.ShoppingCart INNER JOIN dbo.Product ON ShoppingCart.productId=Product.productId INNER JOIN dbo.Vendor ON ShoppingCart.vendorId=Vendor.vendorId WHERE ShoppingCart.customerId="+customerId+";";
        comm.CommandType = CommandType.Text;
        // execute the stored procedure and return the results    
        comm.Connection.Open();
        DbDataReader reader = comm.ExecuteReader();
        Product[] product = new Product[20];
        int i = 0;
        while (reader.Read())
        {
            Product product1 = new Product();
            product1.setProductId(reader.GetInt32(1));
            product1.setproductName(reader.GetString(3));
            product1.setProductShortDesc(reader.GetString(10));
            product1.setProductPrice(reader.GetDouble(4));
            product1.setProductImagePath(reader.GetString(5));
            product1.setProductQuantity(reader.GetInt32(2));
            product1.setProductCountryId(reader.GetInt32(6));
            product1.setProductCategoryId(reader.GetInt32(7));
            product1.setProductLongDesc(reader.GetString(11));
            product1.setproductVendorName(reader.GetString(12));
            product1.setProductVendorId(reader.GetInt32(8));
            product1.setProductRating(reader.GetInt32(9));
            product1.addProduct(product1, product);
            
        }
        return product;
    }

    public static DataTable GetProductsConCat(String concat)
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "SELECT Product.productName,Product.productShortDesc,Product.productPrice,Product.productImagePath,Country.countryName,Vendor.vendorName,Product.productId  FROM dbo.Product INNER JOIN dbo.Country ON Product.productCountryId=Country.countryId INNER JOIN dbo.Vendor ON Product.vendorId=Vendor.vendorId  where " + concat + ";";
        comm.CommandType = CommandType.Text;
        // execute the stored procedure and return the results    
        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    public static DataTable GetCountries()
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "SELECT countryId,countryName FROM dbo.Country;";
        comm.CommandType = CommandType.Text;
        // execute the stored procedure and return the results    
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable GetCategories(String countryid)
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "SELECT categoryId,categoryName FROM dbo.ProductCategory where countryId='"+countryid+"' ;";
        comm.CommandType = CommandType.Text;
        // execute the stored procedure and return the results    
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    
    public static int changePassword(string oldpwd, string login, out int flag)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        
        // set the stored procedure name
        comm.CommandText = "changePassword";
        comm.CommandType = CommandType.StoredProcedure;
        
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        
        param1.ParameterName = "@loginId";
        param1.Value = login;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@OldPassword";
        param2.Value = oldpwd;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@flag";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.String;
        param3.Size = 1;
        comm.Parameters.Add(param3);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        int num = Int32.Parse(comm.Parameters["@flag"].Value.ToString());
        flag = num;
        return num;
    }
}
