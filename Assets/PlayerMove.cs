using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //子オブジェクトのサイズを格納するための変数
    private float Left, Right, Top, Bottom;

    //カメラから見た画面左下の座標を入れる変数
    Vector3 LeftBottom;

    //カメラから見た画面右下の座標を入れる変数
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        //
        var distance = Vector3.Distance(Camera.main.transform.position, transform.forward);

        //
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        //
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        //子オブジェクトの数だけループ処理を行う
        foreach (Transform Child in gameObject.transform)
        {
            //子オブジェクトの中で一番右の位置にいたなら
            if (Child.localPosition.x >= Right)
            {
                //子オブジェクトのローカル座標の右端用の座標に代入する
                Right = Child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番左の位置にいたなら
            if (Child.localPosition.x <= Left)
            {
                //子オブジェクトのローカル座標の左端用の座標に代入する
                Left = Child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番上の位置にいたなら
            if (Child.localPosition.z >= Top)
            {
                //子オブジェクトのローカル座標の上端用の座標に代入する
                Top = Child.transform.localPosition.z;
            }
            //子オブジェクトの中で一番下の位置にいたなら
            if (Child.localPosition.z <= Bottom)
            {
                //子オブジェクトのローカル座標の下端用の座標に代入する
                Bottom = Child.transform.localPosition.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos=transform.position;

        //右矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右方向に0.01動く
            pos.x += 0.01f;
        }
        //左矢印キーが押されたとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左方向に0.01動く
            pos.x -= 0.01f;
        } 
        //上矢印キーが押されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //上方向に0.01動く
            pos.z += 0.01f;
        }
        //下矢印キーが押されたとき
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //下方向に0.01動く
            pos.z -= 0.01f;
        }
        //プレイヤーのワールド座標に代入
        transform.position = new Vector3(Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
                                         pos.y,
                                         Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top));
    }
}
