using Sandbox;

namespace FighterGame;
public sealed class FighterMovement : Component
{
	[Property] CapsuleCollider Collider { get; set; }
	[Property] float Weight { get; set; } = 1f;
	[Property] float Gravity { get; set; } = 600f;
	[Property] float Speed { get; set; } = 180f;
	public CharacterController controller;
	Vector3 WishVelocity = Vector3.Zero;
	protected override void OnStart()
	{
		controller = Collider.Components.Get<CharacterController>();
	}
	protected override void OnUpdate()
	{
		WishVelocity = new Vector3 (Input.AnalogMove.y, -Input.AnalogMove.x, 0) * Speed;
	}
	protected override void OnFixedUpdate()
	{
		//controller.Accelerate( WishVelocity );
		// Apply gravity
		if( !controller.IsOnGround ) controller.Accelerate( new Vector3( 0, -800, 0 ) * Gravity );

		// Movement
		controller.Move();
		WorldPosition = Collider.WorldPosition;
		Log.Info(controller.IsOnGround);
	}
}