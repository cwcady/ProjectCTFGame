using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomTrap : MonoBehaviour
{
    public string tagTarget = "Player";
    [SerializeField] StatusEffectData _data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(tagTarget)) { return; }

        var effectable = other.GetComponent<IEffectable>();

        if (effectable != null)
        {
            effectable.ApplyEffect(_data);
        }
        
        Destroy(this.gameObject);
    }
}
