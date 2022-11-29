using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuffinCTF.Application.Abstractions
{
    public interface ICookie
    {
        Task SetValue(string key, string value, int? days = null);
        Task<string> GetValue(string key, string def = "");
    }
}
