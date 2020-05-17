using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiScript : MonoBehaviour
{
    public List<Sprite> spriteEmoji;
    SpriteRenderer spriteRenderer;
    [HideInInspector]
    public GameObject cup;
    Animator cupAnimator;
    float currentTime;

    bool isDrinking = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cup = transform.GetChild(1).gameObject;
        cupAnimator = cup.GetComponent<Animator>();
        GameManager.instance.emojiFace = gameObject.GetComponent<EmojiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameManager.instance.ARCamera.transform);

        if(isDrinking && Time.time - currentTime > 2)
        {
            int value = (int)GameManager.instance.sliderScore.value++;
            ChangeEmojiFace(value);
            cup.SetActive(false);
            isDrinking = false;
        }
    }

    public void ChangeEmojiFace(int beer)
    {
        if(beer < 2)
        {
            spriteRenderer.sprite = spriteEmoji[0];
        }
        else if(beer >= 2 && beer < 5)
        {
            spriteRenderer.sprite = spriteEmoji[1];
        }
        else if(beer >= 5 && beer < 8)
        {
            spriteRenderer.sprite = spriteEmoji[2];
        }
        else if (beer >= 8)
        {
            spriteRenderer.sprite = spriteEmoji[3];
        }
    }

    public void DrinkBeer()
    {
        cup.SetActive(true);
        cupAnimator.Play("Drink");
        cup.GetComponent<AudioSource>().Play();
        isDrinking = true;
        currentTime = Time.time;
    }
}
