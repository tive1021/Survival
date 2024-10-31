using TMPro;
using UnityEngine;

public class UIStart : MonoBehaviour
{ 
    [SerializeField] private GameObject uiPrefab;

    void Start()
    {
        InitializeUI();
    }

    void InitializeUI()
    {
        GameObject uiInstance = Instantiate(uiPrefab);

        // UI �ν��Ͻ����� Interaction ������Ʈ�� ã��
        Interaction interaction = FindObjectOfType<Interaction>();
        if (interaction != null)
        {
            // UI �ν��Ͻ����� promptText�� ������ Interaction�� ����
            TextMeshProUGUI promptText = uiInstance.GetComponentInChildren<TextMeshProUGUI>();
            interaction.promptText = promptText;
        }
    }
}