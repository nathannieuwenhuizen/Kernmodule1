using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge1 : MonoBehaviour
{
    public Transform[] points;
    private int current = 0;
    public float speed = .05f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToPoint(points[current]));
    }
    IEnumerator GoToPoint(Transform point)
    {
        while (Vector3.Distance(transform.position, point.position) > speed * 1.1f)
        {
            transform.Translate(Vector3.Normalize(point.position - transform.position) * speed);
            yield return new WaitForFixedUpdate();
        }
        current = ++current % points.Length;
        Debug.Log(current);
        StartCoroutine(GoToPoint(points[current]));
    }
}
