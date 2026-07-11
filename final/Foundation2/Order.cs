using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    public List<Product> Products
    {
        get { return _products; }
        set { _products = value; }
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5.00 : 35.00;
        
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING SLIP\n";
        label += "------------\n";
        foreach (Product product in _products)
        {
            label += $"[{product.ProductId}] {product.Name} (Qty: {product.Quantity})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL\n";
        label += "--------------\n";
        label += $"{_customer.Name}\n";
        label += $"{_customer.Address.GetFullAddress()}";
        return label;
    }
}