using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float movementSpeed = 100;

    Transform myT;

    void Awake()
    {
        myT = transform;

    }

    void Update()
    {
        Thrust();
    }

    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }






}
