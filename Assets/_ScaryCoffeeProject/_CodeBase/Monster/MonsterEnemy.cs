using System;
using System.Collections;
using Assets._ScaryCoffeeProject._CodeBase.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._ScaryCoffeeProject._CodeBase.Monster
{
    public class MonsterEnemy : MonoBehaviour
    {
        private const string IsMoving = "IsMoving";
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Animator _animator;

        [SerializeField] private AudioClip _eating;
        [SerializeField] private AudioClip _attacking;

        private Coroutine _chaseRoutine;

        private PlayerCore _target;
        private bool _isReached;

        public event Action Killed;

        public void Init(PlayerCore target)
        {
            _target = target;
        }

        public void Chase()
        {
            if (_chaseRoutine == null)
            {
                _animator.SetBool(IsMoving, true);
                _chaseRoutine = StartCoroutine(ChaseRoutine());
                _agent.SetDestination(_target.transform.position);
                _audioSource.clip = _attacking;
                _audioSource.Play();
            }
        }

        private IEnumerator ChaseRoutine()
        {
            while (!_isReached)
            {
                _agent.SetDestination(_target.transform.position);
                yield return null;
            }

            _animator.SetBool(IsMoving, false);
            Killed?.Invoke();
            _agent.isStopped = true;
            _audioSource.clip = _eating;
            _audioSource.Play();
            transform.position = _target.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerCore playerCore))
            {
                _isReached = true;
            }
        }
    }
}
