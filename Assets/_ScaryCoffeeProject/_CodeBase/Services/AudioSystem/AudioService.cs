using UnityEngine;

namespace Assets._ScaryCoffeeProject._CodeBase.Services.AudioSystem
{
    public class AudioService : MonoBehaviour
    {
        public static AudioService Instance { get; private set; }

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _backgroundMusicDefault;

        public  AudioSource AudioSource => _audioSource;

        private void Awake()
        {
            Instance = this;
        }
    }
}
