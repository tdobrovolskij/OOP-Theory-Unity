using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private UnityEngine.Vector3 offset = new UnityEngine.Vector3(0, 5, -12);
    private UnityEngine.Vector3 driverView = new UnityEngine.Vector3(0, 5, 0);
    private UnityEngine.Quaternion offsetRotation;
    private UnityEngine.Quaternion offsetRotationC;
    private bool isDriver = false;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        offsetRotation = transform.rotation * UnityEngine.Quaternion.Inverse(player.transform.rotation);
        cam = Camera.main;
        //cam.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // ABSTRACTION: no need to have camera switching logic in the Update method
        SwitchView();
    }

    void SwitchView()
    {
        offsetRotationC = player.transform.rotation;
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!isDriver)
                isDriver = true;
            else
                isDriver = false;
        }
        // Offset the camera behind the player
        if (!isDriver)
        {
            transform.position = player.transform.position + offset;
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, offsetRotation, Time.deltaTime * 2.0f);
        }
        else
        {
            transform.position = player.transform.position + driverView;
            // Not sure if 360.0f is needed
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, offsetRotationC, Time.deltaTime * 360.0f);

        }
    }
}
