using UnityEngine;
using TMPro; // Обязательно для работы с TextMeshPro
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Перетащи сюда свой текст
    [TextArea] public string fullText = "Здесь будет твой сюжетный текст..."; // Пиши текст прямо в инспекторе
    public float delayBetweenLetters = 0.05f; // Скорость появления букв

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        textComponent.text = ""; // Очищаем текст перед началом

        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter; // Добавляем по одной букве
            yield return new WaitForSeconds(delayBetweenLetters); // Ждем немного
        }
    }
}
