﻿namespace UpSchoolEcommerce.Shared.Dtos;
public class ResponseDto<T>
{
    public T Data { get; set; }
    public int StatusCode { get; set; }
    public bool IsSuccessful { get; set; }
    public List<string> Errors { get; set; }
    public static ResponseDto<T> Success(T data, int statusCode)
    {
        return new ResponseDto<T>
        {
            Data = data,
            StatusCode = statusCode,
            IsSuccessful = true
        };
    }
    public static ResponseDto<T> Success(int statusCode)
    {
        return new ResponseDto<T>
        {
            Data = default(T),
            StatusCode = statusCode,
            IsSuccessful = true,
        };
    }

    public static ResponseDto<T> Fail(List<string> errors, int statusCode)
    {
        return new ResponseDto<T>
        {
            Errors = errors,
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }

    public static ResponseDto<T> Fail(string error, int statusCode)
    {
        return new ResponseDto<T>
        {
            Errors = new List<string> { error },
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }
}
