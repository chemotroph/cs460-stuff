  using System;
namespace lab3{
public class QueueUnderflowException :Exception
{
  public QueueUnderflowException(): base()
  {
    
  }

  public QueueUnderflowException(String message): base(message)
  {
    
  }
}
}