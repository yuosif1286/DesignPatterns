// See https://aka.ms/new-console-template for more information

using DesignPatterns;

var invoice = new Invoice(123, 1000m, "Software Dev Services");

invoice.Pay();
invoice.Refund();
invoice.Cancel();