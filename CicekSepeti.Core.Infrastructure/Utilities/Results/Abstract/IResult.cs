using CicekSepeti.Core.Infrastructure.Utilities.ComplexTypes;
using System;

namespace CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
