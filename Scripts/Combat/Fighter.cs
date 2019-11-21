using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;
        
        float timeSinceLastAttack = 0;
        Transform target;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;

            if (target != null && !GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
                
            }
                        
            else
            {
                GetComponent<Mover>().Cancel();
                
                
                    AttackBehaviour();
                
                
            }

        }

        private void AttackBehaviour()
            
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // This will trigger the Hit()
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
               
            }
        }
        void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            
            
        }

        public void Cancel()
        {
            target = null;
        }
      //private animation
     
    }
   
}