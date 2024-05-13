using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timeline : MonoBehaviour
{    
    public int _days = 1;
    public int _hours = 12;    
    public float _minutes = 0;
    public Text text;    
    void Start()    
    {
    }
    void Update()
    {
        _minutes += (float)(Time.deltaTime * 1.6);
        if(_minutes >= 60)
        {
            _minutes -= 60;
            _hours += 1;
        }
        if(_hours >= 24)
        {
            _hours -= 24;
            _days += 1;
        }
        if (_hours >= 10 && _minutes >= 10)        
        {
            text.text = "День " + _days.ToString() + ", " + _hours.ToString() + ":" + _minutes.ToString("0");        
        }else if (_hours >= 10 && _minutes < 10)        
        {
            text.text = "День " + _days.ToString() + ", " + _hours.ToString() + ":0" + _minutes.ToString("0");        
        }else if (_hours < 10 && _minutes >= 10)        
        {
            text.text = "День " + _days.ToString() + ", 0" + _hours.ToString() + ":" + _minutes.ToString("0");        
        }else if (_hours < 10 && _minutes < 10)    
        {
            text.text = "День " + _days.ToString() + ", 0" + _hours.ToString() + ":0" + _minutes.ToString("0");       
        }
    }
}

