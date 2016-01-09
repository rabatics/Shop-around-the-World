using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ProductCart
{
    private Product[] productCart;

    public Boolean isProductExists(int productId)
    {
        Boolean exists=false;
        for (int i = 0; i < productCart.Length; i++)
        {
            if (productCart[i].getProductId() == productId)
            {
                exists = true;
            }
        }
        return exists;
    }

    public void addProduct(Product product)
    {
        productCart[productCart.Length] = product;
    }

    public void delProduct(int productId)
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
    

    public double calcTotalPrice()
    {
        double total = 0.00;
        for (int i = 0; i < productCart.Length; i++)
        {
            total += (productCart[i].getProductQuantity() * productCart[i].getProductPrice());
        }
        return total;
    }
}