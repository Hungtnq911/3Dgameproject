using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mark_for_death : MonoBehaviour
{
    #region Singleton
    public static mark_for_death instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject target;
}
