using System.Collections;
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
        Fighter fighter;
        GameObject player;
        Health health;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (health.IsDead()) return;

            //if (player == null) return;

            //if (player != null && !IsInRange())


            if (InAttackRangeofPlayer() && fighter.CanAttack(player))
            {

                //GetComponent<Mover>().MoveTo(Player.transform.position);
                fighter.Attack(player);


            }
            else
            {
                fighter.Cancel();
            }
        }
        private bool InAttackRangeofPlayer()
        {

            //GameObject player = GameObject.FindWithTag("Player");
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;

            // I this as a bool with the logic processed in the method
            //return Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) > chaseDistance;
        }
    }
}