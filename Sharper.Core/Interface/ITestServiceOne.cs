using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharper.Core.Interface
{
    public interface ITestServiceOne: ITagService
    {
        Task FirstMethod();
    }
}
