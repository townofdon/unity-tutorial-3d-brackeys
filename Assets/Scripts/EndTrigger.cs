﻿
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameManager.getInstance().CompleteLevel();
    }
}
