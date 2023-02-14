using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDescription : MonoBehaviour
{
    [SerializeField] private GameObject description;
    private bool displayed = false;

    public void SwitchDisplay()
    {
        displayed = !displayed;
        description.SetActive(displayed);
    }

    /*
    private void OnMouseOver()
    {
        if (click)
        SwitchDisplay();
    }
    */
}
