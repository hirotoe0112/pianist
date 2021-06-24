using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save 
{
    static string filePath = Path.Combine(Application.persistentDataPath, "savedata.json");

    /// <summary>
    /// セーブデータ格納用クラス
    /// </summary>
    [Serializable]
    private class SaveData
    {
        public string test;
    }

    #region 公開メソッド
    /// <summary>
    /// セーブ
    /// </summary>
    public static void SaveGame()
    {
        var tmpSaveData = new SaveData();

        //ここでデータクラスの内容をセーブデータクラスに移送
        tmpSaveData.test = "aaaaaaa";

        var json = JsonUtility.ToJson(tmpSaveData);

        ///プラットフォームに応じてセーブ先を変更
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
    /// ロード
    /// </summary>
    public static void LoadGame()
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        //ファイルを読み込み
        var json = File.ReadAllText(filePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        //ここでセーブデータクラスの内容をデータクラスに移送
    }

    /// <summary>
    /// セーブデータが存在するかチェック
    /// </summary>
    /// <returns></returns>
    public static bool IsExistData()
    {
        return File.Exists(filePath);
    }
#endregion
}
