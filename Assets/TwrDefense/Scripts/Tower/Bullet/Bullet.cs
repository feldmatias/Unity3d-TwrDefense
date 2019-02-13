using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public bool onlyAttackTarget = true;

    public Enemy Target { get; set; }

    public float Damage { get; set; }

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Target == null || !Target.gameObject.activeSelf || Target.IsDead)
        {
            Delete();
        }
        else
        {
            transform.LookAt(Target.ShootingPosition);
            rigidBody.velocity = transform.forward * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Target.gameObject)
        {
            DamageTarget();
            Delete();
        }
        else if (!onlyAttackTarget && other.gameObject.CompareTag(Tags.ENEMY))
        {
            DamageEnemy(other.gameObject, Damage);
        }
    }

    protected virtual void DamageTarget()
    {
        Target.Health.ReceiveDamage(Damage);
    }

    protected virtual void DamageEnemy(GameObject enemy, float damage)
    {
        enemy.GetComponent<Enemy>().Health.ReceiveDamage(damage);
    }

    private void Delete()
    {
        gameObject.SetActive(false);
    }
}
