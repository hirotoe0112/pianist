using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���ʒ萔
/// </summary>
public class GlobalConst
{
    /// <summary>
    /// ���K�ȊO�̑I����
    /// </summary>
    public enum Action
    {
        GYM,
        MUSICAL,
        LIBRARY,
        CANCEL
    }

    //�I�����̃t�H���g�ݒ�
    public static Font selectionFont = Resources.Load<Font>("Fonts/PixelMplus12-Regular");
    public static int selectionFontSize = 20;
    public static Color selectingColor = new Color32(204, 153, 153, 255);
    public static Color defaultColor = new Color32(255, 255, 255, 255);
}
