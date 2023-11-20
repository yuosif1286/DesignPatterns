# DesignPatterns
 
## Introduction to the C# State pattern

**The State pattern is a behavioral design pattern that allows an object to change its behavior when its internal state changes.

The State pattern is useful when the behavior of an object depends on its state and needs to change dynamically when its state changes.**

The following UML diagram illustrates the State pattern:
![Screenshot 2023-11-19 153647.png](Docs%2FMD%2FScreenshot%202023-11-19%20153647.png)


## The State pattern typically consists of the following participants:

* Context is an object that maintains the current state and provides an interface for the clients to interact with the object.
* IState is an interface that defines methods that the concrete states must implement.
* ConcreteState is the concrete class that provides a specific implementation of the IState interface. Each ConcreteState class represents the different behavior of the object.


#### When the state of the context changes, it delegates the behavior to the current ConcreteState object. The ConcreteState class implements the behavior associated with the state. It allows the object to change its behavior dynamically without changing its interface.

## C# State pattern example
Suppose you need to manage invoices with various states: unpaid, paid, canceled, and refunded:

![Screenshot 2023-11-19 155018.png](Docs%2FMD%2FScreenshot%202023-11-19%20155018.png)

### How it works.

First, define the IInvoiceState interface that has three methods Pay, Cancel, and Refund:

```csharp
public interface IInvoiceState
{
    void Pay(Invoice invoice);
    void Cancel(Invoice invoice);
    void Refund(Invoice invoice);
}
```

Second, define the Invoice class that has four properties Number, Amount, Description, and State. Note that this is for simplicity purposes. In the real-world application, an invoice may contain more information. The constructor of the Invoice class initializes the State property to the UnpaidState object:
```csharp
public class Invoice
{
        public int Number
        {
            get;
        }
        public decimal Amount
        {
            get;
        }
        public string Description
        {
            get;
        }
        public IInvoiceState State
        {
            get; set;
        }
    
        public Invoice(int number, decimal amount, string description)
        {
            Number = number;
            Amount = amount;
            Description = description;
    
            // Set the invoice as Unpaid
            State = new UnpaidState();
        }
    
    
        public void Pay()
        {
            State.Pay(this);
            State = new PaidState();
        }
    
        public void Cancel()
        {
            State.Cancel(this);
            State = new CanceledState();
        }
    
        public void Refund()
        {
            State.Refund(this);
            State = new RefundedState();
        }
}
```

Third, define the UnpaidState class that implements the IInvoiceState interface:

```csharp
public class UnpaidState : IInvoiceState
{
    public void Pay(Invoice invoice)
    {
        Console.WriteLine($"Paying invoice {invoice.Number}...");

    }

    public void Cancel(Invoice invoice)
    {
        Console.WriteLine($"Canceling invoice {invoice.Number}...");

    }

    public void Refund(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} is unpaid and cannot be refunded.");

    }
}
```
### An unpaid invoice can be paid or canceled but cannot be refunded.

Fourth, define the PaidState class that also implements the IInvoiceState interface:

```csharp
public class PaidState : IInvoiceState
{
    public void Pay(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} has already been paid.");
    }

    public void Cancel(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} cannot be cancelled.");
    }

    public void Refund(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} has been refunded.");
    }
}
```

### A paid invoice cannot be paid again or canceled but can be refunded.

Fifth define the CanceledState class that implements the IInvoiceState interface:

```csharp
public class CanceledState : IInvoiceState
{
    public void Pay(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} has been canceled and cannot be paid.");
    }

    public void Cancel(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} has already been canceled and cannot be canceled again.");
    }

    public void Refund(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} has been canceled and cannot be refunded.");
    }
}
```
### A canceled invoice cannot be canceled, refunded, or paid.

Similarly, a refunded invoice cannot be canceled, refunded, or paid:

```csharp
public class RefundedState : IInvoiceState
{
    public void Cancel(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} was refunded and cannot be cancelled.");

    }
    public void Pay(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} was refunded and cannot be paid.");

    }
    public void Refund(Invoice invoice)
    {
        Console.WriteLine($"Invoice {invoice.Number} cannot be refunded again.");
    }
}
```

#### Finally, create an invoice object and call the Pay() and Refund() method sequentially:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var invoice = new Invoice(123, 1000m, "Software Dev Services");

        invoice.Pay();
        invoice.Refund();
    }
}
```

# Summary
Use the State pattern to let an object change its behavior when its internal state changes.

# [Executed By *YOYO*]
### [FaceBook](https://www.facebook.com/profile.php?id=100009911341630)
### [Linked](https://www.linkedin.com/in/yuosif-raed-04a84621a/)
### WhatsApp : +9647737872034
