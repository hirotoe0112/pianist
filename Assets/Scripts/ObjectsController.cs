using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{
    [SerializeField]
    GameObject forbiddenOperationArea;

    [SerializeField]
    Text messageArea;

    [SerializeField]
    MessageItem exitMessage;

    [SerializeField]
    MessageItem pianoMessage;

    private Message message = new Message();

    /// <summary>
    /// レパートリーボタンクリック時処理
    /// </summary>
    public void OnClickRepertoire()
    {
        Debug.Log("repa-tori-");
    }

    /// <summary>
    /// セーブボタンクリック時処理
    /// </summary>
    public void OnClickSave()
    {
        Debug.Log("save");
    }

    /// <summary>
    /// ドアクリック時処理
    /// </summary>
    public void OnClickDoor()
    {
        //ドアクリック詳細処理を実行
        StartCoroutine(OnClickDoorDetail());
    }

    /// <summary>
    /// ドアクリック詳細処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnClickDoorDetail()
    {
        //他のボタンを押下不可にする
        forbiddenOperationArea.SetActive(true);
        yield return StartCoroutine(DisplayMessage(exitMessage));
        //他のボタンを押下可能にする
        forbiddenOperationArea.SetActive(false);
    }

    /// <summary>
    /// PCクリック時処理
    /// </summary>
    public void OnClickPC()
    {
        Debug.Log("pcclick");
    }

    /// <summary>
    /// カレンダークリック時処理
    /// </summary>
    public void OnClickCalender()
    {
        Debug.Log("karenda-");
    }

    /// <summary>
    /// ピアノクリック時処理
    /// </summary>
    public void OnClickPiano()
    {
        Debug.Log("piano");
    }

    /// <summary>
    /// メッセージ表示処理
    /// </summary>
    /// <param name="messageItem"></param>
    /// <returns></returns>
    private IEnumerator DisplayMessage(MessageItem messageItem)
    {
        yield return StartCoroutine(message.DrawMessage(messageItem.GetMessages(), messageArea));
    }
}
