using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatewall_1 : MonoBehaviour
{
    Transform myTransform;
    Vector3 origin = new Vector3(-9.47f, 1f, 36.3f);
    Vector3 axis = new Vector3(0f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.RotateAround(origin, axis, -2f);
    }
}