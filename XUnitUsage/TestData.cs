﻿using System.Collections;

namespace XUnitUsage;

public class TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { -4, -6, -10 };
        yield return new object[] { -2, 2, 0 };
        yield return new object[] { int.MinValue, -1, int.MaxValue };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}