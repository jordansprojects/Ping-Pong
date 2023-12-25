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

    RandomNumberGenerator rand;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        rand = new RandomNumberGenerator();
        spawnPoints = new List<Node2D>();
        _anim = GetNode<AnimatedSprite>("AnimatedSprite");

    
        foreach (Node child in GetChildren()){
            if (child is Node2D){
                spawnPoints.Add((Node2D)child);
            }

            GD.Print(this.GetType().Name + ".cs " + spawnPoints.Count + " spawnpoints.");
        }

        
        
        
    }


    public void ServeBall(){
        var num = rand.RandiRange(0,spawnPoints.Count-1);
        var scene = GD.Load<PackedScene>("res://prefabs/Ball.tscn");
        Ball ball = scene.Instance() as Ball;
        GetTree().Root.AddChild(ball);
        ball.GlobalPosition = spawnPoints[num].GlobalPosition;

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
 {
       ServeBall();
  }
}
