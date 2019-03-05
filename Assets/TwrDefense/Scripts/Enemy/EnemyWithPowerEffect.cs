using System.Collections;
using UnityEngine;

public class EnemyWithPowerEffect : Enemy
{
    public ParticleSystem particleEffect;
    private IEnemyPowerEffect powerEffect;

    [Header ("Effect")]
    public float minEffectTime = 1;
    public float maxEffectTime = 4;
    public float effectTime = 1;

    private float timer;
    private float waitTime;

    protected override void Awake()
    {
        base.Awake();
        powerEffect = GetComponent<IEnemyPowerEffect>();
        SetWaitTime();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        timer = 0;
        SetWaitTime();
    }

    private void Update()
    {
        if (IsDead)
        {
            animator.SetBool(EnemyAnimator.EFFECT, false);
            timer = 0;
            return;
        }

        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            StartCoroutine(ApplyEffect());
        }
    }

    IEnumerator ApplyEffect()
    {
        float time = 0;
        animator.SetBool(EnemyAnimator.EFFECT, true);
        while (time < effectTime)
        {
            time += Time.deltaTime;
            timer = 0;
            Movement.SlowDown(0, Time.deltaTime * 2);
            yield return 0;
        }

        SetWaitTime();
        if (!IsDead)
        {
            powerEffect.ApplyEffect();
            if (particleEffect != null)
            {
                particleEffect.Play();
            }
        }
        animator.SetBool(EnemyAnimator.EFFECT, false);
    }

    private void SetWaitTime()
    {
        waitTime = Random.Range(minEffectTime, maxEffectTime);
    }

}
