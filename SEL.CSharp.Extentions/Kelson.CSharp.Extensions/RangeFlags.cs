////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;

namespace Kelson.CSharp.Extensions
{
    /// <summary>
    /// Specifies an interval behavior.
    /// </summary>
    [Flags]
    public enum RangeFlags
    {
        Exclusive     = 0,         // ]a, b[ Does not include a or b
        FromInclusive = 1,         // [a, b[ Includes a, does not include b
        ToInclusive   = 2,         // ]a, b] Does not include a, includes b
        Inclusive     = 1 | 2      // [a, b] Includes a and b
    }
}