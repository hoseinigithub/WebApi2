namespace Common;

public class ResultDto
{
    public bool IsSucces { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
}

public class Result<T> : ResultDto
{
    public T Data { get; set; }
}