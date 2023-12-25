using Godot;
using System;
using System.Collections.Generic;
using System.Timers;
public abstract class CharacterController : Node2D{
	private int _index = 0;
	private int _minIndex = 0;

	const int REST_FRAME = 1;
	const int GO_FRAME = 0;

	private float DEFAULT_SCALE = 0.5f;
	float THETA = 26;

	const int COUNT = 3;
	private bool _selected = false;
	private AnimatedSprite _anim;
	//private AnimatedSprite _paddleAnim;

	public Vector2 direction;
	public int strength;


	public enum Row: int{
		MIDDLE =0 ,LEFT =1 ,RIGHT =2
	}
	Row row = Row.MIDDLE;

	public void SetRow(Row inputRow){
		row = inputRow;
	}
	public Row GetRow(){
		return row;
	}
	public CharacterController(){}
	public CharacterController(int inputIndex){
		_minIndex = _index = inputIndex;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){	
		Scale = new Vector2(DEFAULT_SCALE, DEFAULT_SCALE);
		GD.Print(this.GetType().Name + ".cs: Ready called.");
		_anim = GetNode<AnimatedSprite>("AnimatedSprite") as AnimatedSprite;
		//_paddleAnim = GetNode<Node2D>("Paddle").GetChild<AnimatedSprite>(1);

		/*if(_paddleAnim == null){
			GD.Print(this.GetType().Name + ".cs: Error: AnimatedSprite Paddle node not found.");
		}*/
		
		if (_anim == null){
        GD.Print(this.GetType().Name + ".cs: Error: AnimatedSprite node not found.");
        // Handle the error, throw an exception, or take appropriate action.
    }
	}
	

	public void PlayBall(){
		
		// get mouse position coordinates
		 Vector2 mousPos = GetViewport().GetMousePosition();
		 Scale = ( (mousPos.x < Position.x ) && Scale.x > 0) ? new Vector2(Scale.x*-1, Scale.y) :Scale; 
		 Scale = ( (mousPos.x > Position.x ) && Scale.x < 0) ? new Vector2(Scale.x*-1, Scale.y) :Scale; 

		/*  if (Input.IsActionPressed("ui_select")){
			_paddleAnim.Play("default");

			 //reset animation to beginning if needed.
			if(_paddleAnim.Frame == 2){
			_paddleAnim.Frame = 0; //
			
			}
		 }*/

		 PlayMyStyle(); 
	}

	// incorporates unique playstyle for each character
	public abstract void PlayMyStyle();
	public void StopAnimation(){
		_anim.Stop();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta){ 
	if(_selected && _anim != null){
			PlayBall();
		}     
   }

	public void Select(){
		GD.Print(this.GetType().Name + ".cs: I am active.");
		_selected = true;
		_anim.Frame = GO_FRAME;
	//	_paddleAnim.Play("default");
	//	_paddleAnim.Stop();
	}

	public void Unselect(){
		_selected = false;
		_anim.Frame = REST_FRAME;

	//	_paddleAnim.Play("nothingness");
	//	_paddleAnim.Stop();
		
	}

	public void ChangeSeat(Chair chair){
		Position = chair.Position + new Vector2(0,5);

	}

	public int IncrementIndex(){
		_index++;
		return _index % COUNT;
	}
	public int DecrementIndex(){
		if(_index > _minIndex){
			_index--;
		}else{
			_index+=(COUNT-1);
		}
		return _index % COUNT; 
	}

	
	public bool IsSelected(){
		return _selected;
	}

} // end of class
