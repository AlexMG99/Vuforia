using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    float force = 1.0f;

    float current_time;
    [HideInInspector]
    public bool isVisible = false;
    [HideInInspector]
    public bool isThrown = false;
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
            Vector3 resultVector = GameManager.instance.ARCamera.transform.forward;
            float range = 0;
            switch (GameManager.instance.drunkState)
            {
                case GameManager.Drunk.QUITE_DRUNK:
                    range = Random.Range(-0.02f, 0.02f);
                    break;
                case GameManager.Drunk.DRUNK:
                    range = Random.Range(-0.04f, 0.04f);
                    break;
                case GameManager.Drunk.VERY_DRUNK:
                    range = Random.Range(-0.07f, 0.07f);
                    break;
            }
            resultVector += new Vector3(range, range, range);
            rb.AddForce(resultVector * force, ForceMode.Impulse);
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
