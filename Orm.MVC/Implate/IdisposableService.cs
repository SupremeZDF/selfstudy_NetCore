using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orm.MVC.Implate
{
    public interface IdisposableService
    {

    }

    public class DisposAbleService : IDisposable,IdisposableService
    {
        public void Dispose()
        {
            Console.WriteLine($"dededed {this.GetHashCode()}");
        }
    }
}
