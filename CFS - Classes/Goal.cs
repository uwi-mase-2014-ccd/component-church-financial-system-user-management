//
//
//  Generated by StarUML(tm) C# Add-In
//
//  @ Project : Church Financial System
//  @ File Name : Goal.cs
//  @ Date : 06/04/2014
//  @ Author : Andrew Titus, William McDermott, Peter-Jon Williams, Matthew Hall, Cecil White
//
//


public class Goal {
	private string ID ;
	private string Description ;
	private decimal Required ;
	private ArrayList<Transaction> Transactions = new ArrayList<Transaction>();
	public void CreateGoal(string description, decimal required){
	}
	public void DeleteGoal(){
	}
	public void UpdateGoal(string description, decimal required){
	}
	public string GetDescription(){
	}
	public decimal GetRequired(){
	}
	public decimal GetTotalDonated(){
	}
	public Transaction GetTransaction(string transacttionID){
	}
	public bool GoalReached(){
	}
	public void Donate(Transaction donation){
	}
}