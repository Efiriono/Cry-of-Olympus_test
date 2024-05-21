using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleUI : MonoBehaviour
{
    public Text enemyNameText;
    public Text enemyDescriptionText;
    public Text enemyLevelText;
    public Text enemyTierText;
    public Image enemySprite;

    private CreatureData enemyCreatureData;

    public void SetEnemyCreatureData(CreatureData creatureData)
    {
        enemyCreatureData = creatureData;
        UpdateUI();
    }

    private void UpdateUI()
    {
        
        enemyNameText.text = enemyCreatureData.animalData.creatureName;
        enemyDescriptionText.text = enemyCreatureData.animalData.description;
        enemyLevelText.text = "Level: " + enemyCreatureData.animalData.level.ToString();
        enemyTierText.text = "Tier: " + enemyCreatureData.animalData.tier.ToString();
        enemySprite.sprite = enemyCreatureData.animalData.creatureSprite;
    }

    public void OnFightButton()
    {
        Debug.Log("Начало боя с " + enemyCreatureData.animalData.creatureName);
        GameObject fightManagerObject = new GameObject("FightManager");
        fightManagerObject.AddComponent<FightManager>();
        CreatureData playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<CreatureData>();
        FightManager.Instance.SetPlayerData(playerData);
        FightManager.Instance.SetEnemyData(enemyCreatureData);
        SceneManager.LoadScene("Battle");
        Destroy(gameObject);
    }

    public void OnEscapeButton()
    {
        Debug.Log("Попытка сбежать от " + enemyCreatureData.animalData.creatureName);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}