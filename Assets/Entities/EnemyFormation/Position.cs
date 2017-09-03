using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {


    void OnDrawGizmos()
    {
        /// makes the position object visible in the scene as a circle
        Gizmos.DrawWireSphere(this.transform.position, 1);
    }
}
