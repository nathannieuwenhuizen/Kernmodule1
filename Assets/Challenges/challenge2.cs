using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge2 : MonoBehaviour
{

    public GameObject spawnobject;
    public int amount = 6;
    public float distanceToCenter = 1f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 dir = new Vector3(Mathf.Cos(Mathf.PI * 2 / amount * i), Mathf.Sin(Mathf.PI * 2 / amount * i), 0);

            //transform.Rotate(new Vector3(0,0, 360 / amount));
            Instantiate(spawnobject).transform.position = transform.position + dir * distanceToCenter;
        }
    }
}
