using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance instance;

    [Header("GameSystem")]
    public float Time;
    public int Score;
    public int StageLevel;

    [Header("Player")]
    public int PlayerLevel;
    public int MaxPlayerLevel;

    public float PlayerEXP;
    public float MaxPlayerEXP;

    public float PlayerHp;
    public float MaxPlayerHp;

    public float PlayerATK;
    public float PlayerCriticalChance;
    public float PlayerCriticalHit;

    public float PlayerMoveSpeed;

    public int PlayerWeapon;
    public int PlayerWeaponLevel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }            
        else
            Destroy(gameObject);
    }
}
