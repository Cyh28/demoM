using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GhostHandlerController : MonoBehaviour
{
    public GameObject Ghost;
    private GameObject Player;
    private PlayerController playerController;
    public ObjectPool<GameObject> ghostPool;
    public float createDistance;
    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();
        ghostPool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, true, 10, 1000);
    }

    GameObject createFunc() {
        GameObject obj = Instantiate(Ghost, transform);
        obj.GetComponent<GhostController>().ghostPool = ghostPool;
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
    void FixedUpdate()
    {
        if ((Player.transform.position - lastPos).magnitude >= createDistance) {
            lastPos = Player.transform.position;
            ghostPool.Get().transform.position = Player.transform.position;
        }
    }
}
