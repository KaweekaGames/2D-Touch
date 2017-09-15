using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float rotSpeed;
    public float forwardSpeed;
    public float forwardSpeedFactor;
    public float maxSpeed;
    public float forwardSlowDownFactor;

    private float rotAmount = 0;
    private float playerSpeed = 0;
    private Vector3 velocity;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion rot = player.transform.rotation;

        float z = rot.eulerAngles.z;

        z -= rotAmount * rotSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, 0, z);

        player.transform.rotation = rot;


        Vector3 pos = player.transform.position;

        velocity = new Vector3(0, playerSpeed * forwardSpeedFactor * Time.deltaTime, 0);

        pos += rot * velocity;

        player.transform.position = pos;


        if (rotAmount > 0)
        {
            rotAmount -= Time.deltaTime;
        }
        else if(rotAmount < 0)
        {
            rotAmount += Time.deltaTime;
        }

        if(playerSpeed > 0)
        {
            playerSpeed -= Time.deltaTime * forwardSlowDownFactor;
        }
        //else if (playerSpeed < 0)
        //{
        //   playerSpeed += Time.deltaTime;
        //}

        playerSpeed = Mathf.Clamp(playerSpeed, 0, maxSpeed);
	}

    public void Clockwise()
    {
        rotAmount = rotAmount + 1;
    }

    public void CounterClockwise()
    {
        rotAmount = rotAmount - 1;
    }

    public void Forward()
    {
        playerSpeed += 1;
    }
}
