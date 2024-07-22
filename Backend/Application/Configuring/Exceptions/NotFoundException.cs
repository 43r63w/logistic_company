namespace Application.Configuring.Exceptions;


public class NotFoundException : Exception
{
    public NotFoundException(string? name = null, string? key = null) : base($"{name},{key} was not found")
    {
    }
}