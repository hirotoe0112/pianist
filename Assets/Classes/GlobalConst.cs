using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���ʒ萔
/// </summary>
public class GlobalConst
{
    //PlayerPrefs�̃Z�[�u�f�[�^�L�[��
    public static string savenameByPrefs = "savePrefs";

    //�I�����̃t�H���g�ݒ�
    public static Font selectionFont = Resources.Load<Font>("Fonts/PixelMplus12-Regular");
    public static int selectionFontSize = 20;
    public static Color selectingColor = new Color32(204, 153, 153, 255);
    public static Color defaultColor = new Color32(255, 255, 255, 255);

    //�����Ƃ̔��\�����
    public static int[] recitalChild = { 28 };
    public static int[] recitalStudent = { 7, 14, 21, 28 };
    public static int[] recitalAdult = { 4, 8, 12, 16, 20, 24, 28 };
}
