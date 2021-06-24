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
    /// �I�����\��
    /// </summary>
    /// <param name="selections"></param>
    /// <param name="selectionArea"></param>
    /// <returns></returns>
    private void DrawSelection(List<SelectionData> selections, GameObject selectionArea)
    {
        //�I�����̐������{�^����z�u
        foreach(SelectionData data in selections)
        {
            GameObject selectionButton = new GameObject("selectionButton", typeof(Text));
            selectionButton.transform.SetParent(selectionArea.transform, false);

            //�I�����̕������\������
            selectionButton.GetComponent<Text>().text = data.Text;
            selectionButton.GetComponent<Text>().font = GlobalConst.selectionFont;
            selectionButton.GetComponent<Text>().fontSize = GlobalConst.selectionFontSize;

            //�I�����ɃN���b�N�C�x���g��ݒ�
            selectionButton.AddComponent<EventTrigger>();
            EventTrigger trigger = selectionButton.GetComponent<EventTrigger>();
            EventTrigger.Entry clickEntry = new EventTrigger.Entry();
            clickEntry.eventID = EventTriggerType.PointerDown;
            clickEntry.callback.AddListener((eventData) =>
            {
                SelectionClickEvent(data.Id);
            });
            trigger.triggers.Add(clickEntry);

            //�I�𒆂̐F�ݒ菈����ݒ�
            EventTrigger.Entry selectingEntry = new EventTrigger.Entry();
            selectingEntry.eventID = EventTriggerType.PointerEnter;
            selectingEntry.callback.AddListener((eventData) =>
            {
                SetFontColor(selectionButton.GetComponent<Text>());
            });
            trigger.triggers.Add(selectingEntry);

            //�I�𒆂̐F����������ݒ�
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
    /// �I������\��
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
    /// �I��������
    /// </summary>
    /// <param name="selections">�I�����̃��X�g</param>
    /// <param name="selectionArea">�I������\������G���A</param>
    /// <param name="callback">���ʂ��󂯓n�����߂̃R�[���o�b�N�֐�</param>
    /// <returns></returns>
    public IEnumerator WaitSelection(List<SelectionData> selections, GameObject selectionArea, Action<int> callback)
    {
        isSelected = false;

        //�I�����̕`��
        DrawSelection(selections, selectionArea);
        yield return new WaitForSecondsRealtime(0.5f);

        //�I�������܂ő҂�
        yield return new WaitUntil(() => isSelected);

        //�I������\��
        RemoveSelection(selectionArea);

        //���ʂ�Ԃ�
        callback(selectionIndex);
    }

    /// <summary>
    /// �I�����̐F�ύX����
    /// </summary>
    private void SetFontColor(Text text)
    {
        text.color = GlobalConst.selectingColor;
    }

    /// <summary>
    /// �I�����̐F�ύX��������
    /// </summary>
    /// <param name="text"></param>
    private void RemoveFontColor(Text text)
    {
        text.color = GlobalConst.defaultColor;
    }

    /// <summary>
    /// �I�����N���b�N������
    /// </summary>
    /// <param name="selectionID"></param>
    private void SelectionClickEvent(int selectionID)
    {
        isSelected = true;
        selectionIndex = selectionID;
    }
}
