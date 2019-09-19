﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge3 : MonoBehaviour
{
    public Quaternion ForwardRotationToMouse()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = ForwardRotationToMouse();
    }
}
