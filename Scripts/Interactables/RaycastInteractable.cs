using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public float interactDistance = 5f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            Debug.Log("Hit");

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                Debug.Log("Hit: " + hit.collider.name);

                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
                else
                {
                    Debug.Log("No Interactable on object");
                }
            }
            else
            {
                Debug.Log("Nothing hit");
            }
        }
    }
}