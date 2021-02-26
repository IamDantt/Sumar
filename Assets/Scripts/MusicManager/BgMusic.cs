using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    
    public static BgMusic BgInstace;
    
   private void Awake()
    {
        if(BgInstace != null && BgInstace != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstace = this;
        DontDestroyOnLoad(this);

    }
}
