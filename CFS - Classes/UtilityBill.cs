//
//
//  Generated by StarUML(tm) C# Add-In
//
//  @ Project : Church Financial System
//  @ File Name : UtilityBill.cs
//  @ Date : 06/04/2014
//  @ Author : Andrew Titus, William McDermott, Peter-Jon Williams, Matthew Hall, Cecil White
//
//


public class UtilityBill : BudgetItem{
	private string CustomerNumber ;
	private string PremiseNumber ;
	private string BillingStartDate ;
	private string BillingEndDate ;
	private string DueDate ;
	private string Status ;
	private ArrayList<Transaction> UtilityBillTransaction = new ArrayList<Transaction>();
	public void EnterUtilityBill(string customerNumber, string premiseNumber, Date billingStartDate, string billingEndDate, string dueDate){
	}
	public void UpdateUtilityBill(string customerNumber, string premiseNumber, string billingStartDate, string billingEndDate, string dueDate){
	}
	public void PayUtilityBill(Transaction utilityBillTransaction){
	}
	public void RemoveUtilityBill(){
	}
}
