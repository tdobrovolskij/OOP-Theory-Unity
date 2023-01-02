using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Vehicle
{
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        horsePower = 2000;
        turnSpeed = 45;
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

        // planes can't move backward, ideally we would want them to move at a constant speed while in air but for simplicity sake we won't implement it here
        if (forwardInput > 0)
            vehicleRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        // planes can fly so we model this by rotating along the sideways vector

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.Rotate(Vector3.left, -turnSpeed * Time.deltaTime);
        }
    }
}
