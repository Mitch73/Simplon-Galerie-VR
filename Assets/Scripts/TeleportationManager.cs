using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] XRRayInteractor rayInteractor;
    [SerializeField] TeleportationProvider provider;
    private bool _isActive;
    private InputAction _thumpstick;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        _thumpstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        _thumpstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
            return;

        if (_thumpstick.triggered)
            return;

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
            /*destinationRatation =,*/
        };

        provider.QueueTeleportRequest(request);
    }

    void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }
}
