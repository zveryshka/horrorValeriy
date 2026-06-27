using UnityEngine;
using UnityEngine.UI;

public class MonsterWarning : MonoBehaviour
{
    public Transform player;
    public Transform monster;

    public Image dangerImage;

    public float maxDistance = 40f;

    void Update()
    {
        float distance = Vector3.Distance(
            player.position,
            monster.position
        );

        float alpha = 1 - (distance / maxDistance);

        alpha = Mathf.Clamp01(alpha);

        Color c = dangerImage.color;
        c.a = alpha * 0.6f; // максимальна червоність
        dangerImage.color = c;
    }
}