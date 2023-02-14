using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManagement : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;
    [SerializeField] private InputAction thumbstick;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        //rayinteractor au depart est inactif
        rayInteractor.enabled = false;

        // declaration activation mode teleportation
        var activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        // chaque fois cette action est mise en route cette methode OnTeleportActivate() est activate 
        activate.performed += OnTeleportActivate;

        // declaration cancel mode teleportation
        var cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        //thumbstick  = manette  deplacement par la manette 
        thumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        thumbstick.Enable();


    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;
        if (thumbstick.triggered)
            return;

        // si la fonction GetCurrentRaycasHit renvoie false, donc pas de point hit donc pas de deplacement pour tout ce qui est 3D TryGetCurrent3DRaycastHit
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            rayInteractor.enabled = false;
            isActive = false;
            return;

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
            //destinationRotation =  ? , trouver comment coder la rotation car par rapport position = 0
        };
        provider.QueueTeleportRequest(request);
    }


    // creation de deux methodes la teleportation et l'annulation de la teleportation 

    void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        isActive = true;
    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        isActive = false;
    }

}
