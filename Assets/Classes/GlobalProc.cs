using System.Collections;
using System.Collections.Generic;

public static class GlobalProc
{
    /// <summary>
    /// ƒJƒ“ƒ}‹æØ‚è‚Ì”’l‚ğ•Ô‚·
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string AddComma(long value)
    {
        return string.Format("{0:#,0}", value);
    }
}
