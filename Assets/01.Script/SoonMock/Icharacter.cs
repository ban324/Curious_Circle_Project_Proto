using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
public enum Compatibillity
{
    None,
    Weak,
    Resist,
    Reflect,
    Invalid
}

public enum AttacksType
{
    Strike,//타격
    Slash,//참격
    Penetrate,//관통
    Fire,
    Ice,
    Wind,
    Bolt,
    Light,
    Dark
}
public abstract class Icharacter 
{
    public Dictionary<int, Compatibillity> compatibility;
    public Dictionary<string, int> ownSkills;
    public Dictionary<string, int> Status;
    public int MaxHP;
    public int CurrentHP;
    public int MaxMP;
    public int CurrentMP;

    public int DamageCalc(AttacksType type, int damage)
    {
        int trueDamage = 0;
        switch (compatibility[(int)type])
        {
            case Compatibillity.None:
                {
                    trueDamage = damage;
                }
                break;
                case Compatibillity.Invalid:
                {
                    trueDamage = 0;
                }
                break;
                case Compatibillity.Weak:
                {
                    trueDamage = (damage /2)*3;
                }
                break;
                case Compatibillity.Reflect:
                {

                }
                break;
            case Compatibillity.Resist:
                {
                    trueDamage = damage /2;
                }
                break;
            default:
                break;
        }
        return trueDamage; 
    }
    public void OnDamage(AttacksType attacksType, int damage)
    {
        CurrentHP -= DamageCalc(attacksType, damage);
    }
}