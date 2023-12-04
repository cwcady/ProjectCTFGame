using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string tagTarget = "Player";
    public float moveSpeed = 1f;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * transform.right * Time.deltaTime;
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(tagTarget)) { return; }
        /*Rigidbody rigg = other.GetComponent<Rigidbody>();
        if (rigg != null)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.y = 0;
            rigg.AddForce(direction.normalized * force, ForceMode.Impulse);
            Destroy(gameObject);
        }*/
        knockback(other);
        Destroy(gameObject);
    }

    void knockback(Collider other)
    {
        Rigidbody rigg = other.GetComponent<Rigidbody>();
        if (rigg != null)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.y = 0;
            rigg.AddForce(direction.normalized * force, ForceMode.Impulse);
            
        }
    }
}
