using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public float hunger;
    public float hungerDecayRate = 1f;
    private Timeline timeline;
    public Text hungerText;
    public Slider hungerSlider;

    void Start()
    {
        GameObject _time = GameObject.Find("/UI/InGameUI/Canvas/Time/Time");
        timeline = _time.GetComponent<Timeline>();

        hunger = 100;
        hungerSlider.maxValue = 100;
        hungerSlider.value = hunger;
    }

    void Update()
    {
        if (timeline != null)
        {
            float decayAmount = hungerDecayRate * Time.deltaTime / 60f * 25f;
            hunger -= decayAmount;
            if (hunger < 0)
            {
                hunger = 0;
            } 

            hungerSlider.value = hunger; 
            hungerText.text = hunger.ToString("0");
        }
    }

    public void Eat(float amount)
    {
        hunger += amount;
        if (hunger > 100) 
        {
            hunger = 100; 
        }
        hungerSlider.value = hunger; 
        hungerText.text = hunger.ToString("0"); 
    }
}
