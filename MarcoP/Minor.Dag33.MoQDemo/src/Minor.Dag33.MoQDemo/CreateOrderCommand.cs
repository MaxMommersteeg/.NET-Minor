using System;

public class CreateOrderCommand
{
    public long Ordernumber { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliverDate { get; set; }
    public Address DeliveryAddress { get; set; }

}