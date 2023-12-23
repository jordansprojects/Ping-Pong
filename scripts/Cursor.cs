using Godot;
using System;

public class Cursor : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Connect("area_entered", this, "_OnAreaEntered");
    }



//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)  {      
  	/* use GlobalPosition so that placement does not rely on parent node */
	GlobalPosition =    GetViewport().GetMousePosition();
  }


  private void _OnAreaEntered(Area2D obj)
	{
		
		
		
	}
}
