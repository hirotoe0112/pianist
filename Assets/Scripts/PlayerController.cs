using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float MoveRightLimit;

    [SerializeField]
    float MoveLeftLimit;

    //1フレームごとの移動距離
    private float distance = 0.005f;

    //初期位置
    private Vector2 defaultPosition = new Vector2(0, -1.5f);

    //初期スケール
    private Vector2 defaultScale = new Vector2(1.5f, 1.5f);

    //移動可能かどうか
    private bool canMove;

    private void Start()
    {
        //初期位置を設定
        transform.position = defaultPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Walk();
        }
    }

    private void Walk()
    {
        //マウスの位置をワールド座標に変換
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //左右の移動制限
        cursorPos.x = Mathf.Clamp(cursorPos.x, MoveLeftLimit, MoveRightLimit);

        //移動処理
        if(transform.position.x < cursorPos.x - distance)
        {
            transform.localScale = new Vector2(defaultScale.x * -1, defaultScale.y);
            transform.position = new Vector2(transform.position.x + distance, transform.position.y);
        }
        else if(cursorPos.x + distance < transform.position.x)
        {
            transform.localScale = new Vector2(defaultScale.x, defaultScale.y);
            transform.position = new Vector2(transform.position.x - distance, transform.position.y);
        }
    }

    /// <summary>
    /// キャラクターを初期位置に配置する
    /// </summary>
    public void SetDefaultPosition()
    {
        transform.position = defaultPosition;
    }

    /// <summary>
    /// キャラクターを移動可能にする
    /// </summary>
    public void AllowMove()
    {
        canMove = true;
    }

    /// <summary>
    /// キャラクターを移動不可にする
    /// </summary>
    public void ForbiddenMove()
    {
        canMove = false;
    }
}
