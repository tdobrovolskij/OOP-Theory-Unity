using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        horsePower = 3000;
        turnSpeed = 25;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    // POLYMORPHISM: implenting own version of Move() method inherited from the parent
    public override void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //hrow new System.NotImplementedException();
        vehicleRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
