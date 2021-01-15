using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 1f;
    [SerializeField] AudioClip[] audioClips;

    Vector2 paddleToBallVector;
    bool hasStarted;
    AudioSource audioSource;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = this.transform.position - paddle1.transform.position;
        hasStarted = false;
        audioSource = GetComponent<AudioSource>();
        rigidbody = FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }
    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }
    private void LockBallToPaddle()
    {

        Vector2 paddlePos = paddle1.transform.position;
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            rigidbody.AddForce(new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor)));
        }
    }
}
