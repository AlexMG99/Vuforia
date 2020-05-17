using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiScript : MonoBehaviour
{
    public List<Sprite> spriteEmoji;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.instance.emojiFace = gameObject.GetComponent<EmojiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameManager.instance.ARCamera.transform);
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
}
