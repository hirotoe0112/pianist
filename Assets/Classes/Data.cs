using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    /// <summary>
    /// �`���[�g���A���I��
    /// </summary>
    public static bool isTutorialFinished;

    /// <summary>
    /// ��
    /// </summary>
    public enum TERM
    {
        CHILD,
        STUDENT,
        ADULT
    }

    /// <summary>
    /// ���݂̊�
    /// </summary>
    public static TERM CurrentTerm;

    /// <summary>
    /// ���݂̓���
    /// </summary>
    public static int CurrentDate;

    /// <summary>
    /// �������z
    /// </summary>
    public static long Money;

    /// <summary>
    /// �e�̐E��
    /// </summary>
    public static int Worker;

    /// <summary>
    /// �f�[�^������
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
    /// ���̖��̎擾
    /// </summary>
    /// <param name="term"></param>
    /// <returns></returns>
    public static string GetTermName(TERM term)
    {
        switch (term)
        {
            case TERM.CHILD:
                return "�c����";
            case TERM.STUDENT:
                return "�w����";
            default:
                return "�Љ�l";
        }
    }
}
