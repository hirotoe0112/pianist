using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    /// <summary>
    /// チュートリアル終了
    /// </summary>
    public static bool isTutorialFinished;

    /// <summary>
    /// 期
    /// </summary>
    public enum TERM
    {
        CHILD,
        STUDENT,
        ADULT
    }

    /// <summary>
    /// 現在の期
    /// </summary>
    public static TERM CurrentTerm;

    /// <summary>
    /// 現在の日数
    /// </summary>
    public static int CurrentDate;

    /// <summary>
    /// 所持金額
    /// </summary>
    public static long Money;

    /// <summary>
    /// 親の職業
    /// </summary>
    public static int Worker;

    /// <summary>
    /// データ初期化
    /// </summary>
    public static void InitData()
    {
        isTutorialFinished = false;
        CurrentTerm = TERM.CHILD;
        CurrentDate = 1;
        Money = 0;
        Worker = 0;
    }

    /// <summary>
    /// 期の名称取得
    /// </summary>
    /// <param name="term"></param>
    /// <returns></returns>
    public static string GetTermName(TERM term)
    {
        switch (term)
        {
            case TERM.CHILD:
                return "幼少期";
            case TERM.STUDENT:
                return "学生期";
            default:
                return "社会人";
        }
    }
}
