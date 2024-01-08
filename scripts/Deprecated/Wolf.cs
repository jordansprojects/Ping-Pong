using Godot;
using System;
using System.Collections.Generic;

public class Wolf : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	AnimatedSprite _anim;
	List<Node2D> spawnPoints;

    public static bool isBallLive = false;

	Godot.Timer timer;

	RandomNumberGenerator rand;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetParent().GetNode<Godot.Timer>("BallTimer");

		if(timer == null){
			GD.Print(this.GetType().Name + ".cs Failed to fetch ball timer.");
		}
	  
		rand = new RandomNumberGenerator();
		spawnPoints = new List<Node2D>();
		_anim = GetNode<AnimatedSprite>("AnimatedSprite");

	
		foreach (Node child in GetChildren()){
			if (child is Node2D){
				spawnPoints.Add((Node2D)child);
			}

			GD.Print(this.GetType().Name + ".cs " + spawnPoints.Count + " spawnpoints.");
		}

		ServeBall();
		
		
	}

	  private void _OnBallTimerTimeOut(){
	   // ServeBall();
	}



	public void ServeBall(){
		_anim.Play("default");
		GD.Print(this.GetType().Name + ".cs serving ball!");
		var num = rand.RandiRange(0,spawnPoints.Count-1);
		var scene = GD.Load<PackedScene>("res://prefabs/Ball.tscn");
		Ball ball = scene.Instance() as Ball;
		//GetTree().Root.AddChild(ball);
		GetTree().Root.CallDeferred("add_child", ball);

		ball.GlobalPosition = spawnPoints[num].GlobalPosition;
		_anim.Frame = 0;

        isBallLive = true;

	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta){
	if (!isBallLive){
		ServeBall();
	}
  }
}
