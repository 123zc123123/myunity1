using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtrributeType 
{
    public string name;

    private float value;

    public AtrributeType(string _name,float _value=0) 
    {
        name = _name;
        value = _value;
    }

    public void SetValue(float _value) 
    {
        value = _value;
    }


    public void AddValue(float _addValue) 
    {
        value += _addValue;
    }

    public void SubValue(float _addValue) 
    {
        value -= _addValue;
        if (value < 0) 
        {
            value = 0;
        }
    }
    public float GetValue() 
    {
        return value;
    }
}
