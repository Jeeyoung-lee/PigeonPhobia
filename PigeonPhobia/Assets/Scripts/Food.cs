using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    public int GetFoodHP()
    {
        return GetHP();
    }

    protected abstract int GetHP();
}
