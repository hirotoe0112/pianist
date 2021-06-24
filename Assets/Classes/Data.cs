using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    /// <summary>
    /// Šú
    /// </summary>
    public enum TERM
    {
        CHILD,
        STUDENT,
        ADULT
    }

    /// <summary>
    /// ƒ`ƒ…[ƒgƒŠƒAƒ‹I—¹
    /// </summary>
    public static bool isTutorialFinished;

    /// <summary>
    /// Œ»İ‚ÌŠú
    /// </summary>
    public static TERM CurrentTerm;

    /// <summary>
    /// Œ»İ‚Ì“ú”
    /// </summary>
    public static int CurrentDate;

    /// <summary>
    /// Š‹àŠz
    /// </summary>
    public static long Money;

    /// <summary>
    /// e‚ÌE‹Æ
    /// </summary>
    public static int Worker;

    /// <summary>
    /// Œ»İ‚Ì—ûK‹È‚P
    /// </summary>
    public static int practiceMusic1;

    /// <summary>
    /// Œ»İ‚Ì—ûK‹È‚Q
    /// </summary>
    public static int practiceMusic2;

    /// <summary>
    /// Œ»İ‚Ì—ûK‹È‚R
    /// </summary>
    public static int practiceMusic3;

    /// <summary>
    /// —ûK‹È‚P‚Ìc‚è“ú”
    /// </summary>
    public static int remainDay1;

    /// <summary>
    /// —ûK‹È‚Q‚Ìc‚è“ú”
    /// </summary>
    public static int remainDay2;

    /// <summary>
    /// —ûK‹È‚R‚Ìc‚è“ú”
    /// </summary>
    public static int remainDay3;

    /// <summary>
    /// ƒf[ƒ^‰Šú‰»
    /// </summary>
    public static void InitData()
    {
        isTutorialFinished = false;
        CurrentTerm = TERM.CHILD;
        CurrentDate = 1;
        Money = 0;
        Worker = 0;
        practiceMusic1 = 0;
        practiceMusic2 = 0;
        practiceMusic3 = 0;
        remainDay1 = 0;
        remainDay2 = 0;
        remainDay3 = 0;
    }

    /// <summary>
    /// Šú‚Ì–¼Ìæ“¾
    /// </summary>
    /// <param name="term"></param>
    /// <returns></returns>
    public static string GetTermName(TERM term)
    {
        switch (term)
        {
            case TERM.CHILD:
                return "—c­Šú";
            case TERM.STUDENT:
                return "Šw¶Šú";
            default:
                return "Ğ‰ïl";
        }
    }
}
