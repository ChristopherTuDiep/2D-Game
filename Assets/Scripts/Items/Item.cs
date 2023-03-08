using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item
{
    public string ItemName { get; set; }

    public int ItemCost { get; set; }
    public int ItemAmount { get; set; }

    public bool IsUsable { get; set; }

}
