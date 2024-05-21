using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTrigger : MonoBehaviour
{
    public GameObject battleUIPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;

            GameObject canvas = GameObject.FindGameObjectWithTag("UICanvas");
            GameObject battleUI = Instantiate(battleUIPrefab, canvas.transform);
            BattleUI battleUIScript = battleUI.GetComponent<BattleUI>();
            CreatureData creatureData = GetComponent<CreatureData>();
            battleUIScript.SetEnemyCreatureData(creatureData);
                
        }
    }
}