using QF.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public string Name;
    public int Life;
    public int Attack;
    public int Defend;
    public int Level;
    public int Experience;
    public int Gold;

    private void Reset()
    {
        Name = transform.name;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.Hide();
    }
}
