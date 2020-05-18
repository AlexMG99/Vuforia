using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameManager : MonoBehaviour
{
    public enum Distance
    {
        TOO_CLOSE,
        CLOSE,
        MIDDLE,
        FAR,
        VERY_FAR
    };

    public static GameManager instance { get; private set; }

    [HideInInspector]
    public bool isTableSeen = false;
    [HideInInspector]
    public bool isMarkerSeen = false;
    bool hasWin = false;
    [HideInInspector]
    public GameObject cupPosition;
    [HideInInspector]
    public EmojiScript emojiFace;

    public GameObject ball;
    BallScript ballScript;

    public GameObject ARCamera;
    public Text scoreText;
    public Slider sliderScore;
    public GameObject redCup;
    public Text redCupText;
    public TextMesh distanceText;
    public GameObject winObject;

    int score;
    Distance distanceState;

    AudioSource audioSource;
    public AudioClip clappingSound;
    public AudioClip winSound;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballScript = ball.GetComponent<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began && !redCup.active && isTableSeen && isMarkerSeen && CalculateDistance() > 0.3)
            {
                ballScript.ThrowBall();
            }
            if(hasWin)
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }

        if (redCup.active && !audioSource.isPlaying)
        {
            redCup.SetActive(false);
            emojiFace.DrinkBeer();
            if (sliderScore.value == sliderScore.maxValue - 1)
            {
                WinGame();
            }
        }

        if(isTableSeen)
            StateManager();
    }

    public void HitPoint(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        audioSource.PlayOneShot(clappingSound);
        redCup.SetActive(true);
    }

    public float CalculateDistance()
    {
        Vector3 distance = cupPosition.transform.position - ARCamera.transform.position;
        return distance.sqrMagnitude;
    }


    void StateManager()
    {
        float distance = GameManager.instance.CalculateDistance();

        if (distance < 0.3)
            distanceState = Distance.TOO_CLOSE;
        else if (distance > 0.3 && distance <= 0.45)
            distanceState = Distance.CLOSE;
        else if (distance > 0.45 && distance <= 0.75)
            distanceState = Distance.MIDDLE;
        else if (distance > 0.75 && distance <= 1.25)
            distanceState = Distance.FAR;
        else if (distance > 1.25)
            distanceState = Distance.VERY_FAR;

        switch (distanceState)
        {
            case Distance.TOO_CLOSE:
                distanceText.text = "TOO CLOSE";
                distanceText.color = Color.red;
                if(!ballScript.isThrown)
                {
                    ball.SetActive(false);
                    ballScript.isVisible = false;
                    ballScript.isThrown = false;
                }
                break;
            case Distance.CLOSE:
                distanceText.text = "Close";
                distanceText.color = Color.yellow;
                break;
            case Distance.MIDDLE:
                distanceText.text = "Good";
                distanceText.color = Color.green;
                break;
            case Distance.FAR:
                distanceText.text = "Far";
                distanceText.color = Color.blue;
                break;
            case Distance.VERY_FAR:
                distanceText.text = "Very far";
                distanceText.color = Color.magenta;
                break;
        }
    }

    void WinGame()
    {
        winObject.SetActive(true);
        audioSource.PlayOneShot(winSound);
        hasWin = true;
        ball.SetActive(false);
    }
}
