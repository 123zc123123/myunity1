using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleNPC1 : SingleNPCBase
{



    protected override void Start()
    {
        base.Start();
        dictionType = DictionType.singleNPCDiction;
        canDiction = false;
        dictionIndex = 0;
        oldIndex = 0;
        SetDiction();
    }

    

    private void SetDiction()
    {
        npcDictions = new NPCDiction[3];
        npcDictions[0] = new NPCDiction("Amy", "This region, which was once a thriving empire, is now in a state of disrepair.", 1, false);
        npcDictions[1] = new NPCDiction("Amy", "The insectoid race has invaded our homeland, and the brave knights have fought hard, but it has been in vain.", 2, false);
        npcDictions[2] = new NPCDiction("Amy", "The king led us to flee our homeland, but most people starved to death on the way.", -1, false);
    }

}
