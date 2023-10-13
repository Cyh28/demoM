using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HitEffectHandlerController : SingletonMono<HitEffectHandlerController> {
    public GameObject HitEffect1;
    private GameObject Player;
    private PlayerController playerController;
    public ObjectPool<GameObject> HitEffect1Pool;
    // Start is called before the first frame update
    void Start() {
        Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();
        HitEffect1Pool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, true, 10, 1000);
    }

    GameObject createFunc() {
        GameObject obj = Instantiate(HitEffect1, transform);
        obj.GetComponent<HitEffect1Controller>().HitEffect1Pool = HitEffect1Pool;
        return obj;
    }

    void actionOnGet(GameObject obj) {
        obj.gameObject.SetActive(true);
    }

    void actionOnRelease(GameObject obj) {
        obj.gameObject.SetActive(false);
    }

    void actionOnDestroy(GameObject obj) {
        Destroy(obj);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEffect1() {
        GameObject obj = HitEffect1Pool.Get();
        obj.transform.position = Player.transform.position;
        obj.GetComponent<HitEffect1Controller>().Play();
    }
}
