using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class NeModniyServiz
    {
        public async Task<string> getNeModniyDanik()
        {
            Thread.Sleep(1000);
            return await Task.FromResult("neModniy");
        }
    }
}