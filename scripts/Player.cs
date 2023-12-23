// Player.cs - handles player input to control ping pong players
using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
public class Player : Node{
  
	private int _select = 0; 
	private List<CharacterController> _controllers; 
	private List<Chair> _chairs; 
	private Cursor _cursor;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){

		_cursor = GetNode<Area2D>("Cursor") as Cursor;
		PopulateControllerList();
		PopulateChairList();

		// start with first character
		for(int i = 0; i < 3; i++) ShiftRight();


		
	}

	void PickCharacter(int x ){ // enforces mutually exclusion among characters the player controls
		for(int i = 0; i < _controllers.Count; i++){
			if(i == x){
				_controllers[i].Select();
				_select = i;
			}else{
				Vector2 scale = _controllers[i].Scale;
				_controllers[i].Unselect();
				_controllers[i].Scale = (_controllers[i].Position.x < _chairs[0].Position.x && scale.x < 0 )? new Vector2(scale.x*-1, scale.y) : scale;
				_controllers[i].Scale = (_controllers[i].Position.x > _chairs[0].Position.x && scale.x > 0 )? new Vector2(scale.x*-1, scale.y) : scale;
			}
		}
	}


	public Vector2 TrackMouseCoords(){
		// get mouse position coordinates
		Vector2 mousPos = GetViewport().GetMousePosition();
		GD.Print(this.GetType().Name + "cs : MouseCoordinates " + mousPos);
		return mousPos;
	}

	void PopulateControllerList(){
		_controllers = new List<CharacterController>();
		foreach ( Node node in GetChildren()){

				if(node is CharacterController){
					_controllers.Add((CharacterController)node);
				}
				
			}
			GD.Print(this.GetType().Name + ".cs "+ _controllers.Count + " Character Controllers loaded.");
	}
	void PopulateChairList(){
		_chairs = new List<Chair>();
		foreach ( Node node in GetChildren()){
				if(node is CaptainsChair){
					GD.Print(this.GetType().Name + ".cs : Captains chair loaded.");
					_chairs.Insert(0, (CaptainsChair)node);
				}
				else if(node is Chair){
					GD.Print(this.GetType().Name + ".cs : Chair loaded.");
					_chairs.Add((Chair)node);
				}
				
			}

	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta){
	if (Input.IsActionJustPressed("ui_right")){
		ShiftRight();
	}

	if(Input.IsActionJustPressed("ui_left")){
		ShiftLeft();
	}     
  }

  public void ShiftRight(){
	for(int i = 0; i < _controllers.Count; i++){
			int index = _controllers[i].DecrementIndex();
			_controllers[i].ChangeSeat(_chairs[index]);
			if(index == 0){ // select pig in captains chair
				PickCharacter(i);
			}
		}
  }

	
  public void ShiftLeft(){
for(int i = 0; i < _controllers.Count; i++){
			int index = _controllers[i].IncrementIndex();
			_controllers[i].ChangeSeat(_chairs[index]);
			if(index == 0){ // select pig in captains chair
				PickCharacter(i);
			}
		}
  }
} // end of class
