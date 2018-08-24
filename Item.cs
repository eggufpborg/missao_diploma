using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private AudioSource source;
    public AudioClip itemSound;
    public float vol;

	void Awake ()
    {
		source = GetComponent<AudioSource> ();
	}

	/*Adiciona o som escolhido na colisão */

	 void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            source.PlayOneShot(itemSound, vol);
            /*Faz o item sumir caso entre em contato com um player*/
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<MeshRenderer>());
            Destroy(gameObject, 2);
        }
	}
}

