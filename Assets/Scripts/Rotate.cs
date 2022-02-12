using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 rotateAxis;

    private void Update()
    {
        transform.Rotate(speed * rotateAxis * Time.deltaTime);
    }
}
