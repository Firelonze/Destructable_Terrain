using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableEnvi : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private GameObject destroyEffect;
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }      
    }
}
