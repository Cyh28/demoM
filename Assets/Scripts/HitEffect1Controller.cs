using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HitEffect1Controller : MonoBehaviour {
    public ObjectPool<GameObject> HitEffect1Pool;
    private ParticleSystem _particleSystem;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play() {
        StartCoroutine(AnimPlay());
    }

    IEnumerator AnimPlay() {
        Debug.Log("play");
        if(!_particleSystem)
            _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Play();
        yield return new WaitForSeconds(0.1f);
        _particleSystem.Stop();
        yield return new WaitForSeconds(1f);
        HitEffect1Pool.Release(gameObject);
    }
}
