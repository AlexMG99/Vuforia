using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject ball;
    BallScript ballScript;
    public GameObject ARCamera;
    public Text scoreText;
    public Slider sliderScore;
    int score;

    AudioSource audioSource;
    public AudioClip clappingSound;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballScript = ball.GetComponent<BallScript>();
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
                ballScript.ThrowBall();
            }
        }
    }

    public void HitPoint(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        sliderScore.value++;
        audioSource.PlayOneShot(clappingSound);
    }



}
