using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ObjectsController : MonoBehaviour
{
    [SerializeField]
    GameObject forbiddenOperationArea;

    [SerializeField]
    GameObject FMSArea;

    [SerializeField]
    Text messageArea;

    [SerializeField]
    GameObject selectionArea;

    [SerializeField]
    MessageItem exitMessage;

    [SerializeField]
    MessageItem pianoMessage;

    [SerializeField]
    MessageItem recitalMessage;

    [SerializeField]
    SelectionItem yesnoSelection;

    [SerializeField]
    SelectionItem exitChildSelection;

    [SerializeField]
    SelectionItem exitAdultSelection;

    private Message message = new Message();
    private Selection selection = new Selection();

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

        //メイン処理
        yield return StartCoroutine(DisplayMessage(exitMessage.GetMessages()));
        int? result = null;
        yield return StartCoroutine(DisplaySelection(yesnoSelection, (r => result = r)));

        if (result == 1)
        {
            //他のボタンを押下可能にする
            forbiddenOperationArea.SetActive(false);
        }
        else
        {
            //行き先選択肢
            int? target = null;
            SelectionItem selection = Data.CurrentTerm == Data.TERM.CHILD ? exitChildSelection : exitAdultSelection;
            yield return StartCoroutine(DisplaySelection(selection, (r => target = r)));
            //他のボタンを押下可能にする
            forbiddenOperationArea.SetActive(false);

            //日付送り処理
            //★★★
        }
    }

    /// <summary>
    /// PCクリック時処理
    /// </summary>
    public void OnClickPC()
    {
        //他のボタンを押下不可にする
        forbiddenOperationArea.SetActive(true);

        //FMSを開く
        FMSArea.SetActive(true);
    }

    /// <summary>
    /// カレンダークリック時処理
    /// </summary>
    public void OnClickCalender()
    {
        //カレンダークリック時詳細処理
        StartCoroutine(OnClickCalenderDetail());
    }

    /// <summary>
    /// カレンダークリック詳細処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnClickCalenderDetail()
    {
        //他のボタンを押下不可にする
        forbiddenOperationArea.SetActive(true);

        int[] recital;
        switch (Data.CurrentTerm)
        {
            case Data.TERM.CHILD:
                recital = GlobalConst.recitalChild;
                break;
            case Data.TERM.STUDENT:
                recital = GlobalConst.recitalStudent;
                break;
            default:
                recital = GlobalConst.recitalAdult;
                break;
        }

        //直近の発表会日程を取得
        var recitalday = recital.Where(i => Data.CurrentDate < i).First();
        var messageList = recitalMessage.GetMessages();
        messageList[0] = string.Format(messageList[0], recitalday);
        yield return StartCoroutine(DisplayMessage(messageList));

        //他のボタンを押下可能にする
        forbiddenOperationArea.SetActive(false);
    }

    /// <summary>
    /// ピアノクリック時処理
    /// </summary>
    public void OnClickPiano()
    {
        //ピアノクリック詳細処理
        StartCoroutine(OnClickPianoDetail());
    }
    
    private IEnumerator OnClickPianoDetail()
    {
        //他のボタンを押下不可にする
        forbiddenOperationArea.SetActive(true);

        //メイン処理
        yield return StartCoroutine(DisplayMessage(pianoMessage.GetMessages()));
        int? result = null;
        yield return StartCoroutine(DisplaySelection(yesnoSelection, (r => result = r)));

        if (result == 1)
        {
            //他のボタンを押下可能にする
            forbiddenOperationArea.SetActive(false);
        }
        else
        {
            //他のボタンを押下可能にする
            forbiddenOperationArea.SetActive(false);

            //日付送り処理
            //★★★
        }
    }

    /// <summary>
    /// メッセージ表示処理
    /// </summary>
    /// <param name="messageItem"></param>
    /// <returns></returns>
    private IEnumerator DisplayMessage(IEnumerable messsageList)
    {
        yield return StartCoroutine(message.DrawMessage(messsageList, messageArea));
    }

    /// <summary>
    /// 選択肢処理
    /// </summary>
    /// <param name="selectionItem"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    private IEnumerator DisplaySelection(SelectionItem selectionItem, Action<int?> callback) 
    {
        int? result = null;
        yield return StartCoroutine(selection.WaitSelection(selectionItem.GetSelections(), selectionArea, (r => result = r)));
        callback(result);
    }
}
