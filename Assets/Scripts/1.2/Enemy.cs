using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public string myName;

    private int defence;

    // Start is called before the first frame update
    void Start()
    {
        print($"Hello. I'm Enemy {myName}!");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetDamage(int damageValue)
    {
        health -= damageValue;
        print($"Enemy health = { health}");
        if (health <= 0)
        {
            print("I'm dead");
        }
    }
}
