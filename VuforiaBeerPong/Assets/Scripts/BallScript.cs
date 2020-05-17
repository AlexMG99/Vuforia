using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    float force = 1.0f;

    float current_time;
    bool isVisible = false;
    bool isThrown = false;
    public float liveTime = 2.0f;

    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrown && Time.time - current_time >= liveTime)
        {
            transform.parent = GameManager.instance.ARCamera.transform;
            transform.localPosition = startPosition;

            rb.velocity = rb.angularVelocity = Vector3.zero;

            isThrown = false;
        }
    }

    public void ThrowBall()
    {
        if (!isVisible && !isThrown)
        {
            gameObject.SetActive(true);
            isVisible = true;
        }
        else if (isVisible && !isThrown)
        {
            rb.AddForce(GameManager.instance.ARCamera.transform.forward * force, ForceMode.Impulse);
            current_time = Time.time;
            transform.parent = null;
            isThrown = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
