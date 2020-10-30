using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCam : MonoBehaviour
{
    private float rotMouseY = 0;
    private Quaternion rotOriginal;
    // Start is called before the first frame update
    void Start()
    {
        rotOriginal = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotMouseY += Input.GetAxis("Mouse Y");
        
        rotMouseY = Mathf.Clamp(rotMouseY, -50, 50);

        Quaternion cimaBaixo = Quaternion.AngleAxis(rotMouseY, Vector3.left);

        transform.localRotation = rotOriginal * cimaBaixo;
    }
}
