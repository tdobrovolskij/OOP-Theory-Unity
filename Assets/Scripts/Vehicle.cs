using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    private float m_horsePower = 1000;
    // ENCAPSULATION: negative horsePower not allowed
    protected float horsePower
    {
        get { return m_horsePower; }
        set
        {
            if (value > 0)
                m_horsePower = value;
        }
    }
    protected float turnSpeed;
    protected Rigidbody vehicleRb;

    // INHERITANCE: every vehicle moves, but leave implementation to child classes
    public abstract void Move();
}
