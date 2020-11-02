using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : ScriptableObject {
    private static bool enabled;
    private static float timeLeft;
    private GameObject tankParticlesObject;

    private void OnEnable() {
        enabled = false;
        timeLeft = 1;
        tankParticlesObject = GameObject.Find("TankParticles");
    }

    public void Tick(float deltaTime) {
        if (enabled) timeLeft -= deltaTime;
        if (timeLeft <= 0) {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void EndTheGame(GameObject tankObject) {
        enabled = true;
        timeLeft = 1;

        GameObject newParticleObject = Instantiate<GameObject>(tankParticlesObject);
        ParticleSystem particleSystem = newParticleObject.GetComponent<ParticleSystem>();
        particleSystem.transform.position = tankObject.transform.position;
        particleSystem.Play();
        Destroy(newParticleObject, particleSystem.main.startLifetime.constant); // destroy after the lifetime of the particles

        //bang
        AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("GameScene/Audio/explosion"), new Vector3(0, 0, 0));

        tankObject.transform.position = new Vector3(100, 100, 0);
    }

    public bool IsDead() {
        return enabled;
    }
}
