using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private GameObject effect;
    [SerializeField] private float areaOfEffect;
    [SerializeField] private int damage;


    void Update()
    {
        if (timer <= 0)
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                objectsToDamage[i].GetComponent<DestructableEnvi>().health -= damage;
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
}
