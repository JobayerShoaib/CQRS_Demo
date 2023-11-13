using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Common.Models;

public class Result<T>
{
    public Result()
    {

    }
    internal Result(int succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }
    internal Result(int succeeded, T _data, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
        Data = _data;
    }
    public T Data { get; set; }
    /// <summary>
    /// 0 Failed
    /// 1 Success
    /// :: ::
    /// </summary>
    public int Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;

    public string[] Errors { get; set; }
    public Result<string> Update(string message = "Update Successfully")
    {
        return new Result<string>(1, message, Array.Empty<string>());
    }
    public Result<T> Success()
    {
        return new Result<T>(1, Array.Empty<string>());
    }
    public Result<T> Success(T data)
    {
        return new Result<T>(1, data, Array.Empty<string>());
    }
    public Result<T> Failure(IEnumerable<string> errors)
    {
        return new Result<T>(0, errors);
    }
    public Result<T> NoRecordFound()
    {
        return new Result<T>(2, new[] { "No Record Found." });
    }
}
public class Result
{
    public Result()
    {

    }
    internal Result(int succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }
    internal Result(int succeeded, string message, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
        Message = message;
    }

    public int Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;

    public string[] Errors { get; set; }

    public Result Update(string message = "Updated Successfully")
    {
        return new Result(1, message, Array.Empty<string>());
    }
    //public Result Success()
    //{
    //    return new Result(1, Array.Empty<string>());
    //}

    public Result Success(string message = "Saved Successfully")
    {
        return new Result(1, message, Array.Empty<string>());
    }

    public Result Failure(IEnumerable<string> errors)
    {
        return new Result(0, errors);
    }
    public Result Failure(string message, IEnumerable<string> errors)
    {
        return new Result(0, message, errors);
    }
}