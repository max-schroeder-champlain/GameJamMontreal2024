using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBox : MonoBehaviour
{
    public GameObject[] BoxPrefabs;
    public RandomizeAudio fireSound;
    public Light fireLight;
    private AudioSource catSource;
    public AudioClip[] clips;
    public bool CanCreate = true;
    // Start is called before the first frame update
    void Start()
    {
        CenterPoint.instance.CreateNewBox = this;
        catSource = GetComponent<AudioSource>();
    }
    private void RandomizeAudio()
    {
        int rand = Random.Range(0, clips.Length);
        catSource.clip = clips[rand];
    }
    public void CreateBox()
    {
        if (!CanCreate) return;
        int rand = Random.Range(0, BoxPrefabs.Length);
        GameObject temp = Instantiate(BoxPrefabs[rand], this.transform.position, Quaternion.identity);
        Vector3 pos = CenterPoint.instance.gameObject.transform.position;
        temp.GetComponent<BoxScript>().MoveToStart(new Vector3(pos.x, pos.y - 0.5f, pos.z));
        temp.GetComponent<BoxScript>().IsCat = RandomizeCat();
        CanCreate = false;
    }
    private bool RandomizeCat()
    {
        int rand = Random.Range(0, 9);
        if( rand < 4)
            return true;
        else
            return false;
    }
    public void CauseFire(bool isCat)
    {
        RandomizeAudio();
        if(!catSource.isPlaying && isCat)
            catSource.Play();
        //fireSound.PlayAudio();
        //StartCoroutine(LightFire());
    }
    private IEnumerator LightFire()
    {
        fireLight.enabled = true;
        while(fireLight.intensity < 1.5)
        {
            yield return null;
            fireLight.intensity += Time.deltaTime;
        }
        while(fireLight.intensity > 0)
        {
            yield return null;
            fireLight.intensity -= Time.deltaTime;
        }
    }
}
