using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public InputActionReference interact;
    public float interactRange = 3f;
    public Camera playerCamera;

    private void OnEnable()
    {
        interact.action.started += TryInteract;
    }

    private void OnDisable()
    {
        interact.action.started -= TryInteract;
    }

    private void TryInteract(InputAction.CallbackContext context)
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                return;
            }

            MoneyPickup money = hit.collider.GetComponent<MoneyPickup>();
            if (money != null)
            {
                money.Collect();
            }
        }
    }
}
