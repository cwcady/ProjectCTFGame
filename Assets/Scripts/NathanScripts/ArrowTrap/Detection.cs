using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public string tagTarget = "Player2";
    public List<Collider> detect = new List<Collider>();
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == tagTarget)
        {
            detect.Add(other);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == tagTarget)
        {
            detect.Remove(other);
        }
    }
}
