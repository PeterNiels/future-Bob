using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPoition;
    private void Update()
    {
        transform.position = cameraPoition.position;
    }
}
