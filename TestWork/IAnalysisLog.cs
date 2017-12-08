using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork
{
    public interface IAnalysisLog
    {
        ICheckPatternString CheckPatternString { get; }
        IGetDataFromString GetDataFromString { get; }
    }
}
