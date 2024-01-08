using Godot;
using System;

public class Timer : Godot.Timer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Connect("timeout", this, "_OnTimerTimeout");
        this.Autostart = false;
    }


    private void _OnTimerTimeOut(){
        Paddle.isBallHittable = false;
        GD.Print(this.GetType().Name + ".cs : DING. Timer is up!");
        this.Stop();
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
