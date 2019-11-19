
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;



namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {



        private void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

            }
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {

                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray GetMouseRay = PlayerController.GetMouseRay();
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay, out hit);
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}