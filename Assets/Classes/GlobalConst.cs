using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 共通定数
/// </summary>
public class GlobalConst
{
    /// <summary>
    /// 練習以外の選択肢
    /// </summary>
    public enum Action
    {
        GYM,
        MUSICAL,
        LIBRARY,
        CANCEL
    }

    //選択肢のフォント設定
    public static Font selectionFont = Resources.Load<Font>("Fonts/PixelMplus12-Regular");
    public static int selectionFontSize = 20;
    public static Color selectingColor = new Color32(204, 153, 153, 255);
    public static Color defaultColor = new Color32(255, 255, 255, 255);
}
