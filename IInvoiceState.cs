namespace DesignPatterns;

public interface IInvoiceState
{
    void Pay(Invoice invoice);
    void Cancel(Invoice invoice);
    void Refund(Invoice invoice);
}