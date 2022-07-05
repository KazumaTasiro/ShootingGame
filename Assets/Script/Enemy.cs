using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;
    public GManager gmanager;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <= 0)
        {
            gmanager.AddScoreCount();
            Destroy(this.gameObject);
        }
    }
    public void Damage()
    {
        enemyHp = enemyHp - 1;

        Debug.Log(enemyHp);
    }
}
