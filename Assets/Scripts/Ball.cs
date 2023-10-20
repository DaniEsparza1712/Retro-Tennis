using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float topSpeed = 30;
    GameObject manager;
    Manager managerScript;

    public AudioClip paddleClip, barrierClip, pointClip;

    GameObject clashP1, clashP2, clashGoal;

    private AudioSource audioSource;

    private Rigidbody2D rigidBody2D;
    public float xSpeed;
    public float xGrowth;
    int direction;

    bool roundStart = true;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<Manager>();

        clashP1 = GameObject.Find("ClashP1");
        clashP2 = GameObject.Find("ClashP2");
        clashGoal = GameObject.Find("ClashGoal");

        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roundStart)
        {
            rigidBody2D.AddForce(new Vector2(xSpeed, Random.Range(5, -5)), ForceMode2D.Impulse);
            roundStart = false;
        }
        if (rigidBody2D.transform.position.y > 5)
        {
            float posX = transform.position.x;
            transform.position = new Vector2(posX, 5);
        }
        else if (rigidBody2D.transform.position.y < -5)
        {
            float posX = transform.position.x;
            transform.position = new Vector2(posX, -5f);
        }
    }
    IEnumerator StartRound()
    {
        yield return new WaitForSeconds(3);
        transform.position = Vector2.zero;
        rigidBody2D.velocity = new Vector2(direction * xSpeed, Random.Range(-5, 5));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float ySpeed = rigidBody2D.velocity.y;
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(paddleClip, PlayerPrefs.GetFloat("SFXVolume") / 10);
            if (Mathf.Abs(rigidBody2D.velocity.x) < topSpeed)
            {
                xSpeed += xGrowth;
            }
            rigidBody2D.AddForce(new Vector2(-1 * rigidBody2D.velocity.x, 0), ForceMode2D.Impulse);

            if (transform.position.x < 0)
            {
                rigidBody2D.AddForce(new Vector2(xSpeed, Random.Range(5, -5)), ForceMode2D.Impulse);

                clashP1.GetComponent<ParticleSystem>().Play();
            }
            else if (transform.position.x > 0)
            {
                rigidBody2D.AddForce(new Vector2(-xSpeed, Random.Range(5, -5)), ForceMode2D.Impulse);
                clashP2.GetComponent<ParticleSystem>().Play();
            }
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            audioSource.PlayOneShot(barrierClip, PlayerPrefs.GetFloat("SFXVolume") / 10);
            rigidBody2D.AddForce(new Vector2(0, -2 * ySpeed), ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            managerScript.counter = 3;
            StartCoroutine(managerScript.CountForRound());

            clashGoal.GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(pointClip, PlayerPrefs.GetFloat("SFXVolume") / 10);
            if (xSpeed > 5)
            {
                xSpeed *= 0.75f;
            }
            if(transform.position.x > 0)
            {
                direction = -1;
                managerScript.p1Points += 1;
            }
            else
            {
                direction = 1;
                managerScript.p2Points += 1;
            }
            rigidBody2D.velocity = Vector2.zero;
            StartCoroutine(StartRound());
        }
    }
}
