namespace Common.Contracts;

public record ErrorResponse
{
	public ICollection<Error> Errors { get; init; } = new List<Error>();
}

public record Error
{
	public string Message { get; init; }

	public Error(string message)
	{
		Message = message;
	}
}