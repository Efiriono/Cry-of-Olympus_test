using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public int _strength = 5;
    public int _agility = 5;
    public int _intelligence = 5;
    public int _freePoints = 0;
    public Button _strengthIncreaseButton;
    public Button _agilityIncreaseButton;
    public Button _intelligenceIncreaseButton;
    public Text _strengthValue;
    public Text _agilityValue;
    public Text _intelligenceValue;
    public Text _freePointsText;
    void Start()
    {
        AddPoints();
    }

    // Update is called once per frame
    void Update()
    {
        _strengthValue.text = _strength.ToString();
        _agilityValue.text = _agility.ToString();
        _intelligenceValue.text = _intelligence.ToString();
        _freePointsText.text = "Свободные очки: " + _freePoints.ToString();
    }

    public void AddPoints()
    {
        _strengthIncreaseButton.onClick.AddListener(() =>
        {
            if(_freePoints > 0){
                _strength += 1;
                _freePoints -= 1;
            }
        });

        _agilityIncreaseButton.onClick.AddListener(() =>
        {
            if(_freePoints > 0){
                _agility += 1;
                _freePoints -= 1;
            }
        });

        _intelligenceIncreaseButton.onClick.AddListener(() =>
        {
            if(_freePoints > 0){
                _intelligence += 1;
                _freePoints -= 1;
            }
        });
    }
}
