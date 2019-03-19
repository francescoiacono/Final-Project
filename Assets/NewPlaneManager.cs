using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlaneManager : MonoBehaviour {

    public float PlaneSpeed;
    public float PlaneRotation;
    public float MaxRotationAngle;
    public float MaxPitchAngle;
    public int Heading;
    public bool MF; // Move forward
    public bool RL; // Rotate left
    public bool RR; // Rotate Right
    public bool Stable; // Stabilise the plane
    public bool FH; // Follow Heading
    public bool PU; // Pitch up
    public bool PD; // Pitch down

    private Rigidbody rigidbody;
    private bool stable;


	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (MF) {
            MoveForward(PlaneSpeed);
        }
        if (RL) {
            TurnLeft(PlaneRotation);
        }
        if (RR) {
            TurnRight(PlaneRotation);
        }
        if (Stable) {
            RR = false;
            RL = false;
            Stabilise(PlaneRotation);
        }
        if (FH) {
            FollowHeading(Heading, PlaneRotation);
        }

        if (PU) {
            PitchUp(PlaneRotation);
        }
        if (PD) {
            PitchDown(PlaneRotation);
        }

	}

    // Function moves plane forward
    void MoveForward(float speed) {
        Quaternion q = rigidbody.rotation;
        rigidbody.AddForce(q.eulerAngles * speed * Time.deltaTime);
    }


    // Function stabilises the plane after curves
    void Stabilise(float speed) {        
        int z = (int)Mathf.Floor(transform.localEulerAngles.z);
        int x = (int)Mathf.Floor(transform.localEulerAngles.x);
        if (z != 0) {
            if (z <= MaxRotationAngle)
            {
                Quaternion dRotation = Quaternion.Euler(new Vector3(0f, 0f, -speed) * Time.deltaTime);
                rigidbody.MoveRotation(rigidbody.rotation * dRotation);
            }
            else if (z >= 360 - MaxRotationAngle) {
                Quaternion dRotation = Quaternion.Euler(new Vector3(0f, 0f, speed) * Time.deltaTime);
                rigidbody.MoveRotation(rigidbody.rotation * dRotation);
            }
        }

        if (x != 0) {
            if (x <= MaxPitchAngle)
            {
                Quaternion dRotation = Quaternion.Euler(new Vector3(-speed / 2, 0f, 0f) * Time.deltaTime);
                rigidbody.MoveRotation(rigidbody.rotation * dRotation);
            }
            else if (x >= 360 - MaxPitchAngle)
            {
                Quaternion dRotation = Quaternion.Euler(new Vector3(speed / 2, 0f, 0f) * Time.deltaTime);
                rigidbody.MoveRotation(rigidbody.rotation * dRotation);
            }

        }       
    }
    
    // Rotate the plane for curves
    void TurnLeft(float speed)
    {
        if ((int)Mathf.Floor(transform.localEulerAngles.z) < MaxRotationAngle)
        {
            Quaternion dRotation = Quaternion.Euler(new Vector3(0f, 0f, speed) * Time.deltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * dRotation);
        }
    }

    // Rotate the plane for curves
    void TurnRight(float speed)
    {
        if ((int)Mathf.Floor(transform.localEulerAngles.z) > 360-MaxRotationAngle || 
            (int)Mathf.Floor(transform.localEulerAngles.z) == 0)
        {
            Quaternion dRotation = Quaternion.Euler(new Vector3(0f, 0f, -speed) * Time.deltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * dRotation);
        }
    }

    // Function to give a new heading to the plane
    // TODO this function may cause problems in the future
    void FollowHeading(int newHeading, float speed) {
        int y = (int)Mathf.Floor(transform.localEulerAngles.y);
        if (y != newHeading) {
            if (newHeading < 180)
            {
                Quaternion dRotation = Quaternion.Euler(new Vector3(0f, speed / 2, 0f) * Time.deltaTime);
                rigidbody.MoveRotation(rigidbody.rotation * dRotation);
            }
            else {
                Quaternion dRotation = Quaternion.Euler(new Vector3(0f, -speed / 2, 0f) * Time.deltaTime);
                rigidbody.MoveRotation(rigidbody.rotation * dRotation);
            }
        }
    }

    // Pitching Plane up
    void PitchUp(float speed) {
        int x = (int)Mathf.Floor(transform.localEulerAngles.x);
        if (x != MaxPitchAngle) {
            Quaternion dRotation = Quaternion.Euler(new Vector3(speed / 2, 0f, 0f) * Time.deltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * dRotation);
        }
    }
    
    // Pitching plane down
    void PitchDown(float speed) {
        int x = (int)Mathf.Floor(transform.localEulerAngles.x);
        if (x != 360-MaxPitchAngle) {
            Quaternion dRotation = Quaternion.Euler(new Vector3(-speed / 2, 0f, 0f) * Time.deltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * dRotation);
        }
    }
}
