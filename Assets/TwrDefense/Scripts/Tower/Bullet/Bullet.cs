using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

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
            other.gameObject.GetComponent<Health>().ReceiveDamage(Damage);
            Delete();
        }
    }

    private void Delete()
    {
        gameObject.SetActive(false);
    }
}
