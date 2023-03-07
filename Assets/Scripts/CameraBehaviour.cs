using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform plane;

    [SerializeField]
    private Vector3 offset = new Vector3(0, -21, -12);

    [SerializeField]
    private Vector3 eulerRotation = new Vector3(-45, 0, 0);

    private void Start()
    {
        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    void Update()
    {
        transform.position = plane.position + offset;
    }
}
