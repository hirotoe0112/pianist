using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save 
{
    static string filePath = Path.Combine(Application.persistentDataPath, "savedata.json");

    /// <summary>
    /// �Z�[�u�f�[�^�i�[�p�N���X
    /// </summary>
    [Serializable]
    private class SaveData
    {
        public string test;
    }

    #region ���J���\�b�h
    /// <summary>
    /// �Z�[�u
    /// </summary>
    public static void SaveGame()
    {
        var tmpSaveData = new SaveData();

        //�����Ńf�[�^�N���X�̓��e���Z�[�u�f�[�^�N���X�Ɉڑ�
        tmpSaveData.test = "aaaaaaa";

        var json = JsonUtility.ToJson(tmpSaveData);

        ///�v���b�g�t�H�[���ɉ����ăZ�[�u���ύX
#if UNITY_WEBGL
        Debug.Log("webgl");
        PlayerPrefs.SetString("savedata", json);
        PlayerPrefs.Save();
else
        Debug.Log("else");
        File.WriteAllText(filePath, json);
#endif
    }

    /// <summary>
    /// ���[�h
    /// </summary>
    public static void LoadGame()
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        //�t�@�C����ǂݍ���
        var json = File.ReadAllText(filePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        //�����ŃZ�[�u�f�[�^�N���X�̓��e���f�[�^�N���X�Ɉڑ�
    }

    /// <summary>
    /// �Z�[�u�f�[�^�����݂��邩�`�F�b�N
    /// </summary>
    /// <returns></returns>
    public static bool IsExistData()
    {
        return File.Exists(filePath);
    }
#endregion
}
