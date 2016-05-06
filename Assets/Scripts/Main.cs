using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	[SerializeField]
	NumberSprites Numbers;

	[SerializeField]
	Shaker Shaker;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(Increase());
		StartCoroutine(Shake());

		Sound.Instance.PlayBGM("sample-bgm");
		Sound.Instance.FadeOutBGM(5f, () => Debug.Log("Completely fade out"));

		Sound.Instance.PlaySE("sample-se");
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

	IEnumerator Shake()
	{
		yield return new WaitForSeconds(1f);
		this.Shaker.Shake();
	}
}
