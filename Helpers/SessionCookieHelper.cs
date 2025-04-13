using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class SessionCookieHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionCookieHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // Session Methods
    public void SetSession<T>(string key, T value)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public T GetSession<T>(string key)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var value = session.GetString(key);
        return value == null ? default : JsonConvert.DeserializeObject<T>(value);
    }

    // Cookie Methods
    public void SetCookie(string key, string value, int? expireTime)
    {
        var cookieOptions = new CookieOptions
        {
            Expires = expireTime.HasValue ? DateTime.Now.AddMinutes(expireTime.Value) : (DateTime?)null
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, cookieOptions);
    }

    public string GetCookie(string key)
    {
        return _httpContextAccessor.HttpContext.Request.Cookies[key];
    }
}
