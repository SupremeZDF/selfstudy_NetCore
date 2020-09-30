using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swagger.JwtRepostory.ModelToken
{
    public class RayPIMemoryCache
    {
        //活动
        public static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        public static bool Exists(string key) 
        {
            if (key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }
            object cached;
            //是否获取到值
            return _cache.TryGetValue(key, out cached);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <returns></returns>
        public static object Get(string key) 
        {
            if (key == null) 
            {
                if (key == null) 
                {
                    throw new ArgumentNullException(nameof(key));
                }
            }
            object cache;
            return _cache.Get(key);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存value</param>
        /// <param name="expirsstiding">滑动过期时常</param>
        /// <param name="expiessAbsolte">绝对过期时常</param>
        /// <returns></returns>
        public static bool AddMemoryCache(string key, object value, TimeSpan expirsstiding, TimeSpan expiessAbsolte) 
        {
            if (key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null) 
            {
                throw new ArgumentNullException(nameof(value));
            }
            _cache.Set(key, value, new MemoryCacheEntryOptions().SetSlidingExpiration(expirsstiding).SetAbsoluteExpiration(expiessAbsolte));
            return Exists(key);
        }
    }
}
