using UnityEngine;
using UnityEngine.AI;

namespace Assets._ScaryCoffeeProject._CodeBase.Monster
{
    public class MonsterEnemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Animator _animator;

        [SerializeField] private AudioClip _eating;
        [SerializeField] private AudioClip _steps;
        [SerializeField] private AudioClip _triller;
        [SerializeField] private AudioClip _attacking;
    }
}
