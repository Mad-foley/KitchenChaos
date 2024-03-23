using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode {
        LookAt,
        LookAtInverted,
    }

    [SerializeField] private Mode mode;
    //runs after regular update
    //makes more sense to have camer update later
   private void LateUpdate() {
    switch (mode) {
        case Mode.LookAt:
            transform.LookAt(Camera.main.transform);
            break;
        case Mode.LookAtInverted:
            Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
            transform.LookAt(transform.position + dirFromCamera);
            break;
    }

   }
}
