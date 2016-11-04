using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
	public int damagePerShot = 1;
	public float range = 10f;


	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	Ray[] lightRay = new Ray[6];
	int shootableMask;
	LineRenderer gunLine;
	Light flashLight;


	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent <LineRenderer> ();
		flashLight = GetComponent<Light> ();

		flashLight.enabled=true;
		range = flashLight.range * 0.75f;
	}


	void Update ()
	{
		timer += Time.deltaTime;
		CheckCollision();
	}

	private void CheckCollision()
	{
		for( int i = 0; i < lightRay.Length; i++)
		{
			lightRay[i].origin = transform.position;
			lightRay[i].direction = Quaternion.AngleAxis(flashLight.spotAngle * (i - 3)/6, flashLight.transform.up) * flashLight.transform.forward;

			if (Physics.Raycast (lightRay[i], out shootHit, range, shootableMask))
			{				
				EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
				if(enemyHealth != null)
				{
					enemyHealth.TakeDamage (damagePerShot, shootHit.point);
				}
			}
		}
	}

	public void DisableEffects ()
	{
		gunLine.enabled = false;
		flashLight.enabled = false;
	}
}
