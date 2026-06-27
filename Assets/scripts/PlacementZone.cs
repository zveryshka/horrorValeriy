using UnityEngine;
using UnityEngine.AI;

public class PlacementZone : MonoBehaviour
{
    public Transform snapPoint;

    public GameObject wallToOpen;

    public Enemy monster;

    public float speedBoost = 1f;

    bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated)
            return;

        if (!other.CompareTag("VoodoO"))
            return;

        Debug.Log("Вуду поставлено");

        Rigidbody rb =
            other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;

            rb.velocity =
                Vector3.zero;

            rb.angularVelocity =
                Vector3.zero;

            rb.isKinematic = true;
        }

        other.transform.position =
            snapPoint.position;

        other.transform.rotation =
            snapPoint.rotation;

        other.transform.SetParent(
            snapPoint
        );

        GrabVoodoo grab =
    FindFirstObjectByType<GrabVoodoo>();

        if (grab != null)
        {
            grab.DropObject();
        }

        if (wallToOpen != null)
        {
            wallToOpen.SetActive(false);
        }

        if (monster != null)
        {
            NavMeshAgent agent =
                monster.GetComponent<NavMeshAgent>();

            if (agent != null)
            {
                agent.isStopped = false;

                agent.speed += speedBoost;

                if (monster.player != null)
                {
                    agent.SetDestination(
                        monster.player.position
                    );
                }
            }
        }

        activated = true;

        RitualProgress.instance.Place(
    wallToOpen != null,
    wallToOpen
);
    }
}