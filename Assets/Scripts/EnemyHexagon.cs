using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHexagon : EnemyBase
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        GameManager.GetInstance().enemy = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
