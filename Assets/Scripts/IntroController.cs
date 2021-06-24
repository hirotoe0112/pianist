using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [SerializeField]
    Text messageArea;

    [SerializeField]
    MessageItem message1;

    [SerializeField]
    MessageItem message2;

    [SerializeField]
    MessageItem message3;

    [SerializeField]
    SelectionItem selectionItem;

    [SerializeField]
    GameObject selectionArea;

    [SerializeField]
    GameObject pianist;

    [SerializeField]
    GameObject fadeOutImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroProgress());
    }

    private IEnumerator IntroProgress()
    {
        //少しウエイト
        yield return new WaitForSecondsRealtime(1.0f);

        //メッセージ表示
        var message = new Message();
        yield return StartCoroutine(message.DrawMessage(message1.GetMessages(), messageArea));

        //ピアニスト画像をフェードイン表示
        StartCoroutine(FadeInImage());

        //メッセージ表示
        yield return StartCoroutine(message.DrawMessage(message2.GetMessages(), messageArea));

        //選択肢表示
        var selection = new Selection();
        int? selectionId = null;
        yield return StartCoroutine(selection.WaitSelection(selectionItem.GetSelections(), selectionArea, (r => selectionId = r)));

        //メッセージ表示
        yield return StartCoroutine(message.DrawMessage(message3.GetMessages(), messageArea));

        //初期値をデータクラスにセット
        Data.InitData();
        Data.CurrentTerm = Data.TERM.CHILD;
        Data.CurrentDate = 1;
        Data.Money = 0;

        //フェードアウト
        yield return StartCoroutine(FadeOutDisplay());

        //メインシーンへ遷移
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// 画像のフェードイン表示
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeInImage()
    {
        float alpha = 0;
        SpriteRenderer renderer = pianist.GetComponent<SpriteRenderer>();
        Color renderColor = renderer.color;
        while(alpha < 1)
        {
            renderColor.a = alpha;
            renderer.color = renderColor;
            alpha += 0.0004f;
            yield return null;
        }
    }

    /// <summary>
    /// 画面のフェードアウト
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOutDisplay()
    {
        fadeOutImage.SetActive(true);
        float alpha = 0;
        Image image = fadeOutImage.GetComponent<Image>();
        Color imageColor = image.color;
        while(alpha < 1)
        {
            imageColor.a = alpha;
            image.color = imageColor;
            alpha += 0.001f;
            yield return null;
        }
    }
}
