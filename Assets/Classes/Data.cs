using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
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
    /// �`���[�g���A���I��
    /// </summary>
    public static bool isTutorialFinished;

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
    /// ���݂̗��K�ȂP
    /// </summary>
    public static int practiceMusic1;

    /// <summary>
    /// ���݂̗��K�ȂQ
    /// </summary>
    public static int practiceMusic2;

    /// <summary>
    /// ���݂̗��K�ȂR
    /// </summary>
    public static int practiceMusic3;

    /// <summary>
    /// ���K�ȂP�̎c�����
    /// </summary>
    public static int remainDay1;

    /// <summary>
    /// ���K�ȂQ�̎c�����
    /// </summary>
    public static int remainDay2;

    /// <summary>
    /// ���K�ȂR�̎c�����
    /// </summary>
    public static int remainDay3;

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
        practiceMusic1 = 0;
        practiceMusic2 = 0;
        practiceMusic3 = 0;
        remainDay1 = 0;
        remainDay2 = 0;
        remainDay3 = 0;
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
