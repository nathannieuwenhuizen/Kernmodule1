using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge4 : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Update()
    {
        calculateAngle();
    }

    // Update is called once per frame
    void calculateAngle()
    {
        Vector3 horizontalRelation = transform.forward;
        Vector3 relativePos = transform.forward;
        float rotation =  Vector3.Angle(horizontalRelation, relativePos);
        Debug.Log(horizontalRelation);
        Debug.Log(relativePos);
    }
}
