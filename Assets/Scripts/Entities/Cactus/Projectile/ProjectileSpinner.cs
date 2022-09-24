using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpinner : MonoBehaviour
{
    [SerializeField] float spinSpeed =4;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
