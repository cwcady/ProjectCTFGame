using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

    private Vector3 currentRot;
    private Vector3 targetRot;

    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    [SerializeField] private float recoilZ;

    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetRot = Vector3.Lerp(targetRot, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRot = Vector3.Slerp(currentRot, targetRot, snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRot);
    }

    public void RecoilFire()
    {
        targetRot += new Vector3(recoilX ,Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));

    }
}
