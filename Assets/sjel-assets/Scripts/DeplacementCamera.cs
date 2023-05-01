using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCamera : MonoBehaviour
{
    public Transform camCible;
    public float vitesse;
    public Vector3 distance;
    public Transform regarderCible;

    void FixedUpdate()
    {
        Vector3 dPosition = camCible.position + distance;
        Vector3 sPosition = Vector3.Lerp(transform.position, dPosition, vitesse * Time.deltaTime);
        transform.position = sPosition;
        transform.LookAt(regarderCible.position);
    }
}
