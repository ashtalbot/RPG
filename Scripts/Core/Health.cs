﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        float healthPoints = 100f;
        bool isDead = false;
        public bool IsDead()
        {
            return isDead;
        }
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if (healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //if (isDead)
            //{
            //return;
            //}

            if (isDead) return;
           
            {
                isDead = true;
                GetComponent<Animator>().SetTrigger("die");
                GetComponent<ActionScheduler>().CancelCurrentAction();
                //GetComponent<Mover>().Cancel();
            }
                

            
        }

       // public void zeroHealth()
       // {
            //GetComponent<Animator>().SetTrigger("stopAttack");
            
            
       // }
    }

}