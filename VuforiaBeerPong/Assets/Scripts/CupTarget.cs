using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.cupPosition = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTable()
    {
        GameManager.instance.isTableSeen = true;
        
    }

    public void DeactivateTable()
    {
        GameManager.instance.isTableSeen = false;
        GameManager.instance.distanceText.text = "NO TABLE";
        GameManager.instance.distanceText.color = Color.red;
    }
}
