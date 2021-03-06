﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 5f;
        Fighter fighter;
        GameObject player;
        Health health;
        Vector3 guardPosition;
        float timeSinceLastSawPlayer = Mathf.Infinity;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
            guardPosition = transform.position;

        }

        private void Update()
        {
            if (health.IsDead()) return;

            //if (player == null) return;

            //if (player != null && !IsInRange())


            if (InAttackRangeofPlayer() && fighter.CanAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                //GetComponent<Mover>().MoveTo(Player.transform.position);
                AttackBehavior();

            }
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                SuspicionBehavior();

                
            }
            else
            {
                //fighter.Cancel();
                GuardBehavior();

            }
            timeSinceLastSawPlayer += Time.deltaTime;
        }

        private void GuardBehavior()
        {
            GetComponent<Mover>().StartMoveAction(guardPosition);
        }

        private void SuspicionBehavior()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehavior()
        {
            fighter.Attack(player);
        }

        private bool InAttackRangeofPlayer()
        {

            //GameObject player = GameObject.FindWithTag("Player");
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;

            // I this as a bool with the logic processed in the method
            //return Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) > chaseDistance;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

    }


}