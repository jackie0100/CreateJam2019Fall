using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : Character
{
    public TheMonoLog monolog;
    public override void Death(){
        monolog.win();
    }
}
