//
//
//  Generated by StarUML(tm) C# Add-In
//
//  @ Project : Church Financial System
//  @ File Name : Event.cs
//  @ Date : 06/04/2014
//  @ Author : Andrew Titus, William McDermott, Peter-Jon Williams, Matthew Hall, Cecil White
//
//


public class Event {
	private string Name ;
	private string Description ;
	private string StartDate ;
	private string EndDate ;
	private ArrayList<Goal> Goals = new ArrayList<Goal>();
	public void CreateEvent(string name, string description, string startDate, string endDate){
	}
	public void CloseEvent(){
	}
	public void UpdateEvent(string name, string description, string startDate, string endDate){
	}
	public string GetName(){
	}
	public string GetDescription(){
	}
	public DateTime GetStartDate(){
	}
	public DateTime GetEndDate(){
	}
	public void AddGoal(Goal newGoal){
	}
	public void RemoveGoal(string goalID){
	}
}
