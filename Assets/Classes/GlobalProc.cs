using System.Collections;
using System.Collections.Generic;

public static class GlobalProc
{
    /// <summary>
    /// カンマ区切りの数値を返す
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string AddComma(long value)
    {
        return string.Format("{0:#,0}", value);
    }
}
