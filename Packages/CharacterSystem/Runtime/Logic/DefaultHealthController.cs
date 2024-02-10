using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class DefaultHealthController : CharacterHealthControllerBase
    {
        private CharacterEventHandler characterEventHandler;
        private CharacterEventHandler CharacterEventHandler
        {
            get
            {
                return characterEventHandler == null ? characterEventHandler
                    = transform.root.GetComponentInChildren<CharacterEventHandler>()
                    : characterEventHandler;
            }
        }
        private CheckpointCharacter checkpointCharacter => gameObject.GetComponent<CheckpointCharacter>();


        private void OnEnable()
        {
            CharacterEventHandler.OnReviveRequested.AddListener(ReviveCharacter);
        }
        private void OnDisable()
        {
            CharacterEventHandler.OnReviveRequested.RemoveListener(ReviveCharacter);
        }
        private void Start()
        {
            ReviveCharacter();
        }

        private void Update()
        {
            //Checkpoint Deneme if'i bunu sil
            if (gameObject.transform.position.y < -20)
            {
                ReviveCharacter();
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                ReviveCharacter();
            }
        }
        public override void Heal(float health)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + health, 0, HealthData.MaxHealth);
            CharacterEventHandler.OnCharacterRecieveHeal.Invoke();
        }

        public override void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            CharacterEventHandler.OnCharacterTakeDamage.Invoke();
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                KillCharacter();
            }
        }

        public override void ReviveCharacter()
        {
            base.ReviveCharacter();     
            gameObject.transform.position = new Vector3(10,10,10);
            CurrentHealth = HealthData.MaxHealth;
            CharacterEventHandler.OnCharacterRevive.Invoke();
            Debug.Log("spawned");
        }

        public override void KillCharacter()
        {
            base.KillCharacter();
            characterEventHandler.OnCharacterDeath.Invoke();

        }
    }
}
