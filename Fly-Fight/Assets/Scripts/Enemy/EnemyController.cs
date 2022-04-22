using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool _isLife = true;
    [SerializeField] private EnemyTrigger _enemyTrigger;
    [SerializeField] private CopyLimb _copyLimb;
    [SerializeField] private ParticleSystem _death;

    private StateMachine _SM;
    private IdleState _idleState;
    private Attack03State _attack03State;
    private Attack360State _attack360State;
    private AttackBackhandState _attackBackhandState;
    private AttackDownwardState _attackDownwardState;
    private AttackHorizontalState _attackHorizontalState;
    private AttackKickState _attackKickState;
    private ComboAttackState _comboAttackState;
    [SerializeField] private Animator _enemyAnimator;

    private void Start()
    {
        _SM = new StateMachine();
        _idleState = new IdleState(_enemyAnimator);
        _attack03State = new Attack03State(_enemyAnimator);
        _attack360State = new Attack360State(_enemyAnimator);
        _attackBackhandState = new AttackBackhandState(_enemyAnimator);
        _attackDownwardState = new AttackDownwardState(_enemyAnimator);
        _attackHorizontalState = new AttackHorizontalState(_enemyAnimator);
        _attackKickState = new AttackKickState(_enemyAnimator);
        _comboAttackState = new ComboAttackState(_enemyAnimator);

        _SM.Initialize(_idleState);

        TakeAnimation();
    }

    private void OnEnable()
    {
        _enemyTrigger.OnDeath += Death;
    }

    public void TakeAnimation()
    {
        IEnumerator AnimationCor()
        {
            while (_isLife)
            {
                int animNumber = Random.Range(1, 8);
                switch (animNumber)
                {
                    case 1: _SM.ChangeState(_attack03State); break;
                    case 2: _SM.ChangeState(_attack360State); break;
                    case 3: _SM.ChangeState(_attackBackhandState); break;
                    case 4: _SM.ChangeState(_attackDownwardState); break;
                    case 5: _SM.ChangeState(_attackHorizontalState); break;
                    case 6: _SM.ChangeState(_attackKickState); break;
                    case 7: _SM.ChangeState(_comboAttackState); break;
                    default: Debug.Log("Animation counts error"); break;
                }
                yield return new WaitForSeconds(_enemyAnimator.GetCurrentAnimatorClipInfo(0).Length);
                _SM.ChangeState(_idleState);
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
        }
        
        StartCoroutine(AnimationCor());
    }

    private void Death()
    {
        _isLife = false;
        _copyLimb.IsPlayerActive = true;
        _enemyTrigger.HealthBarInActive();
        _copyLimb.DeleteJoints();
        _death.transform.SetParent(null);
        _death.Play();
        UIController.Instance.Killed++;
        UIController.Instance.CheckWin();
    }

    private void OnDisable()
    {
        _enemyTrigger.OnDeath -= Death;
    }
}
