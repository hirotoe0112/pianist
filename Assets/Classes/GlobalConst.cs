using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 共通定数
/// </summary>
public class GlobalConst
{
    //PlayerPrefsのセーブデータキー名
    public static string savenameByPrefs = "savePrefs";

    //選択肢のフォント設定
    public static Font selectionFont = Resources.Load<Font>("Fonts/PixelMplus12-Regular");
    public static int selectionFontSize = 20;
    public static Color selectingColor = new Color32(204, 153, 153, 255);
    public static Color defaultColor = new Color32(255, 255, 255, 255);

    //期ごとの発表会日程
    public static int[] recitalChild = { 28 };
    public static int[] recitalStudent = { 7, 14, 21, 28 };
    public static int[] recitalAdult = { 4, 8, 12, 16, 20, 24, 28 };
}
