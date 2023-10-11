using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonDontDestory<GameManager>
{
    public CinemachineImpulseSource CIS;

    public GameObject enemy;
    public EnemyBase enemyBase;
    // Start is called before the first frame update
    void Start()
    {
        CIS = GetComponent<CinemachineImpulseSource>();
    }
    public void CameraShake(float magnitude) {
        float angle = Random.value * 2 * Mathf.PI;
        CIS.GenerateImpulseWithVelocity(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
