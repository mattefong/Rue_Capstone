using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float lifeTime;

    public float distance;
    public float damage;

    public LayerMask whatIsSolid;

    public GameObject impactEffect;

    public int direction;


    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy takes damage");
                hitInfo.collider.transform.parent.GetComponent<SC_Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        if(direction == -1)
        {
            transform.Translate(-direction * Vector3.right * projectileSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * Vector3.right * projectileSpeed * Time.deltaTime);
        }
    }

    void DestroyProjectile()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
