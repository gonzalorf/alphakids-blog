using Blazored.LocalStorage;
using System.Text.Json;

namespace NanoBlogEngine.BlazorSite.Extensions;

public static class LocalStorageExtension
{
    public static async Task StoreItem<T>(this ILocalStorageService storageService, string key, T item)
    {
        var jsonItem = JsonSerializer.Serialize(item);
        await storageService.SetItemAsync(key, jsonItem);
    }

    public static async Task<T> GetItem<T>(this ILocalStorageService storageService, string key)
    {
        try
        {
            var jsonItem = await storageService.GetItemAsync<string>(key);
            return JsonSerializer.Deserialize<T>(jsonItem);
        }
        catch
        {
            return default;
        }
    }
}
