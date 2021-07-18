using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public int Damage { get; set; }

    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Direction * Time.deltaTime * _speed);
    }
}
