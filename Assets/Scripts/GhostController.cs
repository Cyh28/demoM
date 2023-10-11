using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GhostController : MonoBehaviour {
    public ObjectPool<GameObject> ghostPool;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReleaseSelf() {
        ghostPool.Release(gameObject);
    }
}
