using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 9f;
    public float offsetY = 6f;

    private Transform playerTrans;
    private Vector3 oldPos;
    private Vector3 newPos;
    private Vector3 playerPos;
    private float transitionSpeed = 5f;
    private float Zangle;
    private float newX;
    private float newY;
    private Camera camera = new Camera();

    // Use this for initialization
    void Awake()
    {

        //camera = gameObject.GetComponent<Camera>();
        camera = Camera.main;

    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            playerPos = playerTrans.position;
            Zangle = playerTrans.eulerAngles.z;
            oldPos = transform.position;

            if (Zangle >= 0 && Zangle < 90f)
            {
                newX = -(offsetX * Zangle / 90f);
                newY = (offsetY - (offsetY * Zangle / 90f));
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }

            if (Zangle >= 90f && Zangle < 180f)
            {
                newX = -(offsetX - (offsetX * (Zangle - 90f) / 90f));
                newY = -(offsetY * (Zangle - 90f) / 90f);
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }

            if (Zangle >= 180f && Zangle < 270f)
            {
                newX = (offsetX * (Zangle - 180f) / 90f);
                newY = -(offsetY - (offsetY * (Zangle - 180f) / 90f));
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }

            if (Zangle >= 270f && Zangle < 360f)
            {
                newX = (offsetX - (offsetX * (Zangle - 270f) / 90f));
                newY = (offsetY * (Zangle - 270f) / 90f);
                newPos = new Vector3(Mathf.Lerp(oldPos.x, playerPos.x + newX, Time.deltaTime * transitionSpeed), Mathf.Lerp(oldPos.y, playerPos.y + newY, Time.deltaTime * transitionSpeed), oldPos.z);
            }
            transform.position = newPos;
        }
    }
}
