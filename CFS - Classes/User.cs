//
//
//  Generated by StarUML(tm) C# Add-In
//
//  @ Project : Church Financial System
//  @ File Name : User.cs
//  @ Date : 06/04/2014
//  @ Author : Andrew Titus, William McDermott, Peter-Jon Williams, Matthew Hall, Cecil White
//
//


public class User {
	private string ID ;
	private string FullName ;
	private string EmailAddress ;
	private ArrayList<Permission> Permissions = new ArrayList<Permission>();
	private UserProfile Profile ;
	public void CreateUser(string fullName, string emailAddress){
	}
	public void DeleteUser(){
	}
	public void UpdateUser(string fullName, string emailAddress){
	}
	public string GetFullName(){
	}
	public string GetEmailAddress(){
	}
	public void AddPermission(Permission newPermission){
	}
}