using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MonsterScript> () != null)
        {
            GameController.instance.MonsterScored();
        }
    }
}
