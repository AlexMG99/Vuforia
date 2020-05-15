using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject ARCamera;
    public Text scoreText;
    public float liveTime = 10.0f;
    int score;
    float current_time;
    bool isVisible = false;
    bool isThrown = false;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        //bool focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        //if (!focusModeSet)
        //    Debug.Log("Failed to set focus mode");

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = touch.position;
            
            if (touch.phase == TouchPhase.Began)
            {
                if (!isVisible && !isThrown)
                {
                    ball.SetActive(true);
                    isVisible = true;
                }
                else if (isVisible && !isThrown)
                {
                    ball.GetComponent<Rigidbody>().AddForce(ARCamera.transform.forward * 20);
                    current_time = Time.time;
                }
            }
        }

        if(isThrown && Time.time - current_time >= liveTime)
        {
            transform.SetPositionAndRotation(startPosition, transform.rotation);
            isVisible = false;
            isThrown = false;
        }
    }

    public void IncreaseScore(string text, int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }


}
