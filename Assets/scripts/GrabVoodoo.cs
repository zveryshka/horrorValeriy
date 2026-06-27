using UnityEngine;

public class GrabVoodoo : MonoBehaviour
{
    public Camera playerCamera;

    public float grabDistance = 3f;
    public float holdDistance = 2f;

    private Rigidbody heldRb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldRb == null)
                TryGrab();
            else
                Drop();
        }

        if (heldRb != null)
        {
            MoveObject();
        }
    }

    void TryGrab()
    {
        if (playerCamera == null)
            return;

        Ray ray =
            playerCamera.ViewportPointToRay(
                new Vector3(0.5f, 0.5f, 0)
            );

        if (Physics.Raycast(ray, out RaycastHit hit, grabDistance))
        {
            if (hit.collider.CompareTag("VoodoO"))
            {
                heldRb =
                    hit.collider.GetComponent<Rigidbody>();

                if (heldRb != null)
                {
                    heldRb.useGravity = false;
                    heldRb.freezeRotation = true;
                }
            }
        }
    }

    void MoveObject()
    {
        heldRb.position =
            playerCamera.transform.position +
            playerCamera.transform.forward *
            holdDistance;
    }

    void Drop()
    {
        DropObject();
    }

    public void DropObject()
    {
        if (heldRb == null)
            return;

        heldRb.useGravity = true;

        heldRb.freezeRotation = false;

        heldRb = null;
    }
}