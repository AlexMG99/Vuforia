using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
            GameManager.instance.HitPoint(CalculateScore());
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private int CalculateScore()
    {
        float distance = GameManager.instance.CalculateDistance();
        int point = 0;

        if (distance > 0.3 && distance <= 0.45)
        {
            point = 25;
            GameManager.instance.redCupText.text = "TOO EASY";
        }
        else if (distance > 0.45 && distance <= 0.75)
        {
            point = 50;
            GameManager.instance.redCupText.text = "NICE";
        }
        else if (distance > 0.75 && distance <= 1.25)
        {
            point = 100;
            GameManager.instance.redCupText.text = "AMAZING";
        }
        else if (distance > 1.25)
        {
            point = 250;
            GameManager.instance.redCupText.text = "DRINKTASTIC";
        }

        return point;
    }

}
