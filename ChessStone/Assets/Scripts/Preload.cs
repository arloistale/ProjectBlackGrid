using UnityEngine;
using System.Collections;

public class Preload : MonoBehaviour
{
  [SerializeField]
  private string firstLevelName;
  
	void Awake() {
		Application.LoadLevel(firstLevelName);
	}
}