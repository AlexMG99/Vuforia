using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void OpenMenu()
    {
        gameObject.SetActive(!gameObject.active);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
