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
    int score;

    // Start is called before the first frame update
    void Start()
    {
        //bool focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        //if (!focusModeSet)
        //    Debug.Log("Failed to set focus mode");
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
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;

                //if(Physics.Raycast(ray, out hitObject))
                //{
                //    if(hitObject.)
                //}

                GameObject currentBall = Instantiate(ball, ARCamera.transform);
                currentBall.GetComponent<Rigidbody>().AddForce(ARCamera.transform.forward * 20);
            }
        }
    }

    public void IncreaseScore(string text, int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
