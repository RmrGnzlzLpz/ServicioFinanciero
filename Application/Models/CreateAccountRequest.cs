namespace Application.Models
{
  public class CreateFinancialServiceRequest
  {
    public string Name { get; set; }
    public int AccountType { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
  }
  public class CreateFinancialServiceResponse
  {
    public string Message { get; set; }
  }
}