using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	public NumberSprites Numbers;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Increase());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator Increase()
	{
		Numbers.Reset(0);
		while (true)
		{
			this.Numbers.Value += Random.Range(10, 20);
			yield return new WaitForSeconds(2);
		}
	}
}
