namespace ExpenseApp.Extensions
{
    public record Result
    {
        public string Code { get; init; } = string.Empty;
        public bool Success => string.IsNullOrWhiteSpace(Code);

        public static Result Fail(ResultCode code) => new() { Code = code.ToString() };
    }

    public record Result<T>(T Data) : Result
    {
        public static Result<T> Ok(T data, string msg = "") => new(data);
        public static Result<T> Fail(ResultCode code) => new(default(T)!) { Code = code.ToString() };
    }

    public enum ResultCode
    {
        PROFILE_ALREADY_EXIST,
        PROFILE_DOES_NOT_EXIST,
        EXPENSE_DOES_NOT_EXIST,
    }
}
