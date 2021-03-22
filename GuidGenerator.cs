using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitCalculatorDemo
{
    /// <summary>
    /// Generate random guid number
    /// </summary>
    public class GuidGenerator
    {
        public Guid RandowmGuid { get; } = Guid.NewGuid();
    }
}
