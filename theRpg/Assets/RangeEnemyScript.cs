using UnityEngine;
using System.Collections;

public class RangeEnemyScript : BasicMoveScript {

	public float fireRate = 1.0f;
	public Transform projectile;
	public int shotspeed = 3;

	private float timer = 1.0f;

	public override void Attack (float direction)
	{
		if (timer < 0) {
			Transform arrow = Instantiate (projectile) as Transform;
			arrow.position = transform.position;
			//arrow.RotateAround(arrow.position, new Vector3(0,0,1), direction);
			ProjectileScript ps = arrow.GetComponent<ProjectileScript>();
			if (ps != null){
				Vector2 dirc = (GetTarget() - transform.position);
				dirc.Normalize();
				float ang =  Vector2.Angle(new Vector2(-1, 0), dirc);
				if (dirc.y > 0){
					ang = Vector2.Angle(new Vector2(1, 0), dirc);
				}
				arrow.RotateAround(arrow.position, new Vector3(0,0,1), ang);
				ps.direction = dirc;
				ps.speed = shotspeed;
			}
			timer = fireRate;
		}

	}

	public override void TimeStuff ()
	{
		timer -= Time.deltaTime ;
		base.TimeStuff ();
	}


}
