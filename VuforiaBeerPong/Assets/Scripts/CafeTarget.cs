using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeTarget : MonoBehaviour
{
    public void ActivateMarker()
    {
        GameManager.instance.isMarkerSeen = true;
    }

    public void DeactivateMarker()
    {
        GameManager.instance.isMarkerSeen = false;
        GameManager.instance.distanceText.text = "NO TABLE";
        GameManager.instance.distanceText.color = Color.red;
    }
}
