using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimationNames : MonoBehaviour
{
    public int IdleHash = Animator.StringToHash("Idle");
    public int ComboAttackHash = Animator.StringToHash("ComboAttack");
    public int AttackBackhandHash = Animator.StringToHash("AttackBackhand");
    public int AttackHorizontalHash = Animator.StringToHash("AttackHorizontal");
    public int Attack03Hash = Animator.StringToHash("Attack03");
    public int Attack360Hash = Animator.StringToHash("Attack360");
    public int AttackDownwardHash = Animator.StringToHash("AttackDownward");
    public int AttackKickHash = Animator.StringToHash("AttackKick");
    public int NoneHash = Animator.StringToHash("None");
    public int StandUpHash = Animator.StringToHash("StandUp");
}
