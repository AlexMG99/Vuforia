using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            GameManager.instance.HitPoint(50);
            Destroy(gameObject);
        }
    }


}
