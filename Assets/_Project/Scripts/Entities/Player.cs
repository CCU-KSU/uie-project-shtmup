using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public class Player : Plane
    {
        protected override void Die(int cause)
        {
            //throw new NotImplementedException();
            Debug.Log("ded");
        }
    }
}
