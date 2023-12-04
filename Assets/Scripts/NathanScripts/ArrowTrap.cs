using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    Transform _player;
    float dis;
    public float near;
    public Transform head, barrel;
    public GameObject projectile;
    public float firerate, nextfire;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(_player.position, transform.position);
        if (dis <= near)
        {
            //head.LookAt(_player);
            if (Time.time >= nextfire)
            {
                nextfire = Time.time + 1f / firerate;
                shoot();
            }
        }
    }

    void shoot()
    {
        GameObject clone = Instantiate(projectile, barrel.position, head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * force);
        Destroy(clone, 5);
    }
}
