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

    // Getter and Setter methods
    public Customer GetCustomer() { return _customer; }
    public void SetCustomer(Customer customer) { _customer = customer; }

    public List<Product> GetProducts() { return _products; }
    public void SetProducts(List<Product> products) { _products = products; }

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
            label += $"[{product.GetProductId()}] {product.GetName()} (Qty: {product.GetQuantity()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL\n";
        label += "--------------\n";
        label += $"{_customer.GetName()}\n";
        label += $"{_customer.GetAddress().GetFullAddress()}";
        return label;
    }
}