using Godot;
using System;

public class Paddle : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	
	private CharacterController _actor; 
	public static bool isBallHittable = false;
	private const float HIT_TIME = 1.0f;
	private string [] animations = new string[] {"PigA", "PigB", "PigC"};
	private AnimatedSprite _anim;
	private Player _player;
	private Timer timer;

	public bool blocked = false;

  
	public override void _Ready(){

		timer = GetNode<Timer>("../Timer");
		_player= GetParent() as Player;
		_anim = GetNode<AnimatedSprite>("AnimatedSprite");

		 Connect("body_entered", this, "_OnBodyEntered");
		 //Connect("")
	}
	private void _OnBodyEntered(Node body){
		GD.Print(this.GetType().Name + ".cs Ball detected.");
		isBallHittable = true;
		timer.Start(HIT_TIME);
		int appliedStrength = _actor.strength;
		var direction = _actor.direction;
		if (body is KinematicBody2D ball){
			 if (Input.IsActionPressed("ui_select") || Input.IsActionJustReleased("ui_select")){
				GD.Print(this.GetType().Name + ".cs Ball hit!");
			 }else if(!isBallHittable){
				GD.Print(this.GetType().Name +".cs Failed to hit ball.");
				direction = Vector2.Down; // ball falls down if you fail to click
				appliedStrength = 50;
			 }
			

		Ball data = (Ball) ball;
		var motion = ( (appliedStrength*direction) );
		ball.MoveAndCollide(motion);
		data.asp.Play();
			
		}else if (body is RigidBody2D){
		  
		}



	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta) {
	 var mouseCoords =    GetViewport().GetMousePosition();
	 _actor = _player.GetActivePlayer();
	 string animation = animations[_player.GetActiveIndex()];

	 Vector2 mousPos = GetViewport().GetMousePosition();
		 Scale = ( (_actor.GlobalPosition.x < GlobalPosition.x ) && Scale.x < 0) ? new Vector2(Scale.x*-1, Scale.y) :Scale; 
		 Scale = ( (_actor.GlobalPosition.x > GlobalPosition.x ) && Scale.x > 0) ? new Vector2(Scale.x*-1, Scale.y) :Scale; 
	_anim.Play(animation);

	//if(blocked){//TODO
	  // clamp based on what region the user is in
    var rect = _actor.regionRect;
    float x =Mathf.Clamp((int)mouseCoords.x, (int)rect.Position.x, (int)rect.End.x);
    float y =Mathf.Clamp((int)mouseCoords.y, (int)rect.Position.y, (int)rect.End.y);
    GlobalPosition = new Vector2(x,y);
	//}
	

  }

  public void SetPlayersRow(CharacterController.Row row){
	_actor.SetRow(row);
  }
  public int GetActiveIndex(){
	return _player.GetActiveIndex();
  }
}
