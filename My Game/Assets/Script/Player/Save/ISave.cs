using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISave 
{

    public void Save(ref SaveStruct _saveDate);

    public void Load(SaveStruct _loadDate);
}
