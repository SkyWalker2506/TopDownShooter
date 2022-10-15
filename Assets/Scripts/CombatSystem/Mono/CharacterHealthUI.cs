using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthUI : MonoBehaviour
{
    [SerializeField] CharacterHealth characterHealth;
    [SerializeField] Image healthBar;
    

    void OnEnable()
    {
        characterHealth.OnHealthUpdated += UpdateUI;
    }

    void OnDisable()
    {
        characterHealth.OnHealthUpdated -= UpdateUI;
    }

    void UpdateUI()
    {
         healthBar.fillAmount = characterHealth.HealthRatio;
    }
}