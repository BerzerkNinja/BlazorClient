using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logic
{
    public class LocalStorage
    {
        private IJSRuntime _jsRuntime;

        public LocalStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task SetItem(string key, object data)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            return _jsRuntime.InvokeAsync<object>("berzerkNinja.localStorage.setItem", key, JsonSerializer.Serialize(data));
        }

        public async Task<T> GetItem<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            var serialisedData = await _jsRuntime.InvokeAsync<string>("berzerkNinja.localStorage.getItem", key);

            if (serialisedData == null)
                return default(T);

            return JsonSerializer.Deserialize<T>(serialisedData);
        }

        public Task RemoveItem(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            return _jsRuntime.InvokeAsync<string>("berzerkNinja.localStorage.removeItem", key);
        }

        public Task Clear() => _jsRuntime.InvokeAsync<bool>("berzerkNinja.localStorage.clear");

        public Task<int> Length() => _jsRuntime.InvokeAsync<int>("berzerkNinja.localStorage.length");

        public Task<string> Key(int index) => _jsRuntime.InvokeAsync<string>("berzerkNinja.localStorage.key", index);
    }
}