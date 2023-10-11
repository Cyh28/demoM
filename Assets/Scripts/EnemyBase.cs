using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public int maxHealth;
    private int Health;
    public int health {
        set {
            healthSlider.value = 1.0f * value / maxHealth;
            Health = value;
        }
        get { return Health; }
    }
    public Slider healthSlider;
    public Animator anim;
    // Start is called before the first frame update
    protected void Start(){
        Debug.Log("started");
        GameManager.GetInstance().enemyBase = this;
        anim = GetComponent<Animator>();
        health = maxHealth;
        Admission();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Admission() {

    }

    public void Death() {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage) {
        health = Mathf.Max(health - damage, 0);
        if (health == 0) {
            Death();
        }
    }
}
