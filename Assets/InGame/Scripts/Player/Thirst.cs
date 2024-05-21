using UnityEngine;
using UnityEngine.UI;

public class Thirst : MonoBehaviour
{
    public float thirst;
    public float thirstDecayRate = 1f; 
    private Timeline timeline;
    public Text thirstText;
    public Slider thirstSlider;

    void Start()
    {
        GameObject _time = GameObject.Find("/UI/InGameUI/Canvas/Time/Time");
        timeline = _time.GetComponent<Timeline>();

        thirst = 100;
        thirstSlider.maxValue = 100;
        thirstSlider.value = thirst;
    }

    void Update()
    {
        if (timeline != null)
        {
            float decayAmount = thirstDecayRate * Time.deltaTime / 60f * 25f;
            thirst -= decayAmount;
            if (thirst < 0) 
            {
                thirst = 0;
            }
            thirstSlider.value = thirst; 
            thirstText.text = thirst.ToString("0"); 
        }
    }

    public void Drink(float amount)
    {
        thirst += amount;
        if (thirst > 100) 
        {
            thirst = 100; 
        }
        thirstSlider.value = thirst; 
        thirstText.text = thirst.ToString("0");
    }
}
