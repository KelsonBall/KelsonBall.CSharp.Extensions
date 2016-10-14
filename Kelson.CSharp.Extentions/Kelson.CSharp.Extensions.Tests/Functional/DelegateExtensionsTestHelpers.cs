////////////////////////////////////////////////////////////
// Copyright © 2016 Schweitzer Engineering Laboratories, Inc.
// Kelson Confidential
/////////////////////////////////////////////////////////////

using System;

namespace Kelson.CSharp.Extensions.Tests.Functional
{
    public class DisposeMe : IDisposable
    {
        public static DisposeMe Instance;

        public int Counter;

        public DisposeMe()
        {
            if (Instance != null)
                throw new Exception("There is a DisposeMe being used.");
            Instance = this;            
        }

        public void Dispose()
        {
            Instance = null;
        }
    }
}