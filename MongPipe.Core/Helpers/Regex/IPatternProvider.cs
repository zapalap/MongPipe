using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Helpers
{
    public interface IPatternProvider
    {
        IList<RegexAliasPattern> Provide();
    }
}
