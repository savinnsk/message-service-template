using Domain.Records;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

internal static class HttpResult
{
    public static IActionResult From(Result<string> result)
    {
        var body = result.Success ? result.Data : result.Error;

        return new ContentResult
        {
            StatusCode = result.StatusCode,
            Content = string.IsNullOrWhiteSpace(body) ? "{}" : body,
            ContentType = "application/json"
        };
    }
}
