using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportationManagement : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;

    // Start is called before the first frame update
    void Start()
    {
        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
