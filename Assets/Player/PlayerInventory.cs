using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int Money { get; private set; }

    public UnityEvent<PlayerInventory> OnMoneyCollected;

    public void MoneyCollected()
    {
        Money++;
        OnMoneyCollected.Invoke(this);
    }
}
