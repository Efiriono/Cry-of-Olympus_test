    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ThirstAndHunger : MonoBehaviour
    {  
        public Slider slider; 
        public Text text; 
        public float _minutes;
        public Timeline _timeLine;
        private float sl_value;
        void Start()
        {
            _timeLine = GameObject.FindGameObjectWithTag("Time").GetComponent<Timeline>();
            _minutes = (float)_timeLine._minutes % 5;
            sl_value = (float)(slider.value * 100);
        }
        void Update()
        { 
            int value = (int)sl_value;
            text.text = value.ToString("0"); 
            _minutes += (float)(Time.deltaTime * 1.6);
            if(_minutes >= 5)
            {
                _minutes -= 5;
                sl_value -= 1;
                slider.value -= 0.01f;
            }
        }
    }
