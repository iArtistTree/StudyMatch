using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Services
{
    public record ServiceResult(bool Success, string? Error = null)
    {
        public static ServiceResult Ok() => new(true);
        public static ServiceResult Fail(string error) => new(false, error);
    }
}