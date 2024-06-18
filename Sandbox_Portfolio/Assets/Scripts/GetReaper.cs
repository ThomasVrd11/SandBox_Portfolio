using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GetReaper : MonoBehaviour
{
	[SerializeField] Transform tpDestination;
    [SerializeField] GameObject player;
	[SerializeField] GameObject effects;
	[SerializeField] List<GameObject> playerModels;
	[SerializeField] CinemachineVirtualCamera VCGetReaper;
	[SerializeField] CinemachineVirtualCamera VCGetReaper2;
	[SerializeField] Animator ghostAnimator;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") 
		{
			player.GetComponent<CharacterController>().enabled = false;
			player.GetComponent<CharacterControls>().enabled = false;
			effects.SetActive(true);
			StartCoroutine(TurnIntoReaper());
		}
	}

	IEnumerator  TurnIntoReaper()
	{
		player.transform.LookAt(VCGetReaper.gameObject.transform.position);
		VCGetReaper.gameObject.SetActive(true);
		yield return new WaitForSeconds(2);
		ghostAnimator.SetTrigger("Surprised");
		yield return new WaitForSeconds(3);
		ghostAnimator.SetTrigger("Surprised");
		playerModels[0].SetActive(true);
		playerModels[2].SetActive(true);
		yield return new WaitForSeconds(0.5f);
		playerModels[1].SetActive(false);
		yield return new WaitForSeconds(0.5f);
		player.GetComponent<Animator>().SetTrigger("Skill1Stage");
		yield return new WaitForSeconds(4);
		VCGetReaper2.gameObject.SetActive(true);
		yield return new WaitForSeconds(8);
		player.transform.position = tpDestination.position;
		yield return new WaitForSeconds(3);
		VCGetReaper2.gameObject.SetActive(false);
		VCGetReaper.gameObject.SetActive(false);
		yield return new WaitForSeconds(1);
		player.GetComponent<CharacterControls>().enabled = true;
		player.GetComponent<CharacterController>().enabled = true;
		Destroy(gameObject);
		yield return null;
	}
}
