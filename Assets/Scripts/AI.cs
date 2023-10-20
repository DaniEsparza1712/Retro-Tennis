using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int isPlayer;
    ControllerP2 controllerP2;
    AI ai;

    public GameObject ball;
    Rigidbody2D ballRB;

    Vector2 distance;
    bool moved = false, onFirstRange = false;
    float offset;
    public float speed;
    public float standardSpeed;
    float reactionDistance;
    public float topDistance, bottomDistance, factorDistance;
    Vector2 posToMove;

    int chance = 1;

    private void Awake()
    {
        controllerP2 = gameObject.GetComponent<ControllerP2>();
        ai = gameObject.GetComponent<AI>();

        if (PlayerPrefs.GetInt("isPlayer2", 1) == 0)
        {
            controllerP2.enabled = false;
        }
        else
        {
            ai.enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = PlayerPrefs.GetFloat("offset", 0.75f);
        reactionDistance = PlayerPrefs.GetFloat("reaction distance", 2);
        standardSpeed = speed;
        ballRB = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position - ballRB.transform.position;
        if(Mathf.Abs(distance.x) >= 3)
        {
            onFirstRange = true;
            if(Mathf.Abs(distance.x) <= 5 && moved == false)
            {
                StartCoroutine(Move());
            }
        }
        else
        {
            onFirstRange = false;
        }
        if (Mathf.Abs(distance.x) < reactionDistance && moved == false)
        {
            if (PlayerPrefs.GetInt("CPULevel", 2) == 3)
            {
                chance = Random.Range(1, 3);
                Debug.Log(chance);
            }
            if (chance != 2)
            {
                StartCoroutine(Move());
            }
            else
            {
                Teleport();
            }
        }
        else if (Mathf.Abs(distance.x) > reactionDistance && onFirstRange == false)
        {
            moved = false;
        }
    }
    IEnumerator Move()
    {
        if(ballRB.velocity.x > 13)
        {
            factorDistance = 1.25f;
        }
        else
        {
            factorDistance = 1;
        }
        speed = standardSpeed;
        float direction;
        if(distance.y != 0)
        {
            direction = distance.y / Mathf.Abs(distance.y);
        }
        else
        {
            direction = 0;
        }
        moved = true;

        posToMove.y = distance.y + Random.Range(-offset, offset);

        for (float i = Mathf.Abs(posToMove.y); i > 0; i--)
        {
            if (Mathf.Abs(posToMove.y) > topDistance)
            {
                speed = standardSpeed * factorDistance * 1.75f;
            }
            else if (Mathf.Abs(posToMove.y) < bottomDistance)
            {
                speed = standardSpeed * factorDistance / 2;
            }
            yield return new WaitForSeconds(0.01f);
            transform.Translate(new Vector2(0, speed * -direction));
            i = i - speed + 1;
        }
    }
    void Teleport()
    {
        posToMove = new Vector2(transform.position.x, ballRB.transform.position.y);
        transform.position = posToMove;
        moved = true;
    }
}
