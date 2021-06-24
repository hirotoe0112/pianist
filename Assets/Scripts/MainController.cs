using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField]
    GameObject childPlayer;

    [SerializeField]
    GameObject adultPlayer;

    [SerializeField]
    Text termText;

    [SerializeField]
    Text dayText;

    [SerializeField]
    Text moneyText;

    [SerializeField]
    Text messageArea;

    [SerializeField]
    MessageItem tutorial;

    [SerializeField]
    GameObject forbiddenOperationArea;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        if (Data.CurrentTerm == Data.TERM.CHILD)
        {
            player = childPlayer.GetComponent<PlayerController>();
            adultPlayer.SetActive(false);
        }
        else
        {
            player = adultPlayer.GetComponent<PlayerController>();
            childPlayer.SetActive(false);
        }

        //UIの設定
        SetUIText();

        //初期処理を開始
        StartCoroutine(Init());
    }

    /// <summary>
    /// 初期処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator Init()
    {
        //チュートリアル
        if (!Data.isTutorialFinished)
        {
            //オブジェクトをクリック不可にする
            forbiddenOperationArea.SetActive(true);

            //プレイヤーを移動不可にする
            player.ForbiddenMove();

            //終わってなければ実施
            yield return StartCoroutine(Tutorial());

            //プレイヤーを移動可能にする
            player.AllowMove();

            //オブジェクトをクリック可能にする
            forbiddenOperationArea.SetActive(false);
        }
        else
        {
            //プレイヤーを移動可能にする
            player.AllowMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// UIの設定
    /// </summary>
    private void SetUIText()
    {
        //日付
        termText.text = Data.GetTermName(Data.CurrentTerm);
        dayText.text = Data.CurrentDate.ToString();
        //所持金
        moneyText.text = GlobalProc.AddComma(Data.Money);
    }

    /// <summary>
    /// チュートリアル
    /// </summary>
    /// <returns></returns>
    private IEnumerator Tutorial()
    {
        //少しウエイト
        yield return new WaitForSecondsRealtime(1.0f);

        //メッセージ表示
        var message = new Message();
        yield return StartCoroutine(message.DrawMessage(tutorial.GetMessages(), messageArea));

        //チュートリアル済み
        Data.isTutorialFinished = true;
    }
}
