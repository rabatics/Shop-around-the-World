using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Product
{
    private String productName;
    private int productId;
    private double productPrice;
    private int productRating;
    private String productImagePath;
    private String productShortDesc;
    private String productLongDesc;
    private int productVendorId;
    private String productVendorName;
    private int productQuantity;
    private int productCategoryId;
    private int productCountryId;


    public String getProductName()
    {
        return productName;
    }

    public void setproductName(String newName)
    {
        this.productName = newName;
    }

    public String getProductVendorName()
    {
        return productVendorName;
    }

    public void setproductVendorName(String newProductVendorName)
    {
        this.productVendorName = newProductVendorName;
    }





    public int getProductId()
    {
        return productId;
    }

    public void setProductId(int newProductId )
    {
        this.productId = newProductId;
    }


    public int getProductRating()
    {
        return productRating;
    }

    public void setProductRating(int newProductRating)
    {
        this.productRating = newProductRating;
    }


    public double getProductPrice()
    {
        return productPrice;
    }

    public void setProductPrice(double newProductPrice)
    {
        this.productPrice = newProductPrice;
    }



    public String getProductImagePath()
    {
        return productImagePath;
    }

    public void setProductImagePath(String newProductImagePath)
    {
        this.productImagePath = newProductImagePath;
    }


    public String getProductShortDesc()
    {
        return productShortDesc;
    }

    public void setProductShortDesc(String newProductShortDesc)
    {
        this.productShortDesc = newProductShortDesc;
    }

    public String getProductLongDesc()
    {
        return productLongDesc;
    }

    public void setProductLongDesc(String newProductLongDesc)
    {
        this.productLongDesc = newProductLongDesc;
    }






    public int getProductVendorId()
    {
        return productVendorId;
    }

    public void setProductVendorId(int newProductVendorId)
    {
        this.productVendorId = newProductVendorId;
    }

    public int getProductQuantity()
    {
        return productQuantity;
    }

    public void setProductQuantity(int newProductQuantity)
    {
        this.productQuantity = newProductQuantity;
    }
    public int getProductCategoryId()
    {
        return productCategoryId;
    }

    public void setProductCategoryId(int newProductCategoryId)
    {
        this.productCategoryId = newProductCategoryId;
    }

    public int getProductCountryId()
    {
        return productCountryId;
    }

    public void setProductCountryId(int newProductCountryId)
    {
        this.productCountryId = newProductCountryId;
    }

    public string isProductExists(int productId,Product[] productCart)
    {
        Boolean exists = false;
        int pos = 0;
        string reply = null;
        for (int i = 0; i < productCart.Length; i++)
        {
            if (productCart[i] != null)
            {
                if (productCart[i].getProductId() == productId)
                {
                    exists = true;
                    pos = i;
                    break;
                }
            }
        }
        reply = exists + "," + pos;
        return reply;
    }

    public void addProduct(Product product, Product[] productCart)
    {
        string reply = product.isProductExists(product.getProductId(), productCart);
        string[] exists = reply.Split(',');
        if (exists[0] == "true")
        {
            productCart[Int32.Parse(exists[1])].setProductQuantity(productCart[Int32.Parse(exists[1])].getProductQuantity() + 1);
        }
        else
        {
            for (int i = 0; i < productCart.Length; i++)
            {


                if (productCart[i] == null)
                {

                    productCart[i] = product;
                    break;
                }
            }
        }
    }

    public void delProduct(int productId, Product[] productCart)
    {
        for (int i = 0; i < productCart.Length; i++)
        {
            if (productCart[i].getProductId() == productId)
            {
                productCart[i] = null;
                for (int j = i; j < productCart.Length; j++)
                {
                    productCart[j] = productCart[j + 1];
                }
            }
        }
    }


    public double calcTotalPrice(Product[] productCart)
    {
        double total = 0.00;
        for (int i = 0; i < productCart.Length; i++)
        {
            if (productCart[i] != null) { 
            total += (productCart[i].getProductQuantity() * productCart[i].getProductPrice());
        }
        }
        return total;
    }


}