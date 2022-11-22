using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroll : MonoBehaviour
{
    public GameManager gameManager;

    private Vector3 startPos;
    public float scrollSpeedMultiplier = 1f;

    public bool repeat = false;
    public float repeatPoint;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.gameStarted == true)
        {
            transform.Translate(Vector3.left * gameManager.gameSpeed * scrollSpeedMultiplier * Time.deltaTime);
        }


        if (transform.position.x < -repeatPoint && repeat == true)
        {
            transform.position = startPos;
        }

    }
}
