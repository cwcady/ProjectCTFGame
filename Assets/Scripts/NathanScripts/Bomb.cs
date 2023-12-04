using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public string tagTarget = "Player";
    public GameObject exp;
    public float expForce;
    public float radius;
    //public playerHealth playerhealth;

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(tagTarget)) { return; }
        GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
        Destroy(_exp, 3);
        knockback();
        //playerhealth.health -= 25;
        //playerhealth.lerpTimer = 0;
        Destroy(gameObject);
    }

    void knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider near in colliders)
        {
            Rigidbody rigg = near.GetComponent<Rigidbody>();
            if (rigg != null) {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}
