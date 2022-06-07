using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //弾のワールド座標を取得
        Vector3 pos = transform.position;

        //上にまっすぐ飛ぶ
        pos.z += 0.05f;

        //弾の移動
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //一定距離が進んだら消滅する
        if (pos.z >= 20)
        {
            Destroy(this.gameObject);
        }
    }
}
