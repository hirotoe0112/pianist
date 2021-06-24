using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Selection
{
    private bool isSelected = false;
    private int selectionIndex;

    /// <summary>
    /// 選択肢表示
    /// </summary>
    /// <param name="selections"></param>
    /// <param name="selectionArea"></param>
    /// <returns></returns>
    private void DrawSelection(List<SelectionData> selections, GameObject selectionArea)
    {
        //選択肢の数だけボタンを配置
        foreach(SelectionData data in selections)
        {
            GameObject selectionButton = new GameObject("selectionButton", typeof(Text));
            selectionButton.transform.SetParent(selectionArea.transform, false);

            //選択肢の文字列を表示する
            selectionButton.GetComponent<Text>().text = data.Text;
            selectionButton.GetComponent<Text>().font = GlobalConst.selectionFont;
            selectionButton.GetComponent<Text>().fontSize = GlobalConst.selectionFontSize;

            //選択肢にクリックイベントを設定
            selectionButton.AddComponent<EventTrigger>();
            EventTrigger trigger = selectionButton.GetComponent<EventTrigger>();
            EventTrigger.Entry clickEntry = new EventTrigger.Entry();
            clickEntry.eventID = EventTriggerType.PointerDown;
            clickEntry.callback.AddListener((eventData) =>
            {
                SelectionClickEvent(data.Id);
            });
            trigger.triggers.Add(clickEntry);

            //選択中の色設定処理を設定
            EventTrigger.Entry selectingEntry = new EventTrigger.Entry();
            selectingEntry.eventID = EventTriggerType.PointerEnter;
            selectingEntry.callback.AddListener((eventData) =>
            {
                SetFontColor(selectionButton.GetComponent<Text>());
            });
            trigger.triggers.Add(selectingEntry);

            //選択中の色解除処理を設定
            EventTrigger.Entry removeEntry = new EventTrigger.Entry();
            removeEntry.eventID = EventTriggerType.PointerExit;
            removeEntry.callback.AddListener((eventData) =>
            {
                RemoveFontColor(selectionButton.GetComponent<Text>());
            });
            trigger.triggers.Add(removeEntry);
        }
    }

    /// <summary>
    /// 選択肢非表示
    /// </summary>
    /// <param name="selectionArea"></param>
    public void RemoveSelection(GameObject selectionArea)
    {
        foreach(Transform child in selectionArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// 選択肢処理
    /// </summary>
    /// <param name="selections">選択肢のリスト</param>
    /// <param name="selectionArea">選択肢を表示するエリア</param>
    /// <param name="callback">結果を受け渡すためのコールバック関数</param>
    /// <returns></returns>
    public IEnumerator WaitSelection(List<SelectionData> selections, GameObject selectionArea, Action<int> callback)
    {
        isSelected = false;

        //選択肢の描画
        DrawSelection(selections, selectionArea);
        yield return new WaitForSecondsRealtime(0.5f);

        //選択されるまで待つ
        yield return new WaitUntil(() => isSelected);

        //選択肢非表示
        RemoveSelection(selectionArea);

        //結果を返す
        callback(selectionIndex);
    }

    /// <summary>
    /// 選択肢の色変更処理
    /// </summary>
    private void SetFontColor(Text text)
    {
        text.color = GlobalConst.selectingColor;
    }

    /// <summary>
    /// 選択肢の色変更解除処理
    /// </summary>
    /// <param name="text"></param>
    private void RemoveFontColor(Text text)
    {
        text.color = GlobalConst.defaultColor;
    }

    /// <summary>
    /// 選択肢クリック時処理
    /// </summary>
    /// <param name="selectionID"></param>
    private void SelectionClickEvent(int selectionID)
    {
        isSelected = true;
        selectionIndex = selectionID;
    }
}
