using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        //セーブデータが存在する場合のみつづきからボタンを有効にする 
        if (Save.IsExistData())
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// はじめから
    /// </summary>
    public void StartNew()
    {
        SceneManager.LoadScene("IntroScene");
    }

    /// <summary>
    /// つづきから
    /// </summary>
    public void StartContinue()
    {
        //セーブデータをロード
        Save.LoadGame();
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// レパートリー
    /// </summary>
    public void Repertoire()
    {
        Debug.Log("レパートリー");
    }
}
