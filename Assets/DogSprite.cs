using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSprite : MonoBehaviour
{
    private Quaternion parentRot;
    // Start is called before the first frame update
    void Start()
    {
        parentRot = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Inverse(transform.parent.localRotation) *
        parentRot *
        transform.localRotation;
        parentRot = transform.parent.localRotation;
    }
}
