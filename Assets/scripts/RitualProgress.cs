using UnityEngine;
using UnityEngine.AI;

public class RitualProgress : MonoBehaviour
{
    public static RitualProgress instance;

    public Enemy monster;

    public int placed = 0;

    public float speedPerVoodoo = 15f;

    public GameObject finalDoor;

    void Awake()
    {
        instance = this;
    }

    public void Place(
        bool openWall,
        GameObject wall
    )
    {
        placed++;

        Debug.Log(
            placed + "/5"
        );

        // Відкрити тільки стіну цієї зони
        if (openWall)
        {
            if (wall != null)
            {
                wall.SetActive(false);
            }
        }
        else
        {
            // Прискорити монстра
            if (monster != null)
            {
                NavMeshAgent agent =
                    monster.GetComponent<NavMeshAgent>();

                if (agent != null)
                {
                    agent.speed += speedPerVoodoo;

                    Debug.Log(
                        "Monster speed: "
                        + agent.speed
                    );
                }
            }
        }

        // Кінець тільки після 5
        if (placed == 5)
        {
            Debug.Log(
                "LEVEL END"
            );

            if (finalDoor != null)
            {
                finalDoor.SetActive(false);
            }
        }
    }
}