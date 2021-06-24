using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message
{
    #region 公開メソッド
    /// <summary>
    /// メッセージ表示
    /// </summary>
    /// <param name="messageList"></param>
    public IEnumerator DrawMessage(IEnumerable messageList, Text textarea)
    {
        InitMessageArea(textarea);
        foreach(string message in messageList)
        {
            textarea.text = message;
            yield return new WaitForSecondsRealtime(0.5f);
            yield return new WaitUntil(() => Input.GetMouseButton(0));
        }
        InitMessageArea(textarea);
    }
    #endregion

    #region 非公開メソッド
    /// <summary>
    /// メッセージウインドウ初期化
    /// </summary>
    /// <param name="textarea"></param>
    void InitMessageArea(Text textarea)
    {
        textarea.text = "";
    }
    #endregion
}
