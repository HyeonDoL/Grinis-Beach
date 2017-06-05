using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform myTransform;

    void Awake()
    {
        myTransform = this.transform;
    }

    void Update()
    {
        myTransform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}