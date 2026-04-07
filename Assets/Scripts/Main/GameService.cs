
using StatePattern.Enemy;
using StatePattern.Events;
using StatePattern.Level;
using StatePattern.Player;
using StatePattern.Sound;
using StatePattern.UI;
using StatePattern.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        // Services:
        public SoundService SoundService { get; private set; }
        public EventService EventService { get; private set; }
        public LevelService LevelService { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public EnemyService EnemyService { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;

        // Scriptable Objects:
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private PlayerScriptableObject playerScriptableObject;
        [SerializeField] private List<LevelScriptableObject> levelScriptableObjects;

        // Scene References:
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource bgMusicSource;

        protected override void Awake()
        {
            base.Awake();
            EventService = new EventService();
            SoundService = new SoundService(soundScriptableObject, sfxSource, bgMusicSource);
            LevelService = new LevelService(levelScriptableObjects);
            PlayerService = new PlayerService(playerScriptableObject);
            EnemyService = new EnemyService();
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => UIService != null);
            yield return null;

            UIService.ShowLevelSelectionUI(levelScriptableObjects.Count);
        }
    }
}