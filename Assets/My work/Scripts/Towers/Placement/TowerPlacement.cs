using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Towers.Placement;

namespace Palewyn
{

    public class TowerPlacement : MonoBehaviour
    {

        public LayerMask hitLayers;


        private void OnDrawGizmos()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 1000f);
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Perform raycaast
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(camRay, out hit, 1000f, hitLayers))
                {
                    //Check if hitting grid
                    IPlacementArea placement = hit.collider.GetComponent<IPlacementArea>();
                    //Get grid position
                    if (placement != null)
                    {
                        //snap position tower to grid element
                        transform.position = placement.Snap(hit.point, new Core.Utilities.IntVector2(1, 1));
                    }
                }
            }




        }
    }
}
