﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiniLotto.API.Extensions;

public static class JsonExtensions
{
    public static T? RemoveCycles<T>(this T obj)
    {
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase

        };

        var serializedObj = JsonSerializer.Serialize(obj, options);

        return JsonSerializer.Deserialize<T?>(serializedObj, options);
    }
}