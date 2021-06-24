using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSController : MonoBehaviour
{
    [SerializeField]
    GameObject forbiddenOperationArea;

    [SerializeField]
    GameObject FMSArea;

    /// <summary>
    /// ×ボタンクリック時処理
    /// </summary>
    public void OnClickCloseButton()
    {
        //メインUIのボタンを押下可能にする
        forbiddenOperationArea.SetActive(false);

        //FMSを終了
        FMSArea.SetActive(false);
    }
}
