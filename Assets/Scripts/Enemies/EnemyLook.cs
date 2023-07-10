using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = _player.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
