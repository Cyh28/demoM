using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlateEffectController : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() {
        StartCoroutine(AnimPlay());
    }
    IEnumerator AnimPlay() {
        Debug.Log("Attack Play");
        if (!_particleSystem)
            _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Play();
        Debug.Log(_particleSystem.isPlaying);
        yield return new WaitForSeconds(0.05f);
        _particleSystem.Stop();
    }
}
