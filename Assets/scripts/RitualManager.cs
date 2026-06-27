using UnityEngine;

public class RitualManager : MonoBehaviour
{
    public static RitualManager instance;

    public int currentStep = 1;

    public GameObject[] areas;

    public Enemy monster; // посилаємо ворога

    void Awake()
    {
        instance = this;
    }

    public void TryPlace(int zone, GameObject voodoo)
    {
        if (zone != currentStep)
            return;

        currentStep++;

        Destroy(voodoo);

        if (zone - 1 < areas.Length)
            areas[zone - 1].SetActive(true);

        // Підвищуємо швидкість монстра після кожної вуду
        monster.speed += 0.5f;

        Debug.Log("Вуду встановлено, монстр прискорився!");
    }
}