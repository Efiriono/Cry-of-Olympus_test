using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightUI : MonoBehaviour
{
    public Text playerNameText;
    public Text playerHealthText;
    public Text enemyNameText;
    public Text enemyHealthText;

    public Button attackButton;
    public Button defendButton;
    public Button escapeButton;

    private CreatureData playerData;
    private CreatureData enemyData;

    void Start()
    {
        attackButton.onClick.AddListener(OnAttackButton);
        defendButton.onClick.AddListener(OnDefendButton);
        escapeButton.onClick.AddListener(OnEscapeButton);

        playerData = FightManager.Instance.playerData;
        enemyData = FightManager.Instance.enemyData;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (playerData != null && playerData.animalData != null)
        {
            playerNameText.text = playerData.animalData.creatureName;
            playerHealthText.text = "Health: " + playerData.animalData.healthMultiplier;
        }

        if (enemyData != null && enemyData.animalData != null)
        {
            enemyNameText.text = enemyData.animalData.creatureName;
            enemyHealthText.text = "Health: " + enemyData.animalData.healthMultiplier;
        }
    }

    void OnAttackButton()
    {
        FightManager.Instance.PlayerAttack();
        UpdateUI();
    }

    void OnDefendButton()
    {
        FightManager.Instance.PlayerDefend();
        UpdateUI();
    }

    void OnEscapeButton()
    {
        if (FightManager.Instance.TryEscape())
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }
}